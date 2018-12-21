using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM_DB_Layer
{
    public class amsql
    {
        public static string getcon()
        {
            return "Data Source=KPCL9243\\KPCLSQL;Initial Catalog=AM;Integrated Security=True";
        }
    }
}
