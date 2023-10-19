using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Rom_Hacks_Completitionist
{
    /*
     * in this class I create the connection between application and mysql database
     */
    internal class DBconnect
    {
        //to create the connection
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;uid=root;psw=;database=stardb");

        //to get connection
        public MySqlConnection GetConnection
        {
            get
            {
                return connection;
            }
        }
        //create a method to open connection
        public void openConnect()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }
        //to close the connection
        public void closeConnect()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
}
