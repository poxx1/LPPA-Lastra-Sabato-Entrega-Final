using MKT.Data.Services;
using System.Collections.Generic;
using System.Linq;
using MKT.Entities.Models;

namespace MKT.Business
{
    public class BizUsuario
    {
        public void Agregar(User usuario)
        {
            var db = new BaseDataService<User>();

            //Encripto el Password para guardarlo en la BD
            usuario.RolId = 2;
            usuario.Password = Encrypter.Encriptar(usuario.Password);
            usuario.Password_ = Encrypter.Encriptar(usuario.Password_);
            usuario.NombreWeb = usuario.Nombre + " " + usuario.Apellido;

            db.Create(usuario);

        }

        public List<User> TraerTodos()
        {
            var db = new BaseDataService<User>();
            var lista = db.Get();
            return lista;
        }

        public User TraerPorId(int id)
        {
            var db = new BaseDataService<User>();
            return db.GetById(id);
        }

        public User TraerPorEmail(string email)
        {
            var db = new BaseDataService<User>();
            return db.Get().SingleOrDefault(u => u.Email == email);
        }

        public void Eliminar(User usuario)
        {
            var db = new BaseDataService<User>();
            db.Delete(usuario);
        }
        public void Eliminar(int idUsuario)
        {
            var db = new BaseDataService<User>();
            db.Delete(idUsuario);
        }

        public void Actualizar(User usuario)
        {

            var db = new BaseDataService<User>();

            db.Update(usuario);
        }


        public void ActualizarPorEmail(string dato, string email)
        {
            var db = new BaseDataService<User>();
            User Busuario = db.Get((User usuario) => usuario.Email == email).First();
            string clave = dato;
            string SHAClave = Encrypter.Encriptar(clave);
            Busuario.Password = SHAClave;
            Busuario.Password_ = SHAClave;
            Busuario.Email_ = email;
            Busuario.UserToken = SHAClave;
            db.Update(Busuario);
        }

        public void RecuperarPorEmail(string dato, string email)
        {
            var db = new BaseDataService<User>();
            User Busuario = db.Get((User usuario) => usuario.Email == email).First();
            string clave = dato;
            string SHAClave = Encrypter.Encriptar(clave);
            Busuario.Password = SHAClave;
            Busuario.Password_ = SHAClave;
            Busuario.Email_ = email;
            //string Titulo = "Recupero de Contraseña";
            string Cuerpo = Busuario.Nombre + " " + Busuario.Apellido + " Tu Clave se Cambio con Exito a  " + dato;
            Busuario.UserToken = SHAClave;
            db.Update(Busuario);
        }
    }
}
