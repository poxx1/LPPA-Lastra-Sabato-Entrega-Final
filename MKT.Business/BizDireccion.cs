using MKT.Data.Services;
using System.Collections.Generic;
using MKT.Entities.Models;

namespace MKT.Business
{
    public class BizDireccion
    {
        public void Agregar(Address direccion)
        {
            var db = new BaseDataService<Address>();
            db.Create(direccion);

        }

        public List<Address> TraerTodos()
        {
            var db = new BaseDataService<Address>();
            var lista = db.Get();
            return lista;
        }

        public Address TraerPorId(int id)
        {
            var db = new BaseDataService<Address>();
            return db.GetById(id);
        }

        public void Eliminar(Address direccion)
        {
            var db = new BaseDataService<Address>();
            db.Delete(direccion);
        }

        public void Actualizar(Address direccion)
        {
            var db = new BaseDataService<Address>();
            db.Update(direccion);
        }
    }
}
