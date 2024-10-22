using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using A2Vehicles;

namespace A2Vehicles
{
    public partial class frmUpdateStatistics : Form
    {
        Statistic registre;
        IXMLManager xmlManager;
        public frmUpdateStatistics(Statistic registre, IXMLManager xmlManager)
        {
            this.registre = registre;
            this.xmlManager = xmlManager;
            InitializeComponent();
        }

        private void frmUpdateStatistics_Load(object sender, EventArgs e)
        {
            this.lblMonthU.Text = registre.Month;
            this.lblYearU.Text = registre.Year;
            this.txtNew.Text = registre.New.ToString();
            this.txtINew.Text = registre.IncomeNew.ToString();
            this.txtUsed.Text = registre.Used.ToString();
            this.txtIUsed.Text = registre.IncomeUsed.ToString();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            registre = new Statistic(lblYearU.Text, lblMonthU.Text, long.Parse(txtINew.Text), long.Parse(txtIUsed.Text), int.Parse(txtUsed.Text), int.Parse(txtNew.Text));
            xmlManager.UpdateStatistics(registre);
            this.Close();
        }
    }
}
