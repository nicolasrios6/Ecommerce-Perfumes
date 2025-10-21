using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace EcommercePerfumes.Datos
{
	public class AccesoDatos
	{
		private SqlConnection conexion;
		public SqlCommand comando;
		private SqlDataReader lector;

		public SqlDataReader Lector { get { return lector; } }

		public AccesoDatos()
		{
			conexion = new SqlConnection(ConfigurationManager.AppSettings["cadenaConexion"]);
			comando = new SqlCommand();
		}

		public void setConsulta(string consulta)
		{
			comando.CommandType = System.Data.CommandType.Text;
			comando.CommandText = consulta;
		}

		public void setProcedimiento(string procedimiento)
		{
			comando.CommandType = System.Data.CommandType.StoredProcedure;
			comando.CommandText = procedimiento;
		}

		public void ejecutarLectura()
		{
			comando.Connection = conexion;
			try
			{
				conexion.Open();
				lector = comando.ExecuteReader();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public void ejecutarAccion()
		{
			comando.Connection = conexion;
			try
			{
				conexion.Open();
				comando.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public void setParametro(string nombre, object valor)
		{
			comando.Parameters.AddWithValue(nombre, valor);
		}

		public void cerrarConexion()
		{
			if (lector != null)
				lector.Close();
			conexion.Close();
		}
	}
}
