using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MKT.Entities.Models;

namespace MKT.Data.Services
{
    public class ValidateLogin
    {
        public static bool Validar(User model, ref string rol)
        {
            bool ValidadorIngreso = false;
            string Password = model.Password;
            var db = new BaseDataService<User>();
            var Ouser = db.Get((User usuario) => usuario.Email == model.Email).FirstOrDefault();

            if (Ouser == null)
            {
                return false;
            }

            string Password2 = Ouser.Password;
            ValidadorIngreso = Encrypter.Validar(Password, Password2);
            rol = Ouser.Rol.Nombre;
            if (ValidadorIngreso == false)
            {

                string uToken = Ouser.UserToken;

                ValidadorIngreso = Encrypter.Validar(Password, uToken);

            }
            return ValidadorIngreso;
        }
    }
}
