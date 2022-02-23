using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using System.Windows.Forms;
namespace WebApplication1.DALLayer
{
    public class dalayer
    {

        public int deletecurrent(deleteaccount d)
        {
            string s1 = "DATA SOURCE=intvmsql01; INITIAL CATALOG=DB03TMS165_1617; USER ID=PJ03TMS165_1617;PASSWORD=tcstvm";
            SqlConnection cos = new SqlConnection(s1);
            cos.Open();
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "sp_deletecurrent";
            com.Connection = cos;
            com.Parameters.AddWithValue("@accountid", d.accountid);
            //com.Parameters.AddWithValue("@amount", d.amount);
            int r = com.ExecuteNonQuery();
            return (r);

        }

        public bool chcksavingsbal(deleteaccount d)
        {
            string s1 = "DATA SOURCE=intvmsql01; INITIAL CATALOG=DB03TMS165_1617; USER ID=PJ03TMS165_1617;PASSWORD=tcstvm";
            SqlConnection cos = new SqlConnection(s1);
            cos.Open();
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "cheaksavingsbal";
            com.Connection = cos;
            com.Parameters.AddWithValue("@accountid", d.accountid);
            SqlDataReader s = com.ExecuteReader();
            if (s.Read())
            {
                if (Convert.ToInt32(s["balance"]) > 0)
                    return false;
                else
                    return true;
            }
            else
                return false;
        }
        


        public bool chckdelesavings(deleteaccount d)
        {
            string s1 = "DATA SOURCE=intvmsql01; INITIAL CATALOG=DB03TMS165_1617; USER ID=PJ03TMS165_1617;PASSWORD=tcstvm";
            SqlConnection cos = new SqlConnection(s1);
            cos.Open();
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "cheakaccountid12";
            com.Connection = cos;
            com.Parameters.AddWithValue("@accountid", d.accountid);
            SqlDataReader s = com.ExecuteReader();
            if (s.Read())
                return true;
            else
                return false;
        }
        public bool chcksavingacctstatus(deleteaccount d)
        {
            string s1 = "DATA SOURCE=intvmsql01; INITIAL CATALOG=DB03TMS165_1617; USER ID=PJ03TMS165_1617;PASSWORD=tcstvm";
            SqlConnection cos = new SqlConnection(s1);
            cos.Open();
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "cheaksavingaccstatus";
            com.Connection = cos;
            com.Parameters.AddWithValue("@accountid", d.accountid);
            SqlDataReader s = com.ExecuteReader();
            if (s.Read())
            {
                if (Convert.ToString(s["astatus"]) == "Inactive")
                    return false;
                else
                    return true;
            }
            else
                return false;
        }

        public bool chckcurrentaccountstatus(deleteaccount d)
        {
            string s1 = "DATA SOURCE=intvmsql01; INITIAL CATALOG=DB03TMS165_1617; USER ID=PJ03TMS165_1617;PASSWORD=tcstvm";
            SqlConnection cos = new SqlConnection(s1);
            cos.Open();
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "cheakcurrentaccstatus";
            com.Connection = cos;
            com.Parameters.AddWithValue("@accountid", d.accountid);
            SqlDataReader s = com.ExecuteReader();
            if (s.Read())
            {
                if (Convert.ToString(s["astatus"]) == "Inactive")
                    return false;
                else
                    return true;
            }
            else
                return false;
        }


        public int deletesavings(deleteaccount d)
        {
            string s1 = "DATA SOURCE=intvmsql01; INITIAL CATALOG=DB03TMS165_1617; USER ID=PJ03TMS165_1617;PASSWORD=tcstvm";
            SqlConnection cos = new SqlConnection(s1);
            cos.Open();
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "sp_deletesavings";
            com.Connection = cos;
            com.Parameters.AddWithValue("@accountid", d.accountid);
            //com.Parameters.AddWithValue("@amount", d.amount);
            int r = com.ExecuteNonQuery();
            return (r);

        }

        public bool chckcurrentbal(deleteaccount d)
        {
            string s1 = "DATA SOURCE=intvmsql01; INITIAL CATALOG=DB03TMS165_1617; USER ID=PJ03TMS165_1617;PASSWORD=tcstvm";
            SqlConnection cos = new SqlConnection(s1);
            cos.Open();
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "cheakcurrentbal";
            com.Connection = cos;
            com.Parameters.AddWithValue("@accountid", d.accountid);
            SqlDataReader s = com.ExecuteReader();
            if (s.Read())
            {
                if (Convert.ToInt32(s["balance"]) > 0)
                    return false;
                else
                    return true;
            }
            else
                return false;
        }

        public bool chckdeletcurrent(deleteaccount d)
        {
            string s1 = "DATA SOURCE=intvmsql01; INITIAL CATALOG=DB03TMS165_1617; USER ID=PJ03TMS165_1617;PASSWORD=tcstvm";
            SqlConnection cos = new SqlConnection(s1);
            cos.Open();
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "cheakaccountid123";
            com.Connection = cos;
            com.Parameters.AddWithValue("@accountid", d.accountid);
            SqlDataReader s = com.ExecuteReader();
            if (s.Read())
                return true;
            else
                return false;
        }


        public int customerinsert(customercreate c)
        {
            string s = "DATA SOURCE=intvmsql01;"+"INITIAL CATALOG=DB03TMS165_1617;"+"USER ID=PJ03TMS165_1617;"+"PASSWORD=tcstvm";
          //  string s = "server=AYUSHASTHANA;database=mydb;trusted_connection=true";
            SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_customerinsert";
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@ssnid", c.ssnid);
            cmd.Parameters.AddWithValue("@cname", c.cname);
            cmd.Parameters.AddWithValue("@cage", c.cage);
            cmd.Parameters.AddWithValue("@caline1", c.caline1);
            cmd.Parameters.AddWithValue("@caline2", c.caline2);
            cmd.Parameters.AddWithValue("@city", c.city);
            cmd.Parameters.AddWithValue("@cstate", c.cstate);
            int res = cmd.ExecuteNonQuery();
            return res;
        }

        //public int customerupdate(UpdateCustomer c)
        //{

        //     string s = "DATA SOURCE=intvmsql01;" + "INITIAL CATALOG=DB03TMS165_1617;" + "USER ID=PJ03TMS165_1617;" + "PASSWORD=tcstvm";
        //    // string s = "server=AYUSHASTHANA;database=mydb;trusted_connection=true";
        //        SqlConnection con = new SqlConnection(s);
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.CommandType = CommandType.StoredProcedure;

        //    string type = Convert.ToString(c.select);
        //    if(type.Equals("ssnid"))
        //    cmd.CommandText = "sp_customerupdate1";
        //    else
        //        cmd.CommandText = "sp_customerupdate2";
        //    cmd.Connection = con;
            
 
        //    cmd.Parameters.AddWithValue("@id", c.id);
           
        //    cmd.Parameters.AddWithValue("@age", c.age);
        //    cmd.Parameters.AddWithValue("@address", c.address);
           
        //    int res = cmd.ExecuteNonQuery();
        //   // MessageBox.Show("inside1");
        //    return res;
        //}

        public SqlDataReader getupdatedcustomer(long id,string itype) {

           // string s = "server=AYUSHASTHANA;database=mydb;trusted_connection=true";
            string s1 = "DATA SOURCE=intvmsql01; INITIAL CATALOG=DB03TMS165_1617; USER ID=PJ03TMS165_1617;PASSWORD=tcstvm";
 
            SqlConnection con = new SqlConnection(s1);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            if (itype.Equals("ssnid"))
                cmd.CommandText = "sp_getcustomerdetailsbyssnid";
            else

                cmd.CommandText = "sp_getcustomerdetailsbycustid";
            cmd.Parameters.AddWithValue("@id",id);
          //  MessageBox.Show("ayush");
            SqlDataReader sd = cmd.ExecuteReader();
            if (sd.Read())
                return sd;
            return null;

        }



        public Boolean chkidexists(createaccount c)
        {
           string s = "DATA SOURCE=intvmsql01;" + "INITIAL CATALOG=DB03TMS165_1617;" + "USER ID=PJ03TMS165_1617;" + "PASSWORD=tcstvm";
          // string s = "server=AYUSHASTHANA;database=mydb;trusted_connection=true";
            SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "chkidexists";
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@cid",c.customerid);

            SqlDataReader sd = cmd.ExecuteReader();
            if (sd.Read())
                return true;
            else
                return false;
        }
        
       /* public Boolean chkid(createaccount c)
        {
            string s = "DATA SOURCE=intvmsql01;" + "INITIAL CATALOG=DB03TMS165_1617;" + "USER ID=PJ03TMS165_1617;" + "PASSWORD=tcstvm";
            SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_chkid";
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@cid", c.custid);

            SqlDataReader sd = cmd.ExecuteReader();
            if (sd.Read())
                return false;
            else
                return true;
        }


        */
       /* public int createaccount(createaccount c) {

            string s = "DATA SOURCE=intvmsql01;" + "INITIAL CATALOG=DB03TMS165_1617;" + "USER ID=PJ03TMS165_1617;" + "PASSWORD=tcstvm";
            SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlCommand cmd1 = new SqlCommand();
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.CommandText = "sp_addsavingaccount";
            cmd1.Connection = con;
            cmd1.Parameters.AddWithValue("@cid", c.custid);

            SqlCommand cmd2 = new SqlCommand();
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.CommandText = "sp_addcurrentaccount";
            cmd2.Connection = con;
            cmd2.Parameters.AddWithValue("@cid", c.custid);

           int r= cmd1.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();
            return r;
        
        
        }
        */
        public Boolean chklogin(LoginViewModel l) {

            //string s = "server=AYUSHASTHANA;database=mydb;trusted_connection=true";
           string s = "DATA SOURCE=intvmsql01;" + "INITIAL CATALOG=DB03TMS165_1617;" + "USER ID=PJ03TMS165_1617;" + "PASSWORD=tcstvm";
            SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlCommand cmd1 = new SqlCommand();
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.CommandText = "sp_chkloginid";
            cmd1.Connection = con;
            cmd1.Parameters.AddWithValue("@id", l.Email);
            cmd1.Parameters.AddWithValue("@pass", l.Password);
            SqlDataReader dr = cmd1.ExecuteReader();
            if (dr.Read())
                return true;
            else
                return false;


        

        }
        public int createsavings(createaccount c)
        {
            //string s1 = "server=LAPTOP-LJI1LU5A\\LOCALHOST;database=mydb;trusted_connection=true";
           // string s1 = "server=AYUSHASTHANA;database=mydb;trusted_connection=true";
            DateTime now = DateTime.Now;
            string s1 = "DATA SOURCE=intvmsql01; INITIAL CATALOG=DB03TMS165_1617; USER ID=PJ03TMS165_1617;PASSWORD=tcstvm";
            SqlConnection cos = new SqlConnection(s1);
            cos.Open();
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "sp_addsavingsaccount";
            com.Connection = cos;
            com.Parameters.AddWithValue("@customerId", c.customerid);
            com.Parameters.AddWithValue("@amount", c.amount);
            com.Parameters.AddWithValue("@ltd", now);
            int r = com.ExecuteNonQuery();
            return r;
        }

        public bool chck2(createaccount c)
        {
            //string s1 = "server=LAPTOP-LJI1LU5A\\LOCALHOST;database=mydb;trusted_connection=true";
             string s1 = "DATA SOURCE=intvmsql01; INITIAL CATALOG=DB03TMS165_1617; USER ID=PJ03TMS165_1617;PASSWORD=tcstvm";
         //   string s1 = "server=AYUSHASTHANA;database=mydb;trusted_connection=true";
            SqlConnection cos = new SqlConnection(s1);
            cos.Open();
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "checkaccountid1216632 ";
            com.Connection = cos;
            com.Parameters.AddWithValue("@customerid", c.customerid);
            SqlDataReader s = com.ExecuteReader();
            if (s.Read())
                return false;
            else
                return true;

            // return true;
        }


        public bool chck3(createaccount c)
        {
            //string s1 = "server=LAPTOP-LJI1LU5A\\LOCALHOST;database=mydb;trusted_connection=true";
           // string s1 = "server=AYUSHASTHANA;database=mydb;trusted_connection=true";
            string s1 = "DATA SOURCE=intvmsql01; INITIAL CATALOG=DB03TMS165_1617; USER ID=PJ03TMS165_1617;PASSWORD=tcstvm";
            SqlConnection cos = new SqlConnection(s1);
            cos.Open();
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "checkcurrentaccount";
            com.Connection = cos;
            com.Parameters.AddWithValue("@customerid", c.customerid);
            SqlDataReader s = com.ExecuteReader();
            if (s.Read())
                return false;
            else
                return true;

            // return true;
        }
        public int createcurrent(createaccount c)
        {
           // string s1 = "server=LAPTOP-LJI1LU5A\\LOCALHOST;database=mydb;trusted_connection=true";

            DateTime now = DateTime.Now;


            string s1 = "DATA SOURCE=intvmsql01; INITIAL CATALOG=DB03TMS165_1617; USER ID=PJ03TMS165_1617;PASSWORD=tcstvm";
            //string s1 = "server=AYUSHASTHANA;database=mydb;trusted_connection=true";
            SqlConnection cos = new SqlConnection(s1);
            cos.Open();
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "sp_addcurrentaccount1216632";
            com.Connection = cos;
            com.Parameters.AddWithValue("@customerId", c.customerid);
            com.Parameters.AddWithValue("@amount", c.amount);
            com.Parameters.AddWithValue("@ltd", now);
            int r = com.ExecuteNonQuery();
            return r;
        }
        
        
        /*  public List<SelectListItem> populateCid() {

          List<SelectListItem> l = new List<SelectListItem>();


          string s = "DATA SOURCE=intvmsql01;" + "INITIAL CATALOG=DB03TMS165_1617;" + "USER ID=PJ03TMS165_1617;" + "PASSWORD=tcstvm";
          SqlConnection con = new SqlConnection(s);
          con.Open();
          SqlCommand cmd = new SqlCommand();
          cmd.CommandType = CommandType.StoredProcedure;
          cmd.CommandText = "sp_retrieveCustId";
          cmd.Connection = con;
         SqlDataReader sd=cmd.ExecuteReader();
         l.Add(new SelectListItem { Text = "Select", Value = "0" });
          while (sd.Read()) {
              l.Add(new SelectListItem { Text = Convert.ToString(sd["ssnid"]) });
             }
          return l;
      
        
        
    }
        */

       /* public int deleteaccount(DeleteAccount cid)
        {
            string s1 = "SERVER=LAPTOP-LJI1LU5A\\LOCALHOST ;" + "DATABASE=mydb;" + "TRUSTED_CONNECTION=TRUE";
            //string s = "DATA SOURCE=intvmsql01;" + "INITIAL CATALOG=DB03TMS165_1617;" + "USER ID=PJ03TMS165_1617;" + "PASSWORD=tcstvm";
            SqlConnection con = new SqlConnection(s1);

            con.Open();
            SqlCommand cmd1 = new SqlCommand();
            SqlCommand cmd2 = new SqlCommand();

            cmd1.CommandType = CommandType.StoredProcedure;
            cmd2.CommandType = CommandType.StoredProcedure;
            
            cmd1.CommandText = "deletesavings";
            cmd2.CommandText = "deletecurrent";
            cmd1.Connection = con;
            cmd2.Connection = con;
            cmd1.Parameters.AddWithValue("@cid", cid.cid);
            cmd2.Parameters.AddWithValue("@cid", cid.cid);
            int r = cmd1.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();
            return r;
        }
        */
    }
}