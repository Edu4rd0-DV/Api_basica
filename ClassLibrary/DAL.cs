using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class DAL
    {
       public List<EN> mostrar_datos()
        {
            IDbConnection _con = Conexion.cnBD();
            _con.Open();
            SqlCommand _comando = new SqlCommand("listar", _con as SqlConnection);
            _comando.CommandType = CommandType.StoredProcedure;
            IDataReader _lector = _comando.ExecuteReader();
            List<EN> list = new List<EN>(); 
            while (_lector.Read()) { 
             EN _datos = new EN();
                _datos.nombre = _lector.GetString(1);
                _datos.apellido = _lector.GetString(2);
                _datos.direccion = _lector.GetString(3); 
                _datos.sexo = _lector.GetString(4);
                list.Add(_datos);
            
            
            }
            _con.Close();
            return list;

              
        }

        public  int agregar_datos (EN _d)
        {
            IDbConnection _con = Conexion.cnBD();
            _con.Open();
            SqlCommand _comando = new SqlCommand("guardar", _con as SqlConnection);
            _comando.CommandType = CommandType.StoredProcedure;
            _comando.Parameters.Add(new SqlParameter("@nombre",_d.nombre));
            _comando.Parameters.Add(new SqlParameter(@"apellido",_d.apellido));
            _comando.Parameters.Add(new SqlParameter(@"direccion", _d.direccion));
            _comando.Parameters.Add(new SqlParameter(@"sexo", _d.sexo));
            int resultado = _comando.ExecuteNonQuery();
            _con.Close();
            return resultado;

        }



        public int eliminar_datos( int _d)
        {
           IDbConnection con = Conexion.cnBD();
            con.Open();
            SqlCommand  comando = new SqlCommand("eliminar",con as SqlConnection);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("@id", _d));
            int resultado = comando.ExecuteNonQuery();
            con.Close();
            return resultado;

        }



        public int actualizar_datos(EN _d) {

            IDbConnection conn = Conexion.cnBD();
            conn.Open();
            SqlCommand comando = new SqlCommand("actualizar" , conn as SqlConnection);
            comando .CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("@id", _d.id));
            comando.Parameters.Add(new SqlParameter("@nombre", _d.nombre));
            comando.Parameters.Add(new SqlParameter(@"apellido", _d.apellido));
            comando.Parameters.Add(new SqlParameter(@"direccion", _d.direccion));
            comando.Parameters.Add(new SqlParameter(@"sexo", _d.sexo));
            int resultado = comando.ExecuteNonQuery();
            conn.Close();

            return resultado;
        
        }

    }
}
