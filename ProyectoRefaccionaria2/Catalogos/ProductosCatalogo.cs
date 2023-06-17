using Microsoft.EntityFrameworkCore;
using ProyectoRefaccionaria2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoRefaccionaria2.Catalogos
{
    public class ProductosCatalogo
    {
        RefaccionariaContext context = new RefaccionariaContext();

        public IEnumerable<Productos> GetAllProductos() 
        {
            return context.Productos.OrderBy(x => x.Nombre);
        }

        public void Create(Productos p)
        {
            context.Database.ExecuteSqlRaw($"call refaccionaria.spAgregarProducto('{p.Descripcion}','{p.Nombre}','{p.Precio}','{p.IdMarcaP}');");
            context.SaveChanges();
            context.Entry(p).Reload();
        }
        public void Update(Productos p)
        {
            context.Update(p);
            context.SaveChanges();
        }
        public void Delete(Productos p)
        {
            context.Remove(p);
            context.SaveChanges();
        }

    }
}
