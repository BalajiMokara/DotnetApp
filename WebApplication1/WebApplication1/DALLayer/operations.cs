using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Windows.Forms;
using WebApplication1.Models;

namespace WebApplication1.DALLayer
{
    public class operations
    {

        public Boolean checkaccountidexists(viewaccountbyid v) {
            
           // string s1 = "server=AYUSHASTHANA;database=mydb;trusted_connection=true";
            string s1 = "DATA SOURCE=intvmsql01; INITIAL CATALOG=DB03TMS165_1617; USER ID=PJ03TMS165_1617;PASSWORD=tcstvm";
 
            SqlConnection cos = new SqlConnection(s1);
            cos.Open();
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.StoredProcedure;
            if(Convert.ToString(v.account).Equals("savings"))
            com.CommandText = "checkaccountidexistsinsavings";
            else
                com.CommandText = "checkaccountidexistsincurrent";
            com.Connection = cos;
            com.Parameters.AddWithValue("@accountid", v.cid);
            

            SqlDataReader s = com.ExecuteReader();
            if (s.Read())
                return true;
            else
                return false;

        }

        public bool chckwithdrawsavings(withdraw d)
        {
            //string s1 = "server=AYUSHASTHANA;database=mydb;trusted_connection=true";
           string s1 = "DATA SOURCE=intvmsql01; INITIAL CATALOG=DB03TMS165_1617; USER ID=PJ03TMS165_1617;PASSWORD=tcstvm";
            SqlConnection cos = new SqlConnection(s1);
            cos.Open();
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "chckwithdrawsavings";
            com.Connection = cos;
            com.Parameters.AddWithValue("@accountid", d.accountid);
            SqlDataReader s = com.ExecuteReader();
            if (s.Read())
                return true;
            else
                return false;
        }
        public bool chckwithdrawcurrent(withdraw d)
        {
            //string s1 = "server=LAPTOP-LJI1LU5A\\LOCALHOST;database=mydb;trusted_connection=true";
           // string s1 = "server=AYUSHASTHANA;database=mydb;trusted_connection=true";
            string s1 = "DATA SOURCE=intvmsql01; INITIAL CATALOG=DB03TMS165_1617; USER ID=PJ03TMS165_1617;PASSWORD=tcstvm";
            SqlConnection cos = new SqlConnection(s1);
            cos.Open();
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "chckwithdrawcurrent";
            com.Connection = cos;
            com.Parameters.AddWithValue("@accountid", d.accountid);
            SqlDataReader s = com.ExecuteReader();
            if (s.Read())
                return true;
            else
                return false;
        }

        public SqlDataReader retriveaccountdetails(int acid, string actyp)
        {
           // string s1 = "server=AYUSHASTHANA;database=mydb;trusted_connection=true";
            string s1 = "DATA SOURCE=intvmsql01; INITIAL CATALOG=DB03TMS165_1617; USER ID=PJ03TMS165_1617;PASSWORD=tcstvm";
            SqlConnection cos = new SqlConnection(s1);
            cos.Open();
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.StoredProcedure;
            if (actyp == "savings")
                com.CommandText = "retrivedatafromsavings";
            else
                com.CommandText = "retrivedatafromcurrent";
            com.Connection = cos;
            com.Parameters.AddWithValue("@accountid", acid);
            SqlDataReader s = com.ExecuteReader();
            if (s.Read())
                Console.Write("contains data");
            else
                Console.Write("cheak sql");
            return s;
        }

        public bool chcksufficientbalance(withdraw2 d)
        {
           // string s1 = "server=LAPTOP-LJI1LU5A\\LOCALHOST;database=mydb;trusted_connection=true";
           string s1 = "DATA SOURCE=intvmsql01; INITIAL CATALOG=DB03TMS165_1617; USER ID=PJ03TMS165_1617;PASSWORD=tcstvm";
           // string s1 = "server=AYUSHASTHANA;database=mydb;trusted_connection=true";
            SqlConnection cos = new SqlConnection(s1);
            cos.Open();
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.StoredProcedure;
            if (d.account == "savings")
                com.CommandText = "chcksufficientbalancesavings";
            else
                com.CommandText = "chcksufficientbalancecurrent";
            com.Connection = cos;
            com.Parameters.AddWithValue("@accountid", d.accid);
            SqlDataReader s = com.ExecuteReader();
            if (s.Read())
               Console.Write(Convert.ToString(s["balance"]));
            else
                Console.Write("empty");

            if ((Convert.ToInt32(s["balance"]) - d.wd) >= 0)
                return true;
            //MessageBox.Show("contains data");
            else
                // MessageBox.Show("cheak sql");
                return false;
        }

        public int withdraw(withdraw2 d)
        {
            int newbal = d.bal - d.wd;
            //string s1 = "server=LAPTOP-LJI1LU5A\\LOCALHOST;database=mydb;trusted_connection=true";
            string s1 = "DATA SOURCE=intvmsql01; INITIAL CATALOG=DB03TMS165_1617; USER ID=PJ03TMS165_1617;PASSWORD=tcstvm";
           // string s1 = "server=AYUSHASTHANA;database=mydb;trusted_connection=true";
            SqlConnection cos = new SqlConnection(s1);
            cos.Open();
            SqlTransaction transaction;
            // con.Open();
            transaction = cos.BeginTransaction(IsolationLevel.ReadCommitted);
            SqlCommand cmd = new SqlCommand();
            cmd.Transaction = transaction;
            //cmd.CommandType = CommandType.StoredProcedure;
            //if (d.actype == "savings")
            //    cmd.CommandText = "updatesavingstbl";
            //else
            //    cmd.CommandText = "updatecurrenttbl";
            DateTime now = DateTime.Now;

            cmd.Connection = cos;
            //cmd.Parameters.AddWithValue("@id", d.accid);
            //cmd.Parameters.AddWithValue("@bal", new_balance);
            //cmd.Parameters.AddWithValue("@ltd",now);

            //int r = cmd.ExecuteNonQuery();
            //return new_balance;

            try
            {
                if (d.account == "savings")
                    cmd.CommandText =
                    "update savingsaccount1216632 set balance=@nb  where savingsaccountid=@id";
                else
                    cmd.CommandText =
                    "update currentaccount1216632 set balance=@nb  where currentaccountid=@id";

                cmd.Parameters.Add("@nb", SqlDbType.Int);
                cmd.Parameters["@nb"].Value = newbal;



                cmd.Parameters.Add("@id", SqlDbType.BigInt);
                cmd.Parameters["@id"].Value = d.accid;



                cmd.ExecuteNonQuery();

                cmd.CommandText =
                    "Insert into transaction1216632 VALUES (@aid,@cid,@type,@amount,@tdate)";

                cmd.Parameters.Add("@aid", SqlDbType.Int);
                cmd.Parameters["@aid"].Value = d.accid;

                cmd.Parameters.Add("@cid", SqlDbType.Int);
                cmd.Parameters["@cid"].Value = d.cusid;
                cmd.Parameters.Add("@type", SqlDbType.VarChar);
                cmd.Parameters["@type"].Value = "withdraw";

                cmd.Parameters.Add("@amount", SqlDbType.BigInt);
                cmd.Parameters["@amount"].Value = d.wd;

                cmd.Parameters.Add("@tdate", SqlDbType.DateTime);
                cmd.Parameters["@tdate"].Value = now;

                cmd.ExecuteNonQuery();
                transaction.Commit();
               // MessageBox.Show("Both records are written to database.");
                return newbal;
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
                        MessageBox.Show("An exception of type " + ex.Message +
                             " was encountered while attempting to roll back the transaction.");
                    }
                }

                MessageBox.Show("An exception of type " + e.Message +
                    " was encountered while inserting the data.");
                MessageBox.Show("Neither record was written to database.");
            }

            return -1;

            //SqlCommand com = new SqlCommand();
            //com.CommandType = CommandType.StoredProcedure;
            //com.Connection = cos;
            //if (d.account == "savings")
            //    com.CommandText = "withdrawsavings";
            //else
            //    com.CommandText = "withdrawcurrent";

            //com.Parameters.AddWithValue("@accountid", d.accid);
            //com.Parameters.AddWithValue("@amount", newbal);
            //com.ExecuteNonQuery();


            //return newbal;
            /*if (dr.Read())
                return true;
            else
                return false;*/


        }

        public SqlDataReader retrieveaccountdetails(viewaccountbyid v) {
           // string s1 = "server=AYUSHASTHANA;database=mydb;trusted_connection=true";
            string s1 = "DATA SOURCE=intvmsql01; INITIAL CATALOG=DB03TMS165_1617; USER ID=PJ03TMS165_1617;PASSWORD=tcstvm";
            SqlConnection cos = new SqlConnection(s1);
            cos.Open();
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.StoredProcedure;
            if (Convert.ToString(v.account) == "savings")
                com.CommandText = "retrieveaccdetailsfromsavings";
            else
                com.CommandText = "retrieveaccdetailsfromcurrent";

        com.Connection=cos;

            com.Parameters.AddWithValue("@id",v.cid);
            SqlDataReader sd=com.ExecuteReader();
            if (sd.Read())
            {
                Console.Write("dat isthere");

            } return sd;
        
        
        }

        public bool chcksavingsaccountwithactive(transfer d)
        {
          // string s1 = "server=AYUSHASTHANA;database=mydb;trusted_connection=true";
            string s1 = "DATA SOURCE=intvmsql01; INITIAL CATALOG=DB03TMS165_1617; USER ID=PJ03TMS165_1617;PASSWORD=tcstvm";
            SqlConnection cos = new SqlConnection(s1);
            SqlConnection cos1 = new SqlConnection(s1);
            cos.Open();
            cos1.Open();
            SqlCommand com = new SqlCommand();
            SqlCommand com1 = new SqlCommand();
            com.CommandType = CommandType.StoredProcedure;
            com1.CommandType = CommandType.StoredProcedure;
            if ((Convert.ToString(d.account) == "savings") && (Convert.ToString(d.account1) == "current"))
            {
                com.CommandText = "checksavingsaccount";
                com.Connection = cos;
                com.Parameters.AddWithValue("@accountid", d.sourceaccount);
                com1.CommandText = "checkcurrentaccount1";
                com1.Connection = cos1;
                com1.Parameters.AddWithValue("@accountid", d.targetaccount);
                SqlDataReader a = com.ExecuteReader();
                SqlDataReader b = com1.ExecuteReader();
                if ((a.Read()) && (b.Read()))
                    return true;
                else
                    return false;
            }
            else if ((Convert.ToString(d.account) == "current") && (Convert.ToString(d.account1) == "savings"))
            {
                com.CommandText = "checkcurrentaccount1";
                com.Connection = cos;
                com.Parameters.AddWithValue("@accountid", d.sourceaccount);
                com1.CommandText = "checksavingsaccount";
                com1.Connection = cos1;
                com1.Parameters.AddWithValue("@accountid", d.targetaccount);
                SqlDataReader a = com.ExecuteReader();
                SqlDataReader b = com1.ExecuteReader();
                if ((a.Read()) && (b.Read()))
                    return true;
                else
                    return false;
            }
            /*else if ((Convert.ToString(d.account) == "savings") && (Convert.ToString(d.account1) == "savings"))
            {
                com.CommandText = "checksavingsaccount";
                com.Connection = cos;
                com.Parameters.AddWithValue("@accountid", d.sourceaccount);
                com1.CommandText = "checksavingsaccount";
                com1.Connection = cos1;
                com1.Parameters.AddWithValue("@accountid", d.targetaccount);
                SqlDataReader a = com.ExecuteReader();
                SqlDataReader b = com1.ExecuteReader();
                if ((a.Read()) && (b.Read()))
                    return true;
                else
                    return false;
            }
            else if ((Convert.ToString(d.account) == "current") && (Convert.ToString(d.account1) == "current"))
            {
                com.CommandText = "checkcurrentaccount";
                com.Connection = cos;
                com.Parameters.AddWithValue("@accountid", d.sourceaccount);
                com1.CommandText = "checkcurrentaccount";
                com1.Connection = cos1;
                com1.Parameters.AddWithValue("@accountid", d.targetaccount);
                SqlDataReader a = com.ExecuteReader();
                SqlDataReader b = com1.ExecuteReader();
                if ((a.Read()) && (b.Read()))
                    return true;
                else
                    return false;
            }*/
            return false;
        }

        public bool chcksourceaccountbalance(transfer d)
        {
           // string s1 = "server=AYUSHASTHANA;database=mydb;trusted_connection=true";
            string s1 = "DATA SOURCE=intvmsql01; INITIAL CATALOG=DB03TMS165_1617; USER ID=PJ03TMS165_1617;PASSWORD=tcstvm";
            SqlConnection cos = new SqlConnection(s1);
            cos.Open();
            SqlCommand com = new SqlCommand();
            //SqlCommand com1 = new SqlCommand();
            com.CommandType = CommandType.StoredProcedure;
            //com1.CommandType = CommandType.StoredProcedure;
            if (Convert.ToString(d.account) == "savings")
            {
                com.CommandText = "checksourcebalsavings";
                com.Connection = cos;
                com.Parameters.AddWithValue("@accountid", d.sourceaccount);
            }
            else
            {
                com.CommandText = "checksourcebalcurrent";
                com.Connection = cos;
                //com.Connection = cos;
                com.Parameters.AddWithValue("@accountid", d.sourceaccount);
            }
            SqlDataReader s = com.ExecuteReader();
            s.Read();
            if ((Convert.ToInt32(s["balance"]) - d.tframt) > 0)
                return true;
            else
                return false;

            //return true;
        }
        public void transfer(transfer d)
        {
           // string s1 = "server=AYUSHASTHANA;database=mydb;trusted_connection=true";
            string s1 = "DATA SOURCE=intvmsql01; INITIAL CATALOG=DB03TMS165_1617; USER ID=PJ03TMS165_1617;PASSWORD=tcstvm";
            SqlConnection cos = new SqlConnection(s1);
            SqlConnection cos1 = new SqlConnection(s1);
            cos.Open();
            cos1.Open();
            SqlCommand com = new SqlCommand();
            SqlCommand com1 = new SqlCommand();
            com.CommandType = CommandType.StoredProcedure;
            com1.CommandType = CommandType.StoredProcedure;
            if (Convert.ToString(d.account) == "savings")
            {
                com1.CommandText = "withdrawfromsavings";
                com1.Connection = cos1;
                com1.Parameters.AddWithValue("@accountid", d.sourceaccount);
                com1.Parameters.AddWithValue("@amount", d.tframt);
            }
            else
            {
                com1.CommandText = "withdrawfromcurrent123";
                com1.Connection = cos1;
                com1.Parameters.AddWithValue("@accountid", d.sourceaccount);
                com1.Parameters.AddWithValue("@amount", d.tframt);
            }
            if (Convert.ToString(d.account1) == "savings")
            {
                //com1.CommandText="withdrawfromcurrent"
                com.CommandText = "transfertosavings";
                com.Connection = cos;
                com.Parameters.AddWithValue("@accountid", d.targetaccount);
                com.Parameters.AddWithValue("@amount", d.tframt);
            }
            else
            {
                com.CommandText = "transfertocurrent";
                com.Connection = cos;
                com.Parameters.AddWithValue("@accountid", d.targetaccount);
                com.Parameters.AddWithValue("@amount", d.tframt);
            }
            SqlDataReader s = com.ExecuteReader();
            SqlDataReader a = com1.ExecuteReader();
            /*if (s.Read())
                return true;
            else
                return false;
            return true;*/
        }

    }
}