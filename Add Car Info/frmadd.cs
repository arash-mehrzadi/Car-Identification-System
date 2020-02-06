using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Accounting_App
{
    public partial class frmadd : Form
    {
        Form1 frmmain;
        public frmadd(Form1 frm)
        {
            frmmain = frm;
            InitializeComponent();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            string s;
            //int statevalue;
            //if (cmbstate.Text == "واریز")
            //    statevalue = 1;
            //else
            //    statevalue = 0;
            s = "insert into controls values ('" + txtcaption.Text + "','" + txtcost.Text + "','" + txtyear.Text +"','"+txtmonth.Text+"','"+txtdate.Text +"','"+txtiran.Text+"','"+ cmbstate.Text+ "','"+txtphonenum.Text+"','"+ txtip.Text+"','"+txtdanesh.Text+"')";
            frmmain.adddata(s);
            txtcaption.Text = "";
            txtcost.Text = "";
            txtdate.Text = "";
            txtmonth.Text = "";
            txtyear.Text = "";
            cmbstate.Text = "";
            txtphonenum.Text = "";
            txtiran.Text = "";
            cmbstate.Focus();
        }

        private void frmadd_Load(object sender, EventArgs e)
        {
            cmbstate.SelectedIndex = 1;
        }
    }
}
