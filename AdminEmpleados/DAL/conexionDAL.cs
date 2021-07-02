using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AdminEmpleados.DAL
{
    class conexionDAL
    {
        private string cadenaConexion = "Data Source=DESKTOP-N97ME57\\; Initial Catalog=dbSistema; Integrated Security= True;";
        SqlConnection Conexion;
        public SqlConnection establecerConexion()
        {
           this.Conexion = new SqlConnection(this.cadenaConexion);
            return this.Conexion;
        }
        /* Metodo INSERT, DELETE, UPDATE*/
        public bool ejecutarComandoSinRetornoDatos(string strComando) {
            try {
               
                SqlCommand Comando = new SqlCommand();
                Comando.CommandText = strComando;
                Comando.Connection = this.establecerConexion();
                Conexion.Open();               //abro conexión           //SI HACEMOS TODO ESTO
                Comando.ExecuteNonQuery();
                Conexion.Close();
                return true;                           //SE RETORNA el booleano
            }catch{
                return false;      //si se conecta y tira error 
            }
          }
        //sobrecarga
        public bool ejecutarComandoSinRetornoDatos(SqlCommand SQLComando)
        {
            try
            {

                SqlCommand Comando = SQLComando;
                
                Comando.Connection = this.establecerConexion();
                Conexion.Open();               //abro conexión           //SI HACEMOS TODO ESTO
                Comando.ExecuteNonQuery();
                Conexion.Close();
                return true;                           //SE RETORNA el booleano
            }
            catch
            {
                return false;      //si se conecta y tira error 
            }
        }
        /*SELECT (retorno datos)*/
        public DataSet ejecutarSentencia(SqlCommand sqlComando)
        {
            DataSet DS = new DataSet();
            SqlDataAdapter Adaptador = new SqlDataAdapter();
            try
            {
                SqlCommand Comando = new SqlCommand();
                Comando = sqlComando;
                Comando.Connection = establecerConexion();
                Adaptador.SelectCommand = Comando;
                Conexion.Open();
                Adaptador.Fill(DS);
                Conexion.Close();
                return DS;

            }
            catch {
                return DS;
                }
            }

        
    }
}
