using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Application.DLL
{
    public class BaseRepository
    {
        public SqlConnection Conn;
        public SqlTransaction trans;

        public static string dbstring
        {
            get
            {
                if (Environment.GetEnvironmentVariable("dbstring") != null)
                {
                    return Environment.GetEnvironmentVariable("dbstring");
                }
                else
                {
                    return Util.AppSetting.Get("dbstring");
                }
            }
        }

        /// <summary>
        /// Connections
        /// </summary>
        public void connection()
        {
            Conn = new SqlConnection(dbstring);
        }
    }
}
