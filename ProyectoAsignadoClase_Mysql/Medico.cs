using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ProyectoAsignadoClase_Mysql
{
    class Medico
    {
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string especialidad { get; set; }
        public string telefono { get; set; }
        public string direccionClinica { get; set; }


        private CRUD crud = new CRUD();


        public MySqlDataReader RegistrosMedicos()
        {
            string query = "SELECT nombreMedico, apellidoMedico, especialidadMedico, telefonoMedico, direccionMedico FROM medico";


            return crud.select(query);
        }

        public bool RegistrarEditarRegistrosMedicos(string action)
        {
            if (action == "new")
            {
                string query = "INSERT INTO medico(nombreMedico, apellidoMedico, especialidadMedico,telefonoMedico, direccionMedico)" +
                    "VALUES ('" + nombre + "', '" + apellido + "','" + especialidad + "','" + telefono + "','" + direccionClinica + "')";

                crud.executeQuery(query);
                return true;
            }
            else if (action == "edit")
            {

                string query = "UPDATE medico SET "
                    + "nombreMedico='" + nombre + "',"
                    + "apellidoMedico='" + apellido + "',"
                    + "especialidadMedico='" + especialidad + "',"
                    + "telefonoMedico='" + telefono + "',"
                    + "direccionMedico='" + direccionClinica + "'"
                    + "WHERE "
                    + "nombreMedico='" + nombre + "'";

                crud.executeQuery(query);
                return true;
            }
            return false;
        }


        public Boolean EliminarMedico()
        {
            string query = "DELETE FROM medico WHERE nombreMedico='" + nombre + "'";
            crud.executeQuery(query);
            return true;
        }
    }
}
