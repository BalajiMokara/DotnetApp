using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Windows.Forms;
using System.Web.Mvc;
using WebApplication1.Models;


namespace WebApplication1.DALLayer
{
    public class dbmd
    {


       
        public DataSet getmini(ministatement m) {

            DataSet g = new DataSet();

             string s = "DATA SOURCE=intvmsql01;" + "INITIAL CATALOG=DB03TMS165_1617;" + "USER ID=PJ03TMS165_1617;" + "PASSWORD=tcstvm";
          // string s = "server=AYUSHASTHANA;database=mydb;trusted_connection=true";
            SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
           // cmd.CommandText = "sp_getministatement";


            if (Convert.ToString(m.select)=="CustomerId")
                cmd.CommandText = "sp_getministatementbycustid";
            else
                cmd.CommandText = "sp_getministatementbyaccountid";
            cmd.Parameters.AddWithValue("@id",m.id);
            cmd.Parameters.AddWithValue("@sdate", m.startdate);
            cmd.Parameters.AddWithValue("@edate", m.enddate);
            cmd.Connection = con;
            

            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            ad.Fill(g);
            return g;



        }
        public Boolean accountidexistsinbothtbl(long id) {

            string s = "DATA SOURCE=intvmsql01;" + "INITIAL CATALOG=DB03TMS165_1617;" + "USER ID=PJ03TMS165_1617;" + "PASSWORD=tcstvm";
           //string s = "server=AYUSHASTHANA;database=mydb;trusted_connection=true";
            SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_chkidexistinbothtbl";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Connection = con;
            SqlDataReader sd = cmd.ExecuteReader();
            if (sd.Read())
                return true;
            else
                return false;



        }

        public DataSet viewAllCustomer()
        {

        //    MessageBox.Show("hfhfhj");

            DataSet g = new DataSet();

            string s = "DATA SOURCE=intvmsql01;" + "INITIAL CATALOG=DB03TMS165_1617;" + "USER ID=PJ03TMS165_1617;" + "PASSWORD=tcstvm";
          //  string s = "server=AYUSHASTHANA;database=mydb;trusted_connection=true";
            SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_viewallcust";
            cmd.Connection = con;

            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            ad.Fill(g);
            return g;




        }

        public Boolean chkaccidexists(long id, string atype) {


              string s = "DATA SOURCE=intvmsql01;" + "INITIAL CATALOG=DB03TMS165_1617;" + "USER ID=PJ03TMS165_1617;" + "PASSWORD=tcstvm";
           //string s = "server=AYUSHASTHANA;database=mydb;trusted_connection=true";
            SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            if (atype.Equals("savings"))
                cmd.CommandText = "sp_chkinsavingstbl";
            else
                cmd.CommandText = "sp_chkincurrenttbl";

            cmd.Parameters.AddWithValue("@id",id);

            SqlDataReader sd = cmd.ExecuteReader();
            if (sd.Read())
                return true;
            else
                return false;
        
        
        }

        public Boolean chkidexists(long id) {

           string s = "DATA SOURCE=intvmsql01;" + "INITIAL CATALOG=DB03TMS165_1617;" + "USER ID=PJ03TMS165_1617;" + "PASSWORD=tcstvm";
           // string s = "server=AYUSHASTHANA;database=mydb;trusted_connection=true";
            SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "chkidexists";
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@cid",id);

            SqlDataReader sd = cmd.ExecuteReader();
            if (sd.Read())
                return true;
            else
                return false;


        }

        public DataSet retrievecustdetails(int id) {

            DataSet d = new DataSet();
           // string s = "server=AYUSHASTHANA;database=mydb;trusted_connection=true";
            string s = "DATA SOURCE=intvmsql01;" + "INITIAL CATALOG=DB03TMS165_1617;" + "USER ID=PJ03TMS165_1617;" + "PASSWORD=tcstvm";
            SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_custbyid";
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@cid", id);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            sd.Fill(d);
            return d;
        }


   public SqlDataReader retrieveaccountdetails(long id,string atype)
        {
            //MessageBox.Show("in dbmd");
            string s = "DATA SOURCE=intvmsql01;" + "INITIAL CATALOG=DB03TMS165_1617;" + "USER ID=PJ03TMS165_1617;" + "PASSWORD=tcstvm";
            //string s = "server=AYUSHASTHANA;database=mydb;trusted_connection=true";
            SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            if(atype.Equals("savings")) 
            cmd.CommandText = "sp_retrievesavingsaccountdetails";
            else
                cmd.CommandText = "sp_retrievecurrentaccountdetails";
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@id", id);
         SqlDataReader d = cmd.ExecuteReader();
         if (d.Read()) { 
              Console.Write("d is not null");
         }
            return d;

        }


        public long depositmoney(Deposit d) {

            long new_balance = d.balance+d.amount;

            SqlTransaction transaction;

            // Start a local transaction.

            string s = "DATA SOURCE=intvmsql01;" + "INITIAL CATALOG=DB03TMS165_1617;" + "USER ID=PJ03TMS165_1617;" + "PASSWORD=tcstvm";

          //string s = "server=AYUSHASTHANA;database=mydb;trusted_connection=true";
            SqlConnection con = new SqlConnection(s);


            con.Open();
            transaction = con.BeginTransaction(IsolationLevel.ReadCommitted);
            SqlCommand cmd = new SqlCommand();
            cmd.Transaction = transaction;
            //cmd.CommandType = CommandType.StoredProcedure;
            //if (d.actype == "savings")
            //    cmd.CommandText = "updatesavingstbl";
            //else
            //    cmd.CommandText = "updatecurrenttbl";
            DateTime now = DateTime.Now;

            cmd.Connection = con;
            //cmd.Parameters.AddWithValue("@id", d.accid);
            //cmd.Parameters.AddWithValue("@bal", new_balance);
            //cmd.Parameters.AddWithValue("@ltd",now);

            //int r = cmd.ExecuteNonQuery();
            //return new_balance;

            try
            {
                if (d.actype == "savings")
                    cmd.CommandText =
                    "update savingsaccount1216632 set balance=@nb , lasttransactiondetails=@ltd where savingsaccountid=@id";
                else
                    cmd.CommandText =
                    "update currentaccount1216632 set balance=@nb , lasttransactiondetails=@ltd where currentaccountid=@id";

                cmd.Parameters.Add("@nb", SqlDbType.Int);
                cmd.Parameters["@nb"].Value = new_balance;

                cmd.Parameters.Add("@ltd", SqlDbType.DateTime);
                cmd.Parameters["@ltd"].Value = now;

                cmd.Parameters.Add("@id", SqlDbType.BigInt);
                cmd.Parameters["@id"].Value = d.accid;



                cmd.ExecuteNonQuery();

                cmd.CommandText =
                    "Insert into transaction1216632 VALUES (@aid,@cid,@type,@amount,@tdate)";

                cmd.Parameters.Add("@aid", SqlDbType.BigInt);
                cmd.Parameters["@aid"].Value = d.accid;

                cmd.Parameters.Add("@cid", SqlDbType.Int);
                cmd.Parameters["@cid"].Value = d.custid;
                cmd.Parameters.Add("@type", SqlDbType.VarChar);
                cmd.Parameters["@type"].Value = "deposit";

                cmd.Parameters.Add("@amount", SqlDbType.BigInt);
                cmd.Parameters["@amount"].Value = d.amount;

                cmd.Parameters.Add("@tdate", SqlDbType.DateTime);
                cmd.Parameters["@tdate"].Value = now;

                cmd.ExecuteNonQuery();
                transaction.Commit();
                //MessageBox.Show("Both records are written to database.");
                return new_balance;
            }
            catch (Exception e)
            {
                try
                {
                    transaction.Rollback();
                }
                catch (SqlException ex)
                {
                    if (transaction.Connection != null)
                    {
                       MessageBox.Show("An exception of type " +ex.Message+
                            " was encountered while attempting to roll back the transaction.");
                    }
                }

                MessageBox.Show("An exception of type " + e.Message +
                    " was encountered while inserting the data.");
               MessageBox.Show("Neither record was written to database.");
            }

            return -1;
        }
    }
}