using MKT.Data.Services;
using MKT.Entities.Models;
using System.Collections.Generic;

namespace MKT.Business
{
    public class BizRol
    {
        public void Agregar(Rol rol)
        {
            var db = new BaseDataService<Rol>();
            db.Create(rol);
        }

        public List<Rol> TraerTodos()
        {
            var db = new BaseDataService<Rol>();
            var lista = db.Get();
            return lista;
        }
        public Rol TraerPorId(int id)
        {
            var db = new BaseDataService<Rol>();
            return db.GetById(id);
        }
        public void Eliminar(Rol rol)
        {
            var db = new BaseDataService<Rol>();
            db.Delete(rol);
        }
        public void Eliminar(int idRol)
        {
            var db = new BaseDataService<Rol>();
            db.Delete(idRol);
        }

        public void Actualizar(Rol rol)
        {
            var db = new BaseDataService<Rol>();
            db.Update(rol);
        }
    }
}
