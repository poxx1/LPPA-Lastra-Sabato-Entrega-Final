using MKT.Data.Services;
using System.Collections.Generic;
using MKT.Entities.Models;

namespace MKT.Business
{
    public class BizOrder
    {
        public Order Agregar(Order order)
        {
            var db = new BaseDataService<Order>();
            return db.Create(order);

        }

        public void AgregarDetalle(OrderDetail orderDetail)
        {
            var db = new BaseDataService<OrderDetail>();
             db.Create(orderDetail);
        }

        public List<Order> TraerTodos()
        {
            var db = new BaseDataService<Order>();
            var lista = db.Get();
            return lista;
        }

        public Order TraerPorId(int id)
        {
            var db = new BaseDataService<Order>();
            return db.GetById(id);
        }

        public void Eliminar(Order order)
        {
            var db = new BaseDataService<Order>();
            db.Delete(order);
        }

        public void Actualizar(Order order)
        {
            var db = new BaseDataService<Order>();
            db.Update(order);
        }
    }
}
