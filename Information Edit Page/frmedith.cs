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
    public partial class frmedith : Form
    {
        Form1 frmmain;
        Timer t = new Timer();
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd1 = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        CurrencyManager cr;
        SqlCommand c1 = new SqlCommand();
        DataTable tb = new DataTable();
        //---------------------------------//
        SQLiteConnection sc = new SQLiteConnection(@"Data Source=" + Application.StartupPath + @"\ControlT.db; Version=3");
        SQLiteCommand scm = new SQLiteCommand();
        SQLiteDataAdapter sda = new SQLiteDataAdapter();
        public frmedith(Form1 frm3)
        {
            frmmain = frm3;
            InitializeComponent();
            formload(null,null);
        }
        private void formload(object sender,EventArgs e)
        {
            
        }

        private void frmedith_Load(object sender, EventArgs e)
        {
            //conn.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="+Application.StartupPath+@"\Accounting_database.mdf;Integrated Security=True";
            //conn.Open();
            sc.Open();
            txtsearch.Enabled = false;
            txtname.Enabled = false;
            txtcarname.Enabled = false;
            txtphonenum.Enabled = false;
            txtstate.Enabled = false;
            txtprenum.Enabled = false;
            txtletter.Enabled = false;
            txtlastnum.Enabled = false;
            txtiran.Enabled = false;
            btnsearch1.Enabled = false;
            btnsearch1.ButtonText = "";
            btnsabt.Enabled = false;
            btnsabt.ButtonText = "";
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            frmmain.fillgrid();
            this.Close();
        }

        private void btnactivation_Click(object sender, EventArgs e)
        {
            //cmd1.Connection = conn;
            scm.Connection = sc;
            //cmd1.CommandText = "select * from tblpass where keyword='" + txtpasscode.Text + "'";
            scm.CommandText= "select * from passapp where pass='" + txtpasscode.Text + "'";
            //da.SelectCommand = cmd1;
            sda.SelectCommand = scm;
            //da.Fill(tb);
            sda.Fill(tb);
            //cmd1.ExecuteNonQuery();
            scm.ExecuteNonQuery();
            if (tb.Rows.Count>0)
            {
                txtsearch.Enabled = true;
                txtname.Enabled = true;
                txtcarname.Enabled = true;
                txtphonenum.Enabled = true;
                txtstate.Enabled = true;
                txtprenum.Enabled = true;
                txtletter.Enabled = true;
                txtlastnum.Enabled = true;
                txtiran.Enabled = true;
                btnsearch1.Enabled = true;
                btnsearch1.ButtonText = "جستجو";
                lblactivation.Text = "فعال";
                lblactivation.ForeColor = Color.SeaGreen;
            }
            else
                txtpasscode.Text = "";
            tb.Clear();
        }

        private void btnsearch1_Click(object sender, EventArgs e)
        {
            string drivername;
            drivername = "select * From controls where driver like '%" + txtsearch.Text + "%'";
            //cmd1.CommandText = drivername;
            scm.CommandText = drivername;
            //cmd1.Connection = conn;
            scm.Connection = sc;
            //da.SelectCommand = cmd1;
            sda.SelectCommand = scm;
            //da.Fill(ds, "T1");
            sda.Fill(ds, "T1");
            txtsearch.Text = "";
            txtname.DataBindings.Clear();
            txtname.DataBindings.Add("text", ds, "T1.driver");
            txtcarname.DataBindings.Clear();
            txtcarname.DataBindings.Add("text", ds, "T1.car");
            txtphonenum.DataBindings.Clear();
            txtphonenum.DataBindings.Add("text", ds, "T1.phonenum");
            txtstate.DataBindings.Clear();
            txtstate.DataBindings.Add("text", ds, "T1.state");
            txtprenum.DataBindings.Clear();
            txtprenum.DataBindings.Add("text", ds, "T1.prenum");
            txtlastnum.DataBindings.Clear();
            txtlastnum.DataBindings.Add("text", ds, "T1.lastnum");
            txtletter.DataBindings.Clear();
            txtletter.DataBindings.Add("text", ds, "T1.letter");
            txtiran.DataBindings.Clear();
            txtiran.DataBindings.Add("text", ds, "T1.iran");
            txtip.DataBindings.Clear();
            txtip.DataBindings.Add("text", ds, "T1.id");
            txtdanesh.DataBindings.Clear();
            txtdanesh.DataBindings.Add("text", ds, "T1.danesh");
        }

        private void txtname_TextChanged(object sender, EventArgs e)
        {
            if (txtname.Text == "")
            {
                btnsabt.Enabled = false;
                btnsabt.ButtonText = "";
            }
            else
            {
                btnsabt.Enabled = true;
                btnsabt.ButtonText = "ثبت";
            }
        }

        private void btnsabt_Click(object sender, EventArgs e)
        {
            //SqlCommand c3 = new SqlCommand();
            SQLiteCommand c3 = new SQLiteCommand();
            c3.CommandText = "update controls set driver=@p1,car=@p2,phonenum=@p3,state=@p4,prenum=@p5,lastnum=@p6,letter=@p7,iran=@p8,id=@p9,danesh=@p10 where driver=@p11";
            c3.Parameters.AddWithValue("p1", txtname.Text);
            c3.Parameters.AddWithValue("p2", txtcarname.Text);
            c3.Parameters.AddWithValue("p3", txtphonenum.Text);
            c3.Parameters.AddWithValue("p4", txtstate.Text);
            c3.Parameters.AddWithValue("p5", txtprenum.Text);
            c3.Parameters.AddWithValue("p6", txtlastnum.Text);
            c3.Parameters.AddWithValue("p7", txtletter.Text);
            c3.Parameters.AddWithValue("p8", txtiran.Text);
            c3.Parameters.AddWithValue("p9", txtip.Text);
            c3.Parameters.AddWithValue("p10", txtdanesh.Text);
            c3.Parameters.AddWithValue("p11", txtname.Text);
            //c3.Connection = conn;
            c3.Connection = sc;
            c3.ExecuteNonQuery();
            frmmain.fillgrid();
            txtname.Text = "";
            txtcarname.Text = "";
            txtphonenum.Text = "";
            txtstate.Text = "";
            txtprenum.Text = "";
            txtlastnum.Text = "";
            txtletter.Text = "";
            txtiran.Text = "";
            txtip.Text = "";
            txtdanesh.Text = "";
        }
    }
}
