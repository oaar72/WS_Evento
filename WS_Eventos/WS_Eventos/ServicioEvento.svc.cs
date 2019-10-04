using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Services;
using WS_Eventos.Network;

namespace WS_Eventos
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : ServicioEvento
    {
        [WebMethod]
        public string ping()
        {
            return "Servicio Activo";
        }

        public void registrarEvento(float valor1, float valor2, float valor3, string escala)
        {
            Connection conn = new Connection();
            string conexion = conn.getConnectionString();

            SqlConnection con = new SqlConnection(conexion);

            con.Open();

            SqlCommand cmd = new SqlCommand("addEvento", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@magnitud", valor1));
            cmd.Parameters.Add(new SqlParameter("@latitud",  valor2));
            cmd.Parameters.Add(new SqlParameter("@longitud", valor3));
            cmd.Parameters.Add(new SqlParameter("@escala", valor3));

            cmd.ExecuteNonQuery();

            con.Dispose();
            con.Close();
            con = null;
        }
    }
}
