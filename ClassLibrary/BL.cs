using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClassLibrary
{
    public class BL
    { 
        DAL _dal = new DAL();

        //mostrar usuarios 
        public List<EN> mostrar_datos()
        {
            return _dal.mostrar_datos();
        
        }


        public int agregar_datos(EN _en)
        {
            return _dal.agregar_datos(_en);

        }

        public int eliminar_datos(int _en)
        {
            return _dal.eliminar_datos(_en);

        }

        public int actualizar_datos(EN eN)
        {
            return _dal.actualizar_datos(eN);   
        }

    }
}
