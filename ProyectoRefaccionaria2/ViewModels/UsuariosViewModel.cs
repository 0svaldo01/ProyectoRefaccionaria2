﻿using ProyectoRefaccionaria2.Catalogos;
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
        UsuariosRolCatalogo catalogoroles = new UsuariosRolCatalogo();
        

        public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection<Usuarios> ListaUsuarios { get; set; }= new ObservableCollection<Usuarios>();
        public ObservableCollection<Rolesusuarios> ListaRolesUsuarios { get; set; } = new ObservableCollection<Rolesusuarios>();
        public Usuarios? Usuario { get; set; } = new Usuarios();
        public Rolesusuarios? rol { get; set; }
        public string Error { get; set; }
        public string Vista { get; set; }
        public ICommand VerUsuariosCommand { get; set; }
        public ICommand VerAgregarCommand { get; set; }
        public ICommand AgregarUsuarioCommand {  get; set; }
        public ICommand VerEditarUsuarioCommand { get; set; }
        public ICommand EditarUsuariosCommand { get; set; }
        public ICommand VerEliminarUsuariosCommand { get; set; }
        public ICommand EliminarUsuariosCommand { get; set; }
        public ICommand RegresarCommand { get; set; }

        public UsuariosViewModel()
        {
            VerUsuariosCommand = new RelayCommand(VerUsuarios);
            VerAgregarCommand = new RelayCommand(VerAgregarUsuarios);
            AgregarUsuarioCommand = new RelayCommand(AgregarUsuario);
            VerEditarUsuarioCommand = new RelayCommand(VerEditarUsuarios);
            EditarUsuariosCommand = new RelayCommand(EditarUsuarios);
            VerEliminarUsuariosCommand = new RelayCommand(VerEliminarUsuarios);
            EliminarUsuariosCommand = new RelayCommand(EliminarUsuarios);

            RegresarCommand = new RelayCommand(Regresar);

            ActualizarBD();
            Actualizar();
            
        }
        private void AgregarUsuario()
        {
            if(Vista == "VerAgregarUsuarios" && Usuario!= null) 
            {
                catalogousuarios.Create(Usuario);
            }
            if(Vista== "VerEditarUsuarios" && Usuario != null) 
            {
                catalogousuarios.Update(Usuario);
            }
            ActualizarBD();
        }

        private void VerAgregarUsuarios()
        {
            Vista = "VerAgregarUsuarios";
            Actualizar();
        }
        private void VerEliminarUsuarios()
        {
            throw new NotImplementedException();
        }

        private void EliminarUsuarios()
        {
            throw new NotImplementedException();
        }

        private void VerEditarUsuarios()
        {
            throw new NotImplementedException();
        }
        private void EditarUsuarios()
        {
            throw new NotImplementedException();
        }

        private void Regresar()
        {
            Vista = "VerUsuarios";
            catalogousuarios.Recargar(Usuario);
            Actualizar();
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
<<<<<<< HEAD
           foreach(var item in ca)
=======
            foreach (var item in catalogoroles.GetAllRolesUsuarios())
            {
                ListaRolesUsuarios.Add(item);
            }
>>>>>>> ya funciona agregar usuarios
            Actualizar();
        }
    }
}
