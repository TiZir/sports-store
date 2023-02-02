using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace Tutorial.SqlConn
{
    class DBUtils
    {
        public static SqlConnection GetDBConnection()
        {
            string datasource = @"DESKTOP-8OAHTJ6\SQLEXPRESS";

            string database = "TikhonovTR";

            return DBSQLServerUtils.GetDBConnection(datasource, database);
        }
    }

}