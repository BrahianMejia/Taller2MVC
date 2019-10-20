using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Modelo;

namespace Controlador
{
    public class CLSEmpleadoMgr
    {
        CLSDatos cnGeneral = null;
        CLSEmpleado objContacto = null;
        DataTable tblDatos = null;

        #region constructor
        public CLSEmpleadoMgr (CLSEmpleado parObjContacto)
        {
            objContacto = parObjContacto;
        }
        #endregion

        public DataTable Listar()
        {
            tblDatos = new DataTable();

            try
            {
                cnGeneral = new CLSDatos();
                SqlParameter[] parParameter = new SqlParameter[1];
                parParameter[0] = new SqlParameter();
                parParameter[0].ParameterName = "@opc";
                parParameter[0].SqlDbType = SqlDbType.Int;
                parParameter[0].SqlValue = objContacto.opc;

                tblDatos = cnGeneral.RetornaTabla(parParameter, "SPEmpleado");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return tblDatos;
        }

        public void GuardarDatos()
        {
            try
            {
                cnGeneral = new CLSDatos();
                SqlParameter[] parParameter = new SqlParameter[6];
                parParameter[0] = new SqlParameter();
                parParameter[0].ParameterName = "@opc";
                parParameter[0].SqlDbType = SqlDbType.Int;
                parParameter[0].SqlValue = objContacto.opc;

                parParameter[1] = new SqlParameter();
                parParameter[1].ParameterName = "@Cedula";
                parParameter[1].SqlDbType = SqlDbType.Int;
                parParameter[1].SqlValue = objContacto.Cedula;

                parParameter[2] = new SqlParameter();
                parParameter[2].ParameterName = "@Nombre";
                parParameter[2].SqlDbType = SqlDbType.VarChar;
                parParameter[2].Size = 50;
                parParameter[2].SqlValue = objContacto.Nombre;

                parParameter[3] = new SqlParameter();
                parParameter[3].ParameterName = "@Apellido";
                parParameter[3].SqlDbType = SqlDbType.VarChar;
                parParameter[3].Size = 50;
                parParameter[3].SqlValue = objContacto.Apellido;

                parParameter[4] = new SqlParameter();
                parParameter[4].ParameterName = "@FNacimiento";
                parParameter[4].SqlDbType = SqlDbType.DateTime;
                parParameter[4].SqlValue = objContacto.FNacimiendo;

                parParameter[5] = new SqlParameter();
                parParameter[5].ParameterName = "@Cargo";
                parParameter[5].SqlDbType = SqlDbType.Int;
                parParameter[5].SqlValue = objContacto.Cargo;

                cnGeneral.EjecutarSP(parParameter, "SPEmpleado");

            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }


       public void EliminarDatos()
        {
            try
            {
                cnGeneral = new CLSDatos();
                SqlParameter[] parParameter = new SqlParameter[2];

                parParameter[0] = new SqlParameter();
                parParameter[0].ParameterName = "@opc";
                parParameter[0].SqlDbType = SqlDbType.Int;
                parParameter[0].SqlValue = objContacto.opc;

                parParameter[1] = new SqlParameter();
                parParameter[1].ParameterName = "@Cedula";
                parParameter[1].SqlDbType = SqlDbType.VarChar;
                parParameter[1].Size = 50;
                parParameter[1].SqlValue = objContacto.Cedula;

                cnGeneral.EjecutarSP(parParameter, "SPEmpleado");

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
