using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Animal.Datos;

namespace Animal.Negocios
{
    internal class Conexion
    {
        private static CONSULTAEntities1 _ani;

        public static CONSULTAEntities1 Ani
        {
            get
            {
                if (_ani == null)
                    _ani = new CONSULTAEntities1();
                return _ani;

            }
            set { _ani = value; }
        }
        
    }
}
