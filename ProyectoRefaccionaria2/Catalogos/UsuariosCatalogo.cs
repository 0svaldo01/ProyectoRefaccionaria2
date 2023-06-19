﻿using Microsoft.EntityFrameworkCore;
using ProyectoRefaccionaria2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoRefaccionaria2.Catalogos
{
    public class UsuariosCatalogo
    {
        RefaccionariaContext context = new RefaccionariaContext();

        //En este metodo mandamos llamar a la base de datos una lista con todos los usuarios ordenados por el id
        public IEnumerable<Usuarios> GetAllUsuarios()
        {
            return context.Usuarios.OrderBy(x => x.IdUsuarios).Include(x=>x.IdTipoRolNavigation);
        }

        //Realmente no se como se implementa ese metodo, solo recuerdo
        //que es necesario para reflejar cambios sin cerrar el programa
        public void Recargar(Usuarios u)
        {
            context.Entry(u).Reload();
        }
        public void Create(Usuarios u)
        {
            context.Add(u);
            context.SaveChanges();
            context.Entry(u).Reload();
        }
        public void Update(Usuarios u)
        {
            context.Update(u);
            context.SaveChanges();
            context.Entry(u).Reload();
        }
        public void Delete(Usuarios u)
        {
            context.Remove(u);
            context.SaveChanges();

        }
    }
}
