using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ProyectoAsignadoClase_Mysql
{
    class CRUD
    {

        private Connection connect = new Connection();

        public MySqlDataReader select(string query)
        {
            MySqlDataReader dataReader;


            connect.command = new MySqlCommand(query, connect.openConnection());
            dataReader = connect.command.ExecuteReader();
            return dataReader;
        }
        public void executeQuery(string query)
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            connect.command = new MySqlCommand(query, connect.openConnection());
            adapter.InsertCommand = connect.command;
            adapter.InsertCommand.ExecuteNonQuery();
            connect.command.Dispose();
            connect.closeConnection();
        }
    }
}
