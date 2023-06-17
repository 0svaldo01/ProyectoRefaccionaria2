using Microsoft.EntityFrameworkCore;
using ProyectoRefaccionaria2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoRefaccionaria2.Catalogos
{
    public class MarcasCatalogo
    {
        RefaccionariaContext context = new RefaccionariaContext();
        
        public IEnumerable<Marcas> GetAllMarcas() 
        {
            return context.Marcas.OrderBy(x => x.Nombre);
        }

        public void Create(Marcas m)
        {
            context.Database.ExecuteSqlRaw($"call refaccionaria.spAgregarMarca('{m.Nombre}');");
            context.SaveChanges();
        }
        public void Update(Marcas m)
        {
            context.Update(m);
            context.SaveChanges();
        }
        public void Delete(Marcas m)
        {
            context.Remove(m);
            context.SaveChanges();
        }
    }
}
