using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProyectoRefaccionaria2.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public object ViewModelActual { get; set; } = new ProductosViewModel();

        public ICommand NavegarMarcasCommand { get; set; }
        public ICommand NavegarProductosCommand { get; set; }
        public ICommand NavegarUsuariosCommand { get; set; }

        public MainViewModel()
        {
            NavegarMarcasCommand = new RelayCommand(NavegarMarcas);
            NavegarProductosCommand = new RelayCommand(NavegarProductos);
            NavegarUsuariosCommand = new RelayCommand(NavegarUsuarios);
        }

        private void NavegarUsuarios()
        {
            ViewModelActual = new ProductosViewModel();
            Actualizar(nameof(ViewModelActual));
        }

        private void NavegarProductos()
        {
            ViewModelActual = new ProductosViewModel();
            Actualizar(nameof(ViewModelActual));
        }

        private void NavegarMarcas()
        {
            ViewModelActual = new MarcasViewModel();
            Actualizar(nameof(ViewModelActual));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void Actualizar(string? propiedad = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propiedad));
        }
    }
}
