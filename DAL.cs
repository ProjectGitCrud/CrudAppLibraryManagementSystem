using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CrudAppLibraryManagementSystem.Models
{
    //DAL Data access layer here we write sql logic to fetch data
    public class DAL
    {
        public ReaderResponse GetAllReaders(SqlConnection connection)
        {
            ReaderResponse response = new ReaderResponse();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Reader", connection);
            DataTable dt = new DataTable();
            List<Reader> lstReaders = new List<Reader>(); 
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                { 
                Reader reader = new Reader();
                reader.ReaderId = Convert.ToInt32(dt.Rows[i]["ReaderId"]);
                reader.ReaderName = Convert.ToString(dt.Rows[i]["ReaderName"]);
                reader.ReaderAddress = Convert.ToString(dt.Rows[i]["ReaderAddress"]);
                reader.ReaderContactNumber = Convert.ToString(dt.Rows[i]["ReaderContactNumber"]);

                lstReaders.Add(reader);
                }
            }

            if (lstReaders.Count > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Data Found";
                response.ListReaders = lstReaders;
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Data Found";
                response.ListReaders = null;
            }

            return response;
        }

        public ReaderResponse GetReadersById(SqlConnection connection, int id)
        {
            ReaderResponse response = new ReaderResponse();

            SqlDataAdapter da = new SqlDataAdapter("Select * from Reader Where ReaderID ='"+id+"'", connection);
            DataTable dt = new DataTable();
            //Reader Reader = new Reader();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                
                    Reader reader = new Reader();
                    reader.ReaderId = Convert.ToInt32(dt.Rows[0]["ReaderId"]);
                    reader.ReaderName = Convert.ToString(dt.Rows[0]["ReaderName"]);
                    reader.ReaderAddress = Convert.ToString(dt.Rows[0]["ReaderAddress"]);
                    reader.ReaderContactNumber = Convert.ToString(dt.Rows[0]["ReaderContactNumber"]);
                    response.StatusCode = 200;
                    response.StatusMessage = "Data Found";
                    response.Reader = reader;
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Data Found";
                response.Reader = null;
            }
            return response;
        }

        public ReaderResponse AddReader(SqlConnection connection, Reader reader)
        {
            ReaderResponse response = new ReaderResponse();

            SqlCommand cmd = new SqlCommand("INSERT INTO Reader(ReaderID, ReaderName, ReaderAddress, ReaderContactNumber) VALUES ('"+ reader.ReaderId+ "','" + reader.ReaderName+ "','" + reader.ReaderAddress+ "','" + reader.ReaderContactNumber + "')", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            { 
                response.StatusCode = 200;
                response.StatusMessage = "Reader Added";
                response.Reader = reader;
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Data Inserted";
            }
            return response;
        }

        public ReaderResponse UpdateReader(SqlConnection connection, Reader reader)
        {
            ReaderResponse response = new ReaderResponse();
            SqlCommand cmd = new SqlCommand("UPDATE Reader SET ReaderName = '" + reader.ReaderName + "', ReaderAddress = '" + reader.ReaderAddress + "', ReaderContactNumber = '" + reader.ReaderContactNumber + "' WHERE ReaderID ='"+reader.ReaderId+"'", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Reader Updated";
                response.Reader = reader;
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Reader Updated";
            }
            return response;
        }

        public ReaderResponse DeleteReader(SqlConnection connection, int id)
        {
            ReaderResponse response = new ReaderResponse();
            SqlCommand cmd = new SqlCommand("DELETE FROM Reader WHERE ReaderID ='" + id + "'", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Reader Deleted";
               // response.Reader = reader;
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Reader Deleted";
            }
            return response;
        }
    }
}
