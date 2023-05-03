using System.Data;
using System.Data.SqlClient;

namespace ADO.NET_Components
{
    class AdoNet
    {
        public const string connectionString = @"Data Source=localhost\SQLEXPRESS01;Initial Catalog=test;Integrated Security=True";
        public static void GetData()
        {

            string query = "SELECT * FROM Tbl_2";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"id : {reader.GetInt32(0)} name:  {reader.GetString(1)} " +
                    $" standard {reader.GetString(2)} section {reader.GetString(3)}");
            }

        }
        // Insert record
        public static void InsertRecord()
        {
            SqlConnection connection = null;
            try
            {
                // Creating Connection  
                connection = new SqlConnection(connectionString);
                // writing sql query  
                SqlCommand cm = new SqlCommand("insert into Tbl_2 (id, name, standard, section) values ('101', 'Amjad hussain', 'BSDS-A', 'AL' )", connection);

                // Opening Connection  
                connection.Open();
                // Executing the SQL query  
                cm.ExecuteNonQuery();
                // Displaying a message  
                Console.WriteLine("Record Inserted Successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong." + e);
            }
            // Closing the connection  
            finally
            {
                connection.Close();
            }
        }
        // Update record 
        public static void UpdateRecord(int id, string name)
        {
            SqlConnection connection = null;
            try
            {
                // Creating Connection  
                connection = new SqlConnection(connectionString);

                // writing sql query  
                SqlCommand cm = new SqlCommand("UPDATE Tbl_2 SET name =@name WHERE id = @id", connection);
                cm.Parameters.AddWithValue("@id", id);
                cm.Parameters.AddWithValue("@name", name);
                // Opening Connection  
                connection.Open();
                // Executing the SQL query  
                cm.ExecuteNonQuery();
                // Displaying a message  
                Console.WriteLine("Record Updated Successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong." + e);
            }
            // Closing the connection  
            finally
            {
                connection.Close();
            }
        }

        // Delete Record 
        public static void DeleteData(int id)
        {
            SqlConnection connection = null;
            try
            {

                connection = new SqlConnection(connectionString);

                SqlCommand cm = new SqlCommand($"delete from Tbl_2 where id = {id}", connection);

                connection.Open();

                cm.ExecuteNonQuery();
                Console.WriteLine("Record Deleted Successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong." + e);
            }
            // Closing the connection  
            finally
            {
                connection.Close();
            }
        }
        public static void SqlAdapter()
        {


            try
            {

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_2", connection);
                    //Using Data Table
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    //The following things are done by the Fill method
                    //1. Open the connection
                    //2. Execute Command
                    //3. Retrieve the Result
                    //4. Fill/Store the Retrieve Result in the Data table
                    //5. Close the connection
                    Console.WriteLine("Using Data Table");
                    //Active and Open connection is not required
                    //dt.Rows: Gets the collection of rows that belong to this table
                    //DataRow: Represents a row of data in a DataTable.
                    foreach (DataRow row in dt.Rows)
                    {
                        //Accessing using string Key Name
                        Console.WriteLine(row["name"] + ",  " + row["standard"] + ",  " + row["section"]);
                        //Accessing using integer index position
                        //Console.WriteLine(row[0] + ",  " + row[1] + ",  " + row[2]);
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong.\n" + e);
            }

        }
        public static void DataSET()
        {
            try
            {

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_2", connection);

                    //Using DataSet
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Tbl_2"); //Here, the datatable student will be stored in Index position 0
                    Console.WriteLine("Using Data Set");
                    //Tables: Gets the collection of tables contained in the System.Data.DataSet.
                    //Accessing the datatable from the dataset using the datatable name
                    foreach (DataRow row in ds.Tables["Tbl_2"].Rows)
                    {
                        //Accessing the data using string Key Name
                        Console.WriteLine(row["name"] + ",  " + row["standard"] + ",  " + row["section"]);
                        //Accessing the data using integer index position
                        //Console.WriteLine(row[0] + ",  " + row[1] + ",  " + row[2]);
                    }
                    //Accessing the datatable from the dataset using the datatable index position
                    //foreach (DataRow row in ds.Tables[0].Rows)
                    //{
                    //    Console.WriteLine(row["Name"] + ",  " + row["Email"] + ",  " + row["Mobile"]);
                    //}
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong.\n" + e);
            }
        }

    }
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Wellcome To ADO .Net Framework ");
            // AdoNet.GetData();
            // AdoNet.InsertRecord();
            // AdoNet.DeleteData(3);
            // AdoNet.UpdateRecord(6, "Aslam");
            //AdoNet.DataSET();
            // AdoNet.SqlAdapter();


        }
    }
}