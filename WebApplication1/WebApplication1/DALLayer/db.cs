using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.DALLayer
{
    public class db
    {

        public DataSet ViewCustomerbyID(int ID, int ch)
        {
            DataSet ds = null;
            string connectionstring = "data source=intvmsql01;" + "database=DB03TMS165_1617;" + "User id=PJ03TMS165_1617;" + "Password=tcstvm";
            SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id", ID);
            command.Parameters.AddWithValue("@ch", ch);
            command.CommandText = "updatenew_";//SQL StoredProcedure Name to perform View Operation
            command.Connection = connection;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = command;
            ds = new DataSet(); da.Fill(ds);
            return ds;

        }




        public int UpdateCustomer(Cusupd obj, int ch, int nb)
        {
            string connectionstring = "data source=intvmsql01;" + "database=DB03TMS165_1617;" + "User id=PJ03TMS165_1617;" + "Password=tcstvm";
            SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "cus_update139";//SQL StoredProcedure Name to perform Update Operation
            command.Connection = connection;
            command.Parameters.AddWithValue("@cusID", nb);//@p_id is the parameter which pass in the SQL StoredProcedure
            command.Parameters.AddWithValue("@ch", ch);//@p_name is the parameter which pass in the SQL StoredProcedure
            command.Parameters.AddWithValue("@cusname", obj.cusname);
            command.Parameters.AddWithValue("@age", obj.age);
            command.Parameters.AddWithValue("@address1", obj.address1);
            command.Parameters.AddWithValue("@address2", obj.address2);
            command.Parameters.AddWithValue("@city", obj.city);
            command.Parameters.AddWithValue("@state1", obj.state1);


            int Rowaffected = command.ExecuteNonQuery();
            connection.Close();

            return (Rowaffected);


        }


        //public string InsertData(Cusdate MD)
        //{

        //    string result = "";
        //    try
        //    {
        //        string s1 = "DATA SOURCE=intvmsql01; INITIAL CATALOG=DB01TMS166_1617; USER ID=PJ01TMS166_1617;PASSWORD=tcstvm";
        //        SqlConnection cos = new SqlConnection(s1);
        //        cos.Open();
        //        SqlCommand com = new SqlCommand();
        //        com.CommandType = CommandType.StoredProcedure;
        //        com.CommandText = "cus_create13";
        //        com.Connection = cos;
        //        com.Parameters.AddWithValue("@cusSSNID", MD.cusSSNID);

        //        com.Parameters.AddWithValue("@cusname", MD.cusname);
        //        com.Parameters.AddWithValue("@age", MD.age);
        //        com.Parameters.AddWithValue("@address1", MD.address1);
        //        com.Parameters.AddWithValue("@address2", MD.address2);
        //        com.Parameters.AddWithValue("@city", MD.city);
        //        com.Parameters.AddWithValue("@state1", MD.state1);
        //        com.Parameters.AddWithValue("@cusID", 0);
        //        result = com.ExecuteNonQuery().ToString();
        //        cos.Close();
        //        return result;
        //    }
        //    catch
        //    {
        //        return result = "";
        //    }

        //}


        public bool checkssnid(GetByID a)
        {
            string connectionstring = "data source=intvmsql01;" + "database=DB03TMS165_1617;" + "User id=PJ03TMS165_1617;" + "Password=tcstvm";
            SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "checkssnid";//SQL StoredProcedure Name to perform Update Operation
            command.Connection = connection;
            command.Parameters.AddWithValue("@ssnid", a.id1);
            SqlDataReader dr = command.ExecuteReader();
            if (dr.Read())
            {
                return true;
            }
            else
            { return false; }
        }

        public bool checkcusid(GetByID a)
        {
            string connectionstring = "data source=intvmsql01;" + "database=DB03TMS165_1617;" + "User id=PJ03TMS165_1617;" + "Password=tcstvm";
            SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "checkcusid";//SQL StoredProcedure Name to perform Update Operation
            command.Connection = connection;
            command.Parameters.AddWithValue("@cusid", a.id1);
            SqlDataReader dr = command.ExecuteReader();
            if (dr.Read())
            {
                return true;
            }
            else
            { return false; }
        }




        public int deleteaccount(DeleteAccount1 c)
        {
            //string s1 = "SERVER=LAPTOP-LJI1LU5A\\LOCALHOST ;" + "DATABASE=mydb;" + "TRUSTED_CONNECTION=TRUE";
            string s1 = "DATA SOURCE=intvmsql01;" + "INITIAL CATALOG=DB03TMS165_1617;" + "USER ID=PJ03TMS165_1617;" + "PASSWORD=tcstvm";
            SqlConnection con = new SqlConnection(s1);

            con.Open();
            SqlCommand cmd1 = new SqlCommand();
            SqlCommand cmd2 = new SqlCommand();

            cmd1.CommandType = CommandType.StoredProcedure;
            cmd2.CommandType = CommandType.StoredProcedure;

            cmd1.CommandText = "deletesavingsaccount";
            cmd2.CommandText = "deletecurrentaccount";
            cmd1.Connection = con;
            cmd2.Connection = con;
            cmd1.Parameters.AddWithValue("@cid", c.custid);
            cmd2.Parameters.AddWithValue("@cid", c.custid);
            int r = cmd1.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();
            return r;
        }



        public bool check7(deletecus MB)
        {
            //string s1 = "server=LAPTOP-LJI1LU5A\\LOCALHOST;database=mydb;trusted_connection=true";
            string s1 = "DATA SOURCE=intvmsql01; INITIAL CATALOG=DB03TMS165_1617; USER ID=PJ03TMS165_1617;PASSWORD=tcstvm";
            SqlConnection cos = new SqlConnection(s1);
            cos.Open();
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "cheakcusid1";
            com.Connection = cos;
            com.Parameters.AddWithValue("@cusid", MB.cusID);
            SqlDataReader s = com.ExecuteReader();
            if (s.Read())
                return true;
            else
                return false;

            // return true;
        }

        public bool chckaccountswithactive(deletecus MB)
        {
            //string s1 = "server=LAPTOP-LJI1LU5A\\LOCALHOST;database=mydb;trusted_connection=true";
            string s1 = "DATA SOURCE=intvmsql01; INITIAL CATALOG=DB03TMS165_1617; USER ID=PJ03TMS165_1617;PASSWORD=tcstvm";
            SqlConnection cos = new SqlConnection(s1);
            cos.Open();
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "chckaccounts";
            com.Connection = cos;
            com.Parameters.AddWithValue("@cusid", Convert.ToInt32(MB.cusID));
            SqlDataReader s = com.ExecuteReader();
            if (s.Read())
            {

                /* SqlCommand com1 = new SqlCommand();
                 com1.CommandType = CommandType.StoredProcedure;
                 com1.CommandText = "chckbalance";
                 com1.Connection = cos;
                 com1.Parameters.AddWithValue("@cusid", Convert.ToInt32(MB.cusID));
                 SqlDataReader d = com1.ExecuteReader();
                 if (d.Read())*/
                return true;

            }
            else
                return false;


        }
        public int deleinaccounts(deletecus MB)
        {
            //string s1 = "server=LAPTOP-LJI1LU5A\\LOCALHOST;database=mydb;trusted_connection=true";
            string s1 = "DATA SOURCE=intvmsql01; INITIAL CATALOG=DB03TMS165_1617; USER ID=PJ03TMS165_1617;PASSWORD=tcstvm";
            SqlConnection cos = new SqlConnection(s1);
            SqlConnection cos1 = new SqlConnection(s1);
            cos.Open();
            cos1.Open();
            SqlCommand com = new SqlCommand();
            SqlCommand com1 = new SqlCommand();
            com.CommandType = CommandType.StoredProcedure;
            com1.CommandType = CommandType.StoredProcedure;
            com.CommandText = "cusidinsavings";
            com1.CommandText = "cusidincurrent";
            com.Connection = cos;
            com1.Connection = cos;
            com.Parameters.AddWithValue("@cusid", MB.cusID);
            com1.Parameters.AddWithValue("@cusid", MB.cusID);
            /* SqlDataReader s = com.ExecuteReader();
             if (s.Read())
                 return true;
             else
                 return false;

             // return true;*/
            int r = com.ExecuteNonQuery();
            int s = com1.ExecuteNonQuery();

            return 1;


        }

        public string delcustomer(deletecus MD)
        {

            string result = "";
            try
            {
                string s1 = "DATA SOURCE=intvmsql01; INITIAL CATALOG=DB03TMS165_1617; USER ID=PJ03TMS165_1617;PASSWORD=tcstvm";
                SqlConnection cos = new SqlConnection(s1);
                cos.Open();
                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "del_cus1";
                com.Connection = cos;

                com.Parameters.AddWithValue("@cusID", MD.cusID);


                result = com.ExecuteNonQuery().ToString();
                cos.Close();
                return result;
            }
            catch
            {
                return result = "";
            }
        }

       

    }
}