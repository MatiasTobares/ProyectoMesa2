using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using AdminEmpleados.BLL;
namespace AdminEmpleados.DAL
{
    class DepartamentosDAL
    {
        conexionDAL conexion;
        public DepartamentosDAL()  //constructor metodo con el mismo nombre q la clase
        {
            conexion = new conexionDAL(); // instanciamos
        }
        public bool Agregar(DepartamentoBLL oDepartamentosBLL)
        {
            SqlCommand SQLComando = new SqlCommand("INSERT INTO Departamentos VALUES(@Departamentos)");

            SQLComando.Parameters.Add("@Departamentos", SqlDbType.VarChar).Value=oDepartamentosBLL.Departamento;
            return conexion.ejecutarComandoSinRetornoDatos(SQLComando);
          // return conexion.ejecutarComandoSinRetornoDatos("INSERT INTO Departamentos (departamento)VALUES('"+oDepartamentosBLL.Departamento+"')");
           
        }
        public bool Eliminar(DepartamentoBLL oDepartamentosBLL)
        {
            SqlCommand SQLComando = new SqlCommand("DELETE FROM Departamentos WHERE ID=@ID");

            SQLComando.Parameters.Add("@ID", SqlDbType.Int).Value = oDepartamentosBLL.ID;
            return conexion.ejecutarComandoSinRetornoDatos(SQLComando);

        }
        public DataSet mostrarDepartamentos()
        {
            SqlCommand sentencia = new SqlCommand("SELECT * FROM Departamentos");
            return conexion.ejecutarSentencia(sentencia);
        }
        public bool Modificar(DepartamentoBLL oDepartamentosBLL)
        {
            SqlCommand SQLComando = new SqlCommand("UPDATE Departamentos SET departamento=@Departamento WHERE ID=@ID");

            SQLComando.Parameters.Add("@Departamento", SqlDbType.VarChar).Value = oDepartamentosBLL.Departamento;
            SQLComando.Parameters.Add("@ID", SqlDbType.Int).Value = oDepartamentosBLL.ID;
            return conexion.ejecutarComandoSinRetornoDatos(SQLComando);
        }
    }
}
