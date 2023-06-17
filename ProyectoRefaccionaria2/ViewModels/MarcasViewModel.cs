﻿using System;
using ProyectoRefaccionaria2.Catalogos;
using ProyectoRefaccionaria2.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using ProyectoRefaccionaria2.Views.MarcasViews;
using System.Windows.Controls;

//se agrega un using para tener acceso a las views de marcas

namespace ProyectoRefaccionaria2.ViewModels
{
    public class MarcasViewModel : INotifyPropertyChanged
    {
        #region eventos
        public event PropertyChangedEventHandler? PropertyChanged;
        #endregion
        MarcasCatalogo catalogomarcas = new MarcasCatalogo();
        public ObservableCollection<Productos> ListaProductos { get; set; } 
        public ObservableCollection<Marcas> ListaMarcas { get; set; }

        // se hace una propiedad para mandar a llamar las vistas
        public string Vista { get; set; }

        //se manda a llamar la clase de models para poder darle uso en los metodos de marcas
        public Marcas?Marcas { get; set; }

        #region commands
        public ICommand VerMarcasCommand { get; set; }
        public ICommand VerAgregarMarcasCommand { get; set; }
        public ICommand AgregarMarcasCommand { get; set; }
        public ICommand VerEditarMarcasCommand { get; set; }
        public ICommand EditarMarcasCommand { get; set; }
        public ICommand VerEliminarMarcasCommand { get; set; }
        public ICommand EliminarMarcasCommand { get; set; }
        public ICommand RegresarCommand { get; set; }

        #endregion

        public MarcasViewModel()
        {
            VerMarcasCommand = new RelayCommand(VerMarcas);
            VerAgregarMarcasCommand = new RelayCommand(VerAgregarMarcas);
            AgregarMarcasCommand = new RelayCommand(AgregarMarcas);
            VerEditarMarcasCommand = new RelayCommand<Marcas>(VerEditarMarcas);
            EditarMarcasCommand = new RelayCommand<Marcas>(EditarMarcas);
            VerEliminarMarcasCommand = new RelayCommand(VerEliminarMarcas);
            AgregarMarcasCommand = new RelayCommand<Marcas>(EliminarMarcas);
            RegresarCommand = new RelayCommand<Marcas>(Regresar);

            //Se actualiza primero la base de datos para que se 
            //muestren los cambios y luego ya actualizas para que se vean los cambios ¿no?
            //si, asi es como se actualiza
            ActualizarBD();
            Actualizar();


        }

        private void VerMarcas()
        {
            throw new NotImplementedException();
        }

        private void VerAgregarMarcas()
        {
            throw new NotImplementedException();
        }

        private void AgregarMarcas()
        {
            if(Marcas != null)
            {
                if (Marcas.IdMarca != 0)
                {
                    catalogomarcas.Update(Marcas);
                }
                else
                {
                    catalogomarcas.Create(Marcas);
                }
                
            }
            ActualizarBD();
            Vista = "Ver";
            Actualizar();
        }

        private void VerEditarMarcas(Marcas m)
        {
           if(m != null)
            {
                catalogomarcas.Update(m);
                ActualizarBD();
                Vista = "Editar";
                Actualizar();
            }
        }

        private void EditarMarcas(Marcas m)
        {
            Marcas = m;
            Vista = "Editar";
            Actualizar();
        }

        private void VerEliminarMarcas()
        {
            if(Marcas != null)
            {
                catalogomarcas.Delete(Marcas);
                ActualizarBD() ;
                Vista = "Ver";
                Actualizar();
            }
        }

       // se manda a llamar el model en el metodo, si es diferente a nulo, 
       //abre la vista de eliminar, al eliminar se actualiza la base de datos
        private void EliminarMarcas(Marcas m)
        {
            if(m !=null)
            {
                Marcas = m;
                Vista = "Eliminar";
                ActualizarBD();
            }
        }

        //metodo para regresar/cancelar la accion en la vista
        //y regrese a la vista anterior
        private void Regresar(Marcas m)
        {
            Marcas = m;
            Vista = "Regresar";
            Actualizar();
        }

        //Actualizar la base de datos para que se vean los cambios en la lista
        //por eso primero se borra y se llena de nuevo ¿no?
        private void ActualizarBD()
        {
            ListaMarcas.Clear();
            foreach (var item in catalogomarcas.GetAllMarcas())
            {
                ListaMarcas.Add(item);
            }
            Actualizar();
        }
        //Metodo que uso para actualizar y cambiar las vistas
        private void Actualizar(string? propiedad = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propiedad));
        }
    }
}
