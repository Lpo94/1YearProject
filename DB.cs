using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;


namespace _1YearProject
{
    class DB
    {
        public void db()
        {
            {
                SQLiteConnection.CreateFile("1YearProject.db");
                SQLiteConnection dbConn = new
                SQLiteConnection("Data Source=1YearProject.db;Version=3;");
                String connStr = "Data Source=ny.db;Version=3";
                SQLiteConnection conn = new SQLiteConnection(connStr);
                dbConn.Open();
                String sql = "create table highscores (name varchar(20), score int)";
                SQLiteCommand command = new SQLiteCommand(sql, dbConn);
                command.ExecuteNonQuery();
            }
        }
    }
}
