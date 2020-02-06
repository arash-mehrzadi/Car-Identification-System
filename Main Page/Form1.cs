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
    public partial class Form1 : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd1 = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        CurrencyManager cr;
        SqlCommand c1 = new SqlCommand();
        DataTable tb = new DataTable();
        int state;
        string asad;
        SQLiteConnection sc = new SQLiteConnection(@"Data Source="+Application.StartupPath+@"\ControlT.db; Version=3");
        SQLiteCommand scm = new SQLiteCommand();
        SQLiteDataAdapter sda = new SQLiteDataAdapter();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //conn.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="+Application.StartupPath+@"\Accounting_database.mdf;Integrated Security=True";
            //MessageBox.Show(conn.ConnectionString.ToString());
            //conn.Open();
            sc.Open();
            fillgrid();
            //MessageBox.Show(sc.ConnectionString.ToString());
            //lbllastnum.Text = "ddd";
            lblday.Visible = false;
            lblmonth.Visible = false;
            lblyear.Visible = false;
            txtday.Visible = false;
            txtmonth.Visible = false;
            txtyear.Visible = false;
            txtiran.Visible = false;
            lbldash.Visible = false;
            lblprenum.Visible = false;
            lbllastnum.Visible = false;
            lblletter.Visible = false;
            lblirann.Visible = false;
            combosearchby.SelectedIndex = 0;
            //cr.Position = cr.Count;
            //cant select one row !!!
        }
        public void fillgrid(string s= "select driver,car,iran,lastnum,letter,prenum,State,phonenum from controls ")
        {
            //cmd1.CommandText = s;
            scm.CommandText = s;
            //cmd1.Connection = conn;
            scm.Connection = sc;
            //da.SelectCommand = cmd1;
            sda.SelectCommand = scm;
            ds.Clear();
            sda.Fill(ds, "T1");
            dataGridView1.DataBindings.Clear();
            dataGridView1.DataBindings.Add("datasource", ds, "T1");
            cr = (CurrencyManager)this.BindingContext[ds, "t1"];
        }
        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            frmadd f1 = new frmadd(this);
            f1.ShowDialog();
        }
        public void adddata(string s)
        {
            //SqlCommand c1 = new SqlCommand();
            SQLiteCommand cma1 = new SQLiteCommand();
            //c1.CommandText = s;
            cma1.CommandText = s;
            //c1.Connection = conn;
            cma1.Connection = sc;
            //c1.ExecuteNonQuery();
            cma1.ExecuteNonQuery();
            fillgrid();
        }

        private void txtsearchfor_TextChanged(object sender, EventArgs e)
        {
            string a;
            a = "select * From controls where driver like '%" + txtsearchfor.Text + "%'";
            fillgrid(a);
        }

        private void btncalculate_Click(object sender, EventArgs e)
        {
            frmcalculate f2 = new frmcalculate(this);
            f2.ShowDialog();
        }
        private void combosearchby_SelectedIndexChanged(object sender, EventArgs e)
        {
            string state;
            state = ((ComboBox)sender).Text;
            if (state == "پلاک")
            {
                txtsearchfor.Visible = false;
                lblday.Visible = true;
                lblmonth.Visible = true;
                lblyear.Visible = true;
                txtday.Visible = true;
                txtmonth.Visible = true;
                txtyear.Visible = true;
                txtiran.Visible = true;
                lbldash.Visible = true;
                lblprenum.Visible = true;
                lbllastnum.Visible = true;
                lblletter.Visible = true;
                lblirann.Visible = true;
                btnsearch.Visible = true;
            }
            else
            {
                txtsearchfor.Visible = true;
                lblday.Visible = false;
                lblmonth.Visible = false;
                lblyear.Visible = false;
                txtday.Visible = false;
                txtmonth.Visible = false;
                txtyear.Visible = false;
                txtiran.Visible = false;
                lbldash.Visible = false;
                lblprenum.Visible = false;
                lbllastnum.Visible = false;
                lblletter.Visible = false;
                lblirann.Visible = false;
                btnsearch.Visible = false;
            }
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            string prenum, iran, lastnum, letter, a,name;
            frmfindd f22 = new frmfindd(this);
            if (combosearchby.Text == "پلاک")
            {
                prenum = txtyear.Text;
                letter = txtmonth.Text;
                lastnum = txtday.Text;
                iran = txtiran.Text;
                a = "select * From Tblaccounting where prenum='" + prenum + "' and letter=N'" + letter + "' and lastnum='" + lastnum + "'and Iran='" + iran + "'";
                fillgrid(a);
            }
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            string buttonname;
            buttonname = btnedit.ButtonText;
            if (buttonname == "ویرایش")
            {
                frmedith f3 = new frmedith(this);
                f3.ShowDialog();
            }
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            frmfindd f22 = new frmfindd(this);
            f22.ShowDialog();
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            frmsetting f235 = new frmsetting(this);
            f235.ShowDialog();
        }
    }
}
//created By Arash mehrzadi 
