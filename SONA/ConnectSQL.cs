using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SONA
{
    public class ConnectSQL
    {
        private readonly string connectString = @"Data Source=(local);Initial Catalog=MUSIC_APP;Integrated Security=True";
        private SqlConnection connect;
        private SqlCommand command;
        private SqlDataAdapter adapter;

        public ConnectSQL()
        {
            connect = new SqlConnection(connectString);
        }

        private void Open()
        {
            if (connect.State == ConnectionState.Closed)
            {
                connect.Open();
            }
        }

        private void Close()
        {
            if (connect.State == ConnectionState.Open)
            {
                connect.Close();
            }
        }
        public DataTable Get(string table)
        {
            DataTable dtb = new DataTable();
            try
            {
                Open();
                command = new SqlCommand($"SELECT * FROM {table}", connect);
                adapter = new SqlDataAdapter(command);
                adapter.Fill(dtb);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving songs: " + ex.Message);
            }
            finally
            {
                Close();
            }
            return dtb;
        }

        public DataTable Query(string query)
        {
            DataTable dtb = new DataTable();
            try
            {
                Open();
                command = new SqlCommand(query, connect);
                adapter = new SqlDataAdapter(command);
                adapter.Fill(dtb);
            }
            catch (Exception ex)
            {
                throw new Exception("Error executing query: " + ex.Message);
            }
            finally
            {
                Close();
            }
            return dtb;
        }

        public void ExecuteQuery(string query)
        {
            try
            {
                Open();
                command = new SqlCommand(query, connect);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error executing non-query: " + ex.Message);
            }
            finally
            {
                Close();
            }
        }
    }
}
