using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WS_Eventos
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface ServicioEvento
    {
        [OperationContract]
        string ping();

        [OperationContract]
        void registrarEvento(float valor1, float valor2, float valor3, string escala);
    }
}
