using MKT.Data.Services;
using System.Collections.Generic;
using MKT.Entities.Models;
using System.Data;

namespace MKT.Business
{
    public class BizOrderDetail
    {
        public void Agregar(OrderDetail order)
        {
            var db = new BaseDataService<OrderDetail>();
            db.Create(order);

        }

        public List<OrderDetail> TraerTodos()
        {
            var db = new BaseDataService<OrderDetail>();
            var lista = db.Get();
            return lista;
        }

        public List<OrderDetail> TraerTodos(int id)
        {
            var db = new BaseDataService<OrderDetail>();
            var lista = db.Get(e => e.OrderId == id);
            return lista;
        }

        public OrderDetail TraerPorId(int id)
        {
            var db = new BaseDataService<OrderDetail>();
            return db.GetById(id);
        }

        public void Eliminar(OrderDetail order)
        {
            var db = new BaseDataService<OrderDetail>();
            db.Delete(order);
        }

        public void Actualizar(OrderDetail order)
        {
            var db = new BaseDataService<OrderDetail>();
            db.Update(order);
        }
    }
}
