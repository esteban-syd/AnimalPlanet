using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Animal.Datos;

namespace Animal.Negocios
{
    public class Usuario
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public Usuario()
        {
            
        }

        public Usuario( string username, string name, string password)
        {
            this.Username = username;
            this.Name = name;
            Password = password;

        }

        public bool Create()
        {
            try
            {
                Datos.usuario usu = new Datos.usuario()
                {
                    Username = this.Username,
                    Name = this.Name,
                    Password = this.Password,

                };
                Conexion.Ani.usuario.Add(usu);
                Conexion.Ani.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public bool Leer()
        {
            try
            {
                Datos.usuario iniciar = Conexion.Ani.usuario.First(pp => pp.Password == Password);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Delete()
        {
            try
            {
                Datos.usuario user = Conexion.Ani.usuario.First(e => e.Name == Name);
                Conexion.Ani.usuario.Remove(user);
                Conexion.Ani.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
