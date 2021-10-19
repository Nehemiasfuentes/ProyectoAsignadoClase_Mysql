using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace ProyectoAsignadoClase_Mysql
{
    class Connection
    {
        private MySqlConnection conn =
            new MySqlConnection("Server=localhost;Database=medicos;Uid=root;Pwd=usbw; SSL MODE= None");

        public MySqlCommand command;

        //Habilitar conexcion a la BD
        public MySqlConnection openConnection()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            return conn;
        }

        //Desabilitar conexcion a la BD
        public MySqlConnection closeConnection()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            return conn;
        }
    }
}
