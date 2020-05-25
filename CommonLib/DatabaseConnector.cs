using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib
{
    public class DatabaseConnector
    {
         
        //Use default values from installer at a later date 
        //Currently uses hard coded defaults
        public DatabaseConnector()
        {
        }

        public void InsertNewItem(Item newItem)
        {
            using (IDbConnection con = new SQLiteConnection(LoadConnectionString()))
            {
                con.Open();
                if (!string.IsNullOrEmpty(newItem.Name))
                {
                    using (var command = con.CreateCommand())
                    {
                        command.CommandTimeout = 0;
                        command.CommandText = "INSERT into item (name,price,description,taxable,islelocation) values (@Name, @Price, @Description, @Taxable, @IsleLocation)";
                        command.Parameters.Add(new SQLiteParameter("@Name", newItem.Name));
                        command.Parameters.Add(new SQLiteParameter("@Price", newItem.Price));
                        command.Parameters.Add(new SQLiteParameter("@Description", newItem.Description));
                        command.Parameters.Add(new SQLiteParameter("@Taxable", newItem.Taxable));
                        command.Parameters.Add(new SQLiteParameter("@IsleLocation", newItem.IsleLocation));

                        command.ExecuteNonQuery();
                    }
                }
            }

            /*
             * MySqlConnection con = ConnectToDB();
             * try
             * {
             * con.Open();
             * //Switched to Parameterized query + 05/16/2020 11:30 AM
             * string sqlString = "INSERT INTO item(name,price,quanitytype) VALUES(@name,@price,@perPriceMod)";
             * MySqlCommand command = new MySqlCommand(sqlString, con);
             * command.Parameters.AddWithValue("@name", newItem.Name);
             * command.Parameters.AddWithValue("@price", newItem.Price);
             * command.Parameters.AddWithValue("@perPriceMod", newItem.perPriceMod.ToString());
             * command.ExecuteNonQuery();
             * Console.WriteLine(newItem.ToString() + " has been inserted into database!");
             * }
             * catch (Exception ex)
             * {
             * Console.WriteLine(ex.Message);
             * return;
             * }
             */
        }

        public List<Item> GetAllItems()
        {
            using (IDbConnection con = new SQLiteConnection(LoadConnectionString()))
            {
                IEnumerable<Item> output = con.Query<Item>("SELECT * from item", new DynamicParameters());
                return output.ToList();

            }
        }

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

        

    }
}
