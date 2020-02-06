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
    public partial class frmfindd : Form
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
        //-----------------------------------//
        SQLiteConnection sc = new SQLiteConnection(@"Data Source=" + Application.StartupPath + @"\ControlT.db; Version=3");
        SQLiteCommand scm = new SQLiteCommand();
        SQLiteDataAdapter sda = new SQLiteDataAdapter();
        public frmfindd(Form1 frm)
        {
            frmmain = frm;
            InitializeComponent();
        }
        private void frmfindd_Load(object sender, EventArgs e)
        {
            //conn.ConnectionString = @"Data Source="+Application.ExecutablePath+@";AttachDbFilename="+Application.StartupPath+@"\Accounting_database;Integrated Security=True";
            //conn.Open();
            sc.Open();
            lblwarning.Visible = false;
            txtsearchfor.Visible = false;
            txtpernums.Visible = true;
            txtlastnums.Visible = true;
            txtirans.Visible = true;
            lbllasts.Visible = true;
            lblletters.Visible = true;
            lblprenums.Visible = true;
            lblpelak.Visible = true;
            combosearchby.SelectedIndex = 0;
        }

        private void combosearchby_SelectedIndexChanged(object sender, EventArgs e)
        {
            string state;
            state = ((ComboBox)sender).Text;
            if (state == "پلاک")
            {
                txtsearchfor.Visible = false;
                txtpernums.Visible = true;
                txtlastnums.Visible = true;
                txtirans.Visible = true;
                txtletters.Visible = true;
                lbllasts.Visible = true;
                lblletters.Visible = true;
                lblprenums.Visible = true;
                lblpelak.Visible = true;
                lbl1.Visible = true;
                lbl2.Visible = true;
                lbl3.Visible = true;
                lblirans.Visible = true;
            }
            else
            {
                txtsearchfor.Visible = true;
                txtpernums.Visible = false;
                txtlastnums.Visible = false;
                txtirans.Visible = false;
                txtletters.Visible = false;
                lbllasts.Visible = false;
                lblletters.Visible = false;
                lblprenums.Visible = false;
                lblpelak.Visible = false;
                lbl1.Visible = false;
                lbl2.Visible = false;
                lbl3.Visible = false;
                lblirans.Visible = false;
            }
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            frmmain.fillgrid();
            this.Close();
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
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
            string prenum, iran, lastnum, letter, a, name;
            if (combosearchby.Text=="نام مالک")
            {
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
                string drivername;
                drivername = "select * From controls where driver like '%" + txtsearchfor.Text + "%'";
                //cmd1.CommandText = drivername;
                scm.CommandText = drivername;
                //cmd1.Connection = conn;
                scm.Connection = sc;
                //da.SelectCommand = cmd1;
                sda.SelectCommand = scm;
                //da.Fill(ds, "T1");
                sda.Fill(ds, "T1");
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
            else
            {
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
                prenum = txtpernums.Text;
                letter = txtletters.Text;
                lastnum = txtlastnums.Text;
                iran = txtirans.Text;
                a = "select * From controls where prenum='" + prenum + "' and letter='" + letter + "' and lastnum='" + lastnum + "'and Iran='" + iran + "'";
                string drivername;
                drivername = a;
                //cmd1.CommandText = drivername;
                scm.CommandText = drivername;
                //cmd1.Connection = conn;
                scm.Connection = sc;
                //da.SelectCommand = cmd1;
                sda.SelectCommand = scm;
                //da.Fill(ds, "T1");
                sda.Fill(ds, "T1");
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
            if (txtname.Text == "")
            {
                lblwarning.Visible = true;
            }
            else
            {
                lblwarning.Visible = false;
            }

        }
    }
}
