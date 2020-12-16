using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Animal.Datos;
using Animal.Negocios;
namespace Animal.Negocios
{
    public class Mascota
    {
        #region variables
        private int _id;
        private string _nom;
        private Nullable<int> _edad;
        public TipoRaza _raza;
        private Esterilizados _esterilizado;
        private Sexos _sexo;
        public TipoAtencion _tipoAt;
        private Nullable<DateTime> _fechaNacimiento;
  
        #endregion
        #region Propiedades
        public int Id
        {
            get { return _id; }
            set {_id = value;}

        }
        public string Nombre
        {
            get { return _nom; }
            set { _nom = value; }
        }
        public Nullable<int> Edadm
        {
            get { return _edad; }
            set { _edad = value; }
        }
        public TipoRaza Raza
        {
            get { return _raza; }
            set { _raza = value; }
        }
        public Esterilizados Esterilizado
        {
            get { return _esterilizado; }
            set { _esterilizado = value; }
        }
        public Sexos Sexo
        {
            get { return _sexo; }
            set { _sexo = value; }
        }
        public TipoAtencion TipoAte
        {
            get { return _tipoAt; }
            set { _tipoAt = value; }
        }
        public Nullable<DateTime> FechaNaci
        {
            get { return _fechaNacimiento; }
            set { _fechaNacimiento = value; }
        }
      
        #endregion
        #region Contructor
        public Mascota()
        {
            _id = 1;
            _nom = string.Empty;
            _edad = 1;
            _raza = TipoRaza.Pitbull;
            _esterilizado = Esterilizados.NO;
            _sexo = Sexos.Hembra;       
           _tipoAt = TipoAtencion.Control;
            _fechaNacimiento = DateTime.Now;

        }

        public Mascota(int id, string nom, Nullable<int> edad, string TipoRaza, string ester, string sexo, string TipoAtencion, Nullable<DateTime> fechaN )
        {

            Id = id;
            Nombre = nom;
            Edadm = edad;
            TipoRaza tr;
            Enum.TryParse(TipoRaza, out tr);
            Raza = tr;
            Esterilizados ET;
            Enum.TryParse(ester, out ET);
            Esterilizado = ET;
            Sexos SX;
            Enum.TryParse(sexo, out SX);
            Sexo = SX;          
            TipoAtencion ta;
            Enum.TryParse(TipoAtencion, out ta);
            TipoAte = ta;
            FechaNaci = fechaN;


        }
     

        #endregion
        #region CRUD
        public bool  Create()
        {
            try
            {
                Datos.MASCOTA mas = new Datos.MASCOTA()
                {
                    IDMASCOTA = Id,
                    NOMBRE = Nombre,
                    EDAD = Edadm,
                    RAZA = Raza.ToString(),              
                    ESTERILIZADO = Esterilizado.ToString(),
                    SEXO = Sexo.ToString(),
                    TIPO_ATENCION = TipoAte.ToString(),
                    FECHA_NACIMIENTO = FechaNaci,
                };
                Conexion.Ani.MASCOTA.Add(mas);
                Conexion.Ani.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;

            }
        }
        public bool Read()
        {
            try
            {
                Datos.MASCOTA ma = (from mais in Conexion.Ani.MASCOTA
                                    where mais.IDMASCOTA == Id
                                    select mais).First();
                Id = ma.IDMASCOTA;
                Nombre = ma.NOMBRE;
                Edadm = ma.EDAD;
                TipoRaza TR;
                Enum.TryParse(ma.RAZA, out TR);
                Raza = TR;             
                Esterilizados ET;
                Enum.TryParse(ma.ESTERILIZADO, out ET);
                Esterilizado = ET;
                Sexos SX;
                Enum.TryParse(ma.SEXO, out SX);
                Sexo = SX;
                TipoAtencion TA;
                Enum.TryParse(ma.TIPO_ATENCION, out TA);
                TipoAte = TA;
                FechaNaci = DateTime.MaxValue;
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
                Datos.MASCOTA mas = Conexion.Ani.MASCOTA.First(m=> m.IDMASCOTA == Id);
                mas.IDMASCOTA = Id;
                mas.NOMBRE = Nombre;
                mas.EDAD = Edadm;
                mas.RAZA = Raza.ToString();
                mas.ESTERILIZADO = Esterilizado.ToString();
                mas.SEXO = Sexo.ToString();
                mas.FECHA_NACIMIENTO = FechaNaci;
                mas.TIPO_ATENCION = TipoAte.ToString();
                mas.FECHA_NACIMIENTO = FechaNaci;
                Conexion.Ani.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete ()
        {
            try
            {
                Datos.MASCOTA mas = (from masco in Conexion.Ani.MASCOTA
                                     where masco.NOMBRE == Nombre
                                     select masco).First();
                Conexion.Ani.MASCOTA.Remove(mas);
                Conexion.Ani.SaveChanges();
                return true;
                
            }
            catch
            {
                return false;
            }

        }
         #endregion


    }
}

