using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace Accounting_App
{
    public partial class frmsetting : Form
    {
        Form1 frmmain;
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd1 = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        CurrencyManager cr;
        SqlCommand c1 = new SqlCommand();
        DataTable tb = new DataTable();
        //-------------------------------//
        SQLiteConnection sc = new SQLiteConnection(@"Data Source=" + Application.StartupPath + @"\ControlT.db; Version=3");
        SQLiteCommand scm = new SQLiteCommand();
        SQLiteDataAdapter sda = new SQLiteDataAdapter();
        public frmsetting(Form1 frm26)
        {
            frmmain = frm26;
            InitializeComponent();
        }

        private void frmsetting_Load(object sender, EventArgs e)
        {
            //conn.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="+Application.StartupPath+@"\Accounting_database.mdf;Integrated Security=True";
            //conn.Open();
            sc.Open();
            lblaac.Visible = false;
            lblwrongpassword.Visible = false;
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            //cmd1.Connection = conn;
            scm.Connection = sc;
            //cmd1.CommandText = "select * from pass where keyword='" + txtpass.Text + "'";
            scm.CommandText = "select * from passapp where pass='" + txtpass.Text + "'";
            //da.SelectCommand = cmd1;
            sda.SelectCommand = scm;
            //da.Fill(tb);
            sda.Fill(tb);
            //cmd1.ExecuteNonQuery();
            scm.ExecuteNonQuery();
            if(tb.Rows.Count>0 && txtnpass.Text==txtnpassr.Text)
            {
                //cmd1.CommandText="update tblpass set keyword='"+txtnpass.Text+"'";
                scm.CommandText= "update passapp set pass='" + txtnpass.Text + "'";
                //cmd1.Connection = conn;
                scm.Connection = sc;
                //da.SelectCommand = cmd1;
                //nullll
                sda.SelectCommand = scm;
                //da.Fill(ds);
                sda.Fill(ds);
                //cmd1.ExecuteNonQuery();
                scm.ExecuteNonQuery();
                lblwrongpassword.Visible = false;
                lblaac.Visible = true;
            }
            else
            {
                txtnpassr.Text = "";
                txtpass.Text = "";
                txtnpass.Text = "";
                lblaac.Visible = false;
                lblwrongpassword.Visible = true;
            }
            //cmd1.Connection = conn;
            //cmd1.CommandText = "select * from tblpass where keyword='" + txtpass.Text + "'";
            //da.SelectCommand = cmd1;
            //da.Fill(ds,"T1");
            //txtnpassr.DataBindings.Clear();
            //txtnpassr.DataBindings.Add("text", ds, "T1.keyword");
            //da.Fill(tb);
            //cmd1.ExecuteNonQuery();
            //if(tb.Rows.Count>0)
            //{
            //    lblaac.Visible = true;
            //}
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            frmmain.fillgrid();
            this.Close();
        }
    }
}
