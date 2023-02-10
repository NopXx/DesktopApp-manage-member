using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Compet2
{
    public class db
    {
        public static string strconn = "host=localhost;user=root;password=;database=db_library;";
        public static MySqlConnection conn = new MySqlConnection(strconn);
    }
    public class member_info
    {
        public static string username;
    }
}
