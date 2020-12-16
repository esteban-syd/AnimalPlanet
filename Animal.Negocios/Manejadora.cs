using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Animal.Datos;
using Animal.Negocios;


namespace Animal.Negocios
{
    public class Manejadora
    {
        public List<Mascota> ListarMascotas()
        {
            List<Mascota> ListaMascotas = new List<Mascota>();
            foreach (Datos.MASCOTA Masco in Conexion.Ani.MASCOTA)
            {
                Mascota NuevaMascota = new Mascota
               (Masco.IDMASCOTA, Masco.NOMBRE, Masco.EDAD, Masco.RAZA, Masco.ESTERILIZADO, Masco.SEXO , Masco.TIPO_ATENCION, Masco.FECHA_NACIMIENTO);
                ListaMascotas.Add(NuevaMascota);
            }
            return ListaMascotas;
        }


        public List<Cliente> ListarClientes()
        {
            List<Cliente> ListaClientes = new List<Cliente>();
            foreach (Animal.Datos.CLIENTE Cli in Conexion.Ani.CLIENTE)
            {
                Cliente NuevoCLiente = new Cliente(Cli.IDCLIENTE,Cli.EDAD_C, Cli.RUT, Cli.NOMBRE, Cli.PAGO);
                ListaClientes.Add(NuevoCLiente);

            }
            return ListaClientes;
        }

         public List<Usuario> ListarUser ()
        {
            List<Usuario> ListaUsuarios = new List<Usuario>();
            foreach (Animal.Datos.usuario User in Conexion.Ani.usuario)
            {
                Usuario NuevoUser = new Usuario(User.Username, User.Name, User.Password);
                ListaUsuarios.Add(NuevoUser);
            }
            return ListaUsuarios;
        }
    }
};