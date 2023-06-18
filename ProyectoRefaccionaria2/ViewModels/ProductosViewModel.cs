using GalaSoft.MvvmLight.Command;
using ProyectoRefaccionaria2.Catalogos;
using ProyectoRefaccionaria2.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProyectoRefaccionaria2.ViewModels
{
    public class ProductosViewModel : INotifyPropertyChanged
    {
        #region eventos
        public event PropertyChangedEventHandler? PropertyChanged;
        #endregion

        ProductosCatalogo catalogoproductos = new ProductosCatalogo();
       
        public ObservableCollection<Productos> ListaProductos { get; set; } = new ObservableCollection<Productos>();
        public ObservableCollection<Marcas> ListaMarcas { get; set; }
        public string Vista { get; set; }

        #region commands
        public ICommand VerProductosCommand { get; set; }
        public ICommand VerAgregarProductosCommand { get; set; }
        public ICommand AgregarProductosCommand { get; set; }
        public ICommand VerEditarProductosCommand { get; set; }
        public ICommand EditarProductosCommand { get; set; }
        public ICommand VerEliminarProductosCommand { get; set; }
        public ICommand EliminarProductosCommand { get; set; }
        public ICommand RegresarCommand { get; set; }
        #endregion
        public ProductosViewModel()
        {
            VerProductosCommand = new RelayCommand(VerProductos);
            VerAgregarProductosCommand = new RelayCommand(VerAgregarProductos);
            AgregarProductosCommand = new RelayCommand(AgregarProductos);
            VerEditarProductosCommand = new RelayCommand(VerEditarProductos);
            EditarProductosCommand = new RelayCommand(EditarProductos);
            VerEliminarProductosCommand = new RelayCommand(VerEliminarProductos);
            AgregarProductosCommand = new RelayCommand(EliminarProductos);
            RegresarCommand = new RelayCommand(Regresar);

            //Se actualiza primero la base de datos para que se 
            //muestren los cambios y luego ya actualizas para que se vean los cambios ¿no?
            ActualizarBD();
            Actualizar();
        }

        private void VerProductos()
        {
            Vista = "";
        }

        private void VerAgregarProductos()
        {
            Vista = "VerAgregarProductos";
            Actualizar();
        }

        private void AgregarProductos()
        {
            throw new NotImplementedException();
        }

        private void VerEditarProductos()
        {
            throw new NotImplementedException();
        }

        private void EditarProductos()
        {
            throw new NotImplementedException();
        }

        private void VerEliminarProductos()
        {
            throw new NotImplementedException();
        }

        private void EliminarProductos()
        {
            throw new NotImplementedException();
        }

        private void Regresar()
        {
          
        }

        //Actualizar la base de datos para que se vean los cambios en la lista
        //por eso primero se borra y se llena de nuevo ¿no?
        private void ActualizarBD()
        {
            ListaProductos.Clear();
            foreach (var item in catalogoproductos.GetAllProductos())
            {
                ListaProductos.Add(item);
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
