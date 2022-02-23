using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Windows.Forms;

namespace WebApplication1.DALLayer
{
    public class db_MD
    {


        public DataSet viewAllCustomer() {

            MessageBox.Show("hfhfhj");

            DataSet g = new DataSet();

            string s = "DATA SOURCE=intvmsql01;" + "INITIAL CATALOG=DB03TMS165_1617;" + "USER ID=PJ03TMS165_1617;" + "PASSWORD=tcstvm";
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



    }
}