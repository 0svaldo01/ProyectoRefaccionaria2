using System;
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
        public string Vista;

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
            VerEditarMarcasCommand = new RelayCommand(VerEditarMarcas);
            EditarMarcasCommand = new RelayCommand(EditarMarcas);
            VerEliminarMarcasCommand = new RelayCommand(VerEliminarMarcas);
            AgregarMarcasCommand = new RelayCommand(EliminarMarcas);
            RegresarCommand = new RelayCommand(Regresar);

            //Se actualiza primero la base de datos para que se 
            //muestren los cambios y luego ya actualizas para que se vean los cambios ¿no?
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
            throw new NotImplementedException();
        }

        private void VerEditarMarcas()
        {
            throw new NotImplementedException();
        }

        private void EditarMarcas()
        {
            throw new NotImplementedException();
        }

        private void VerEliminarMarcas()
        {
            throw new NotImplementedException();
        }

        private void EliminarMarcas()
        {
            throw new NotImplementedException();
        }

        private void Regresar()
        {
            throw new NotImplementedException();
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
