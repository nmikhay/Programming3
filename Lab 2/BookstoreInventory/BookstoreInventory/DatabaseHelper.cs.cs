using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreInventory
{
    internal class DatabaseHelper
    {
        public static SQLiteConnection GetConnection()
        {
            string connectionString = "Data Source=your_database_file_path;Version=3;";
            return new SQLiteConnection(connectionString);
        }
    }
}
