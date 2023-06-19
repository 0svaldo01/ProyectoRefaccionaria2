using ProyectoRefaccionaria2.Catalogos;
using ProyectoRefaccionaria2.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoRefaccionaria2.Views.UsuariosViews;
using GalaSoft.MvvmLight.Command;
using System.ComponentModel;
using System.Windows.Input;
using System.Printing;

namespace ProyectoRefaccionaria2.ViewModels
{
    public class UsuariosViewModel: INotifyPropertyChanged
    {
        UsuariosCatalogo catalogousuarios = new UsuariosCatalogo();
        

        public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection<Usuarios> ListaUsuarios { get; set; }= new ObservableCollection<Usuarios>();
        public ObservableCollection<Rolesusuarios> ListaRolesUsuarios { get; set; } = new ObservableCollection<Rolesusuarios>();
        public Usuarios? usuario { get; set; }
        public Rolesusuarios? rol { get; set; }
        public string Vista { get; set; }
        public ICommand VerUsuariosCommand { get; set; }
        public ICommand VerAgregarCommand { get; set; }
        public ICommand AgregarUsuarioCommand {  get; set; }
        public ICommand VerEditarUsuarioCommand { get; set; }
        public ICommand EditarUsuariosCommand { get; set; }
        public ICommand RegresarCommand { get; set; }

        public UsuariosViewModel()
        {
            VerUsuariosCommand = new RelayCommand(VerUsuarios);
            VerAgregarCommand = new RelayCommand(verAgregar);
            AgregarUsuarioCommand = new RelayCommand(AgregarUsuario);
            VerEditarUsuarioCommand = new RelayCommand(VerEditar);
            RegresarCommand = new RelayCommand(Regresar);
            ActualizarBD();
            Actualizar();
            
        }

        private void Regresar()
        {
        
            Actualizar();
        }
 
        private void VerEditar()
        {
            throw new NotImplementedException();
        }

        private void AgregarUsuario()
        {
            throw new NotImplementedException();
        }

        private void verAgregar()
        {
            throw new NotImplementedException();
        }

        private void VerUsuarios()
        {
            throw new NotImplementedException();
        }

        private void Actualizar(string? propiedad = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propiedad));
        }

        private void ActualizarBD()
        {
            ListaUsuarios.Clear();
            ListaRolesUsuarios.Clear();
            foreach (var item in catalogousuarios.GetAllUsuarios())
            {
                ListaUsuarios.Add(item);
            }
            foreach(var item in ca)
            Actualizar();
        }
    }
}
