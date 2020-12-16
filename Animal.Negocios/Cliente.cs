using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Animal.Negocios;
using Animal.Datos;
namespace Animal.Negocios
{
     public class Cliente
    {
        #region atributos
        private int _id;
        private Nullable<int> _edad;
        private string _rut, _nombre; 
        private MetodoPago _MetoPago;
        #endregion
        #region Propiedades

              
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }      
        public Nullable<int> Edad
        {
            get { return _edad; }
            set { _edad = value; }

        }
        public string Rut
        {
            get { return _rut; }
            set { _rut = value; }
            
        }
        public string Nombre
        {
            get { return _nombre; }
            set
            {
                if (value.Split(' ').Length >= 2)
                    _nombre = value;
                else
                    throw new ArgumentException("Ingrese primer y apellido");
            }
        }
        public MetodoPago MetoPago
        {
            get { return _MetoPago; }
            set { _MetoPago = value; }
        }
        #endregion
        #region Contructor

        public Cliente()
        {
            _id = 0;
            _edad = 0;
            _rut = string.Empty;
            _nombre = string.Empty;          
            _MetoPago = MetodoPago.Debito;
         
        }

        public Cliente(int IDCLIENTE, Nullable<int> EDAD_C, string RUT, string NOMBRE,  string PAGO)
        {
            Id = IDCLIENTE;
            Edad = EDAD_C;
            Rut = RUT;
            Nombre = NOMBRE;
            MetodoPago PP;
            Enum.TryParse(PAGO, out PP);
            MetoPago = PP;


        }

        #endregion
        #region CRUD
        public bool Create ()  //Crear cliente 
        {
            try
            {
                Datos.CLIENTE cli = new Datos.CLIENTE()
                {
                    IDCLIENTE = Id,
                    EDAD_C = Edad,
                    RUT = Rut,
                    NOMBRE = Nombre,
                    PAGO = MetoPago.ToString(),
            
                };
                Conexion.Ani.CLIENTE.Add(cli);
                Conexion.Ani.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Read () // leer o buscar por rut ....
        {
            try
            {
                Datos.CLIENTE ci = (from clie in Conexion.Ani.CLIENTE
                                     where clie.RUT == Rut
                                     select clie).First();
                Id = ci.IDCLIENTE;
                Edad = ci.EDAD_C;
                Rut = ci.RUT;
                Nombre = ci.NOMBRE;
                MetodoPago MP;
                Enum.TryParse(ci.PAGO, out MP);
                MetoPago =MP;
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Update ()
        {
            try
            {
                Datos.CLIENTE cli = Conexion.Ani.CLIENTE.First(p => p.RUT == Rut);
                cli.IDCLIENTE = Id;
                cli.EDAD_C = Edad;
                cli.RUT = Rut;
                cli.NOMBRE = Nombre;
                cli.PAGO = MetoPago.ToString();
                Conexion.Ani.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }//Actualizar cliente 
        public bool Delete ()
        {
            try
            {
                Datos.CLIENTE cli = (from clien in Conexion.Ani.CLIENTE
                                     where clien.RUT == Rut
                                     select clien).First();
                Conexion.Ani.CLIENTE.Remove(cli);
                Conexion.Ani.SaveChanges();
                return true;

            }
            catch
            {
                return false;
            }
        } //Eliminar

        #endregion



    }// final
}
