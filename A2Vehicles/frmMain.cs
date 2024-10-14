using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.AxHost;

namespace A2Vehicles
{
    public partial class frmMain : Form
    {
        private XMLManagerFactory factory = new XMLManagerFactory();
        private IXMLManager dao = null;
        private string[] mesos = ["JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC", "ALL"];

        public frmMain()
        {
            dao = factory.CreateXMLImpl();
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            var intYears = dao.GetDistinctYears();
            List<string> years = new List<string>();
            foreach (var year in intYears)
            {
                years.Add(year.ToString());
            }
            years.Add("ALL");
            cmbMonths.DataSource = mesos;
            cmbYears.DataSource = years;
            cmbYears.Text = "ALL";
            cmbMonths.Text = "ALL";
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            string mes = cmbMonths.Text;
            string any = cmbYears.Text;

            if (mes != "ALL" && any == "ALL")
            {
                Statistic result = dao.GetSalesByMonth(mes);
                ShowStatistic(result);
            }
            else if (any != "ALL" && mes == "ALL")
            {
                Statistic result = dao.GetSalesByYear(Convert.ToInt32(any));
                ShowStatistic(result);
            }

            else if (mes != "ALL" && mes != "ALL")
            {
                var result = dao.GetSalesByYearAndMonth(int.Parse(any), mes);
                ShowStatistic(result);
            }
        }
        private void ShowStatistic(Statistic stat)
        {
            lblYear.Text = stat.Year.ToString();
            lblMonth.Text = stat.Month.ToString();
            lblNew.Text = stat.New.ToString();
            lblUsed.Text = stat.Used.ToString();
            lblIncomeNew.Text = stat.IncomeNew.ToString();
            lblIncomeUsed.Text = stat.IncomeUsed.ToString();

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnShowDesglose_Click(object sender, EventArgs e)
        {
            try
            {
                int year = int.Parse(cmbYears.Text);
                List<Statistic> list = dao.GetSalesMonthByMonth(year);
                dgvDataOfAYear.DataSource = list;
                lblTitleGrid.Text = year.ToString();
            }
            catch
            {
                MessageBox.Show("Please select a year", "Incorrect usage", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnClearGrid_Click(object sender, EventArgs e)
        {
            dgvDataOfAYear.DataSource = null;
            lblTitleGrid.Text = null;
        }

        private void btnClearSide_Click(object sender, EventArgs e)
        {
            lblYear.Text = null;
            lblMonth.Text = null;
            lblNew.Text = null;
            lblUsed.Text = null;
            lblIncomeNew.Text = null;
            lblIncomeUsed.Text = null;
        }

        private void btnUpdateStatistics_Click(object sender, EventArgs e)
        {
            try
            {
                var result = dao.GetSalesByYearAndMonth(int.Parse(cmbYears.Text), cmbMonths.Text);
                Form frmUpdate = new frmUpdateStatistics(result, dao);
                frmUpdate.Show();
            }
            catch
            {
                MessageBox.Show("Please select a year and a month", "Incorrect usage", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
