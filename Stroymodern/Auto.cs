using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Stroymodern
{
    public class Auto
    {
        string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=159632;Database=Stroymodern";
        public bool Check_user(string login, string password)
        {
            string login_test = null;
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT login FROM users where login = @login AND password = @password";
                using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@login", login);
                    command.Parameters.AddWithValue("@password", password);
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            login_test = reader.GetString(0);
                        }
                    }
                }
            }
            if (login == login_test)
            {
                return true;
            }
            return false;
        }
        public bool Capch(string test)
        {
            string capch = null;
            Random random = new Random();
            const string chars = "abcdefghijklmnopqrstuvwxyz";
            for (int i = 0; i < 5; i++)
            {
                capch = capch + Convert.ToString(chars[random.Next(chars.Length)]);
            }
            for (int i = 0; i < 5; i++)
            {
                capch = capch + Convert.ToString(random.Next(10));
            }
            if (test == "0")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool Check_password(string login_true, string password)
        {
            string login = null;
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT login FROM users where password = @password";
                using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@password", password);
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            login = reader.GetString(0);
                        }
                    }
                }
            }
            if (login_true == login)
            {
                return true;
            }
            return false;
        }
    }
}
