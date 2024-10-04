
using System.Data.SqlClient;

namespace Utils
{
    public class Util
    {
        public static SqlConnection getconnection()
        {
            return new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=DemoDb;Integrated Security=True;Pooling=False;") ;
        }
    }
}
