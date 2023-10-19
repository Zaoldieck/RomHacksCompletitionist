using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Rom_Hacks_Completitionist
{
    internal class Star
    {
        DBconnect connect = new DBconnect();

        public bool insertStar(string starName, string courseName, string romHack, string type, DateTime obtainedDate, string obtained = "NO", string listed = "NO", string note = "", double rating = 0.0, byte[] img = null)
        {

            MySqlCommand command = new MySqlCommand("INSERT INTO `star`(`Star Name`, `Course Name`, `Rom Hack`, `Type`, `Obtained`, `Date`, `Listed`, `Rating`, `Note`, `Picture`) VALUES (@sn,@cn,@rh,@t,@o,@d,@l,@r,@n,@img)",connect.GetConnection);

            // @sn,@cn,@rh,@t,@o,@d,@l,@r,@n,@img

            command.Parameters.Add("@sn", MySqlDbType.VarChar).Value = starName;
            command.Parameters.Add("@cn", MySqlDbType.VarChar).Value = courseName;
            command.Parameters.Add("@rh", MySqlDbType.VarChar).Value = romHack;
            command.Parameters.Add("@t", MySqlDbType.VarChar).Value = type;
            command.Parameters.Add("@d", MySqlDbType.Date).Value = obtainedDate;
            command.Parameters.Add("@o", MySqlDbType.VarChar).Value = obtained;
            command.Parameters.Add("@l", MySqlDbType.VarChar).Value = listed;
            command.Parameters.Add("@r", MySqlDbType.Double).Value = rating;
            command.Parameters.Add("@n", MySqlDbType.Text).Value = note;
            command.Parameters.Add("@img", MySqlDbType.LongBlob).Value = img;

            connect.openConnect();
            if(command.ExecuteNonQuery()==1)
            {
                connect.closeConnect();
                return true;
            }
            else
            {
                connect.closeConnect();
                return false;
            }
        }
        // to get student table
        public DataTable getStarList()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `star`", connect.GetConnection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
    }
}
