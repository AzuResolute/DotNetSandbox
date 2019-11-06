using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Linq;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace Refresher
{
    class ADOPractice
    {
        public static void ADOReadTable(string input)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["databaseCS"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = $"SELECT * FROM {input}";
                cmd.Connection = con;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"" +
                            $"{reader.GetInt32(0)}\t" +
                            $"{reader.GetString(1)}\t" +
                            $"{reader.GetString(2)}");
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
            }
        }
        public static void ADOTableSize(string input)
        {
            string PK = $"{input.Substring(0, input.Length - 1)}ID";
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["databaseCS"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand($"SELECT COUNT({PK}) FROM {input}", con);
                con.Open();
                int totalRows = (int)cmd.ExecuteScalar();
                Console.WriteLine($"{PK} - {totalRows}");
            }
        }
        public static void ADOCategoryInsert(string newcat, string newdesc)
        {
            int totalRows = 0;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["databaseCS"].ConnectionString))
            {
                string findAllquery = $"SELECT * FROM Categories";
                SqlCommand findAllCmd = new SqlCommand(findAllquery, con);
                SqlCommand countCmd = new SqlCommand($"SELECT COUNT(CategoryID) FROM Categories", con);
                con.Open();
                totalRows = (int)countCmd.ExecuteScalar();
                string insertQuery = $"INSERT into Categories (CategoryName, Description) VALUES (@CategoryName, @Description)";
                SqlCommand insertCmd = new SqlCommand(insertQuery, con);
                insertCmd.Parameters.AddWithValue("@CategoryName", newcat);
                insertCmd.Parameters.AddWithValue("@Description", newdesc);
                int affectewdRows = insertCmd.ExecuteNonQuery();
                SqlDataReader reader = findAllCmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(
                            $"{reader["CategoryID"]}\t" +
                            $"{reader["CategoryName"]}\t" +
                            $"{reader["Description"]}");
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
            }
        }
        public static void ADOUpdate(int id, string newcat, string newdesc)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["databaseCS"].ConnectionString))
            {
                SqlCommand updateCmd = new SqlCommand($"Update Categories set CategoryName = @CategoryName, Description = @Description WHERE CategoryID = @CategoryID", con);
                updateCmd.Parameters.AddWithValue("@CategoryID", id);
                updateCmd.Parameters.AddWithValue("@CategoryName", newcat);
                updateCmd.Parameters.AddWithValue("@Description", newdesc);
                SqlCommand findAllCmd = new SqlCommand("Select * from Categories", con);
                con.Open();
                int affectedRows = updateCmd.ExecuteNonQuery();
                SqlDataReader reader = findAllCmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(
                            $"{reader.GetInt32(0)}\t" +
                            $"{reader.GetString(1)}");
                    }
                }

            }
        }
        public static void ADOReadTableViaAdapter(string input)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["databaseCS"].ConnectionString))
            {
                //SqlDataAdapter da = new SqlDataAdapter($"Select * from {input}", con);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand($"Select * from {input}", con);

                DataSet ds = new DataSet();
                // An in-memory representation of your database
                // Can store tables and relationships between tables
                // Present in the memory in the web server

                // For stored procedure
                //da.SelectCommand.CommandType = CommandType.StoredProcedure;
                //da.SelectCommand.Parameters.AddWithValue("@parametername","qeqeqeqe");

                da.Fill(ds);
                // Will take care of opening, filling data, and closing connections

                var reader = ds.CreateDataReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(
                            $"{reader["CategoryID"]}\t" +
                            $"{reader["CategoryName"]}\t" +
                            $"{reader["Description"]}");
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
            }
        }
        public static void ADOViewCategoriesAndProducts()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["databaseCS"].ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand($"Select * from Categories; Select * from Products", con);

            DataSet ds = new DataSet();
            da.Fill(ds);
            ds.Tables[0].TableName = "Categories";
            ds.Tables[1].TableName = "Products";

            for (int i = 0; i < ds.Tables.Count; i++)
            {
                var reader = ds.Tables[i].CreateDataReader();

                if (reader.HasRows)
                {
                    Console.WriteLine($"*** {ds.Tables[i].TableName} ***");
                    while (reader.Read())
                    {
                        Console.WriteLine(
                            $"{reader[0]}\t" +
                            $"{reader[1]}\t" +
                            $"{reader[2]}");
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
            }
        }
        public static void ADOReadFromExcel()
        {
            using (OleDbConnection con = new OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0; Data Source=C:\\Users\\roger\\Documents\\LaunchDay2019.xlsx; Extended Properties= Excel 8.0"))
            {
                OleDbDataAdapter da = new OleDbDataAdapter("Select * from [sheet2$]", con);
                DataSet ds = new DataSet();
                da.Fill(ds);

                for (int i = 0; i < ds.Tables.Count; i++)
                {
                    DataTableReader reader = ds.Tables[i].CreateDataReader();

                    if (reader.HasRows)
                    {
                        Console.WriteLine($"*** {ds.Tables[i].TableName} ***");
                        Console.WriteLine(
                            $"{ds.Tables[i].Columns[0]}\t" +
                            $"{ds.Tables[i].Columns[1]}\t" +
                            $"{ds.Tables[i].Columns[6]}\t" +
                            $"{ds.Tables[i].Columns[7]}"
                            );
                        while (reader.Read())
                        {
                            Console.WriteLine(
                                $"{reader[0]}\t" +
                                $"{reader[1]}\t" +
                                $"{reader[6]}\t" +
                                $"{reader[7]}");
                        }
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("No rows found.");
                    }
                }
                // Life is good
            }
        }
    }
}
