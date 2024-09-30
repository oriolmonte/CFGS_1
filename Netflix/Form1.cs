using Microsoft.Win32;
using System.Data;
using System.Globalization;

namespace Netflix
{
    public partial class Form1 : Form
    {
        private DAOFactory factory = new DAOFactory();
        private IDAO dao = null;

        public Form1()
        {
            dao = factory.CreateNetflixImpl();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int nThriller = dao.SelectByGenre("thriller", "thriller.csv");
            string targetExercici2Null = dao.SelectByIndex(2309472);
            string targetExercici2 = dao.SelectByIndex(10);
            string targetExercici3Null = dao.SelectById("tmaskdjghaskjdh");
            string targetExercici3 = dao.SelectById("tm204541");
            Console.WriteLine();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void idbut_Click(object sender, EventArgs e)
        {
            if (this.idbox.Text != "")
            {
                var a = dao.SelectById(this.idbox.Text);
                if (a != null)
                {
                    registres.Text = a.ToString();
                }
            }
        }

        private void indexbut_Click(object sender, EventArgs e)
        {
            if (this.indexbox.Text != "")
            {
                var a = dao.SelectByIndex(int.Parse(indexbox.Text));
                if (a != null)
                {
                    registres.Text = a.ToString();
                }

            }
        }

        private void registre_TextChanged(object sender, EventArgs e)
        {

        }

        private void mergebut_Click(object sender, EventArgs e)
        {
            registres.Text = "";
            var a = dao.ReadTitles(0, 3000);
            var b = dao.ReadTitles(3000, 3000);
            registres.Text += dao.PreMerge(a, "FIRSTHALF.csv") + "\n";
            registres.Text += dao.PreMerge(b, "SECONDHALF.csv") + "\n";
            try
            {
                dao.Merge("FIRSTHALF.csv", "SECONDHALF.csv", "MERGED.csv");
                registres.Text += "Merged successfully check MERGED.CSV";
            }
            catch (Exception ex)
            {
                registres.Text = ex.Message;
            }



        }

        private void genbut_Click(object sender, EventArgs e)
        {
            if (this.generebox.Text != "")
            {
                var a = dao.SelectByGenre(this.generebox.Text, $"{this.generebox.Text}.csv");
                if (a != null)
                {
                    try
                    {
                        registres.Text = a.ToString() + $" guardats a arxiu {this.generebox.Text}.csv";
                    }
                    catch (Exception ex)
                    {
                        registres.Text = ex.Message;
                    }

                }

            }
        }

        private void rangebut_Click(object sender, EventArgs e)
        {
            if (this.minbox.Text != "" && this.maxbox.Text != "")
            {
                registres.Text = "";
                var a = dao.TitlesInRange("MERGED.CSV", double.Parse(this.minbox.Text, new CultureInfo("en-US")), double.Parse(this.maxbox.Text, new CultureInfo("en-US")));
                foreach (string s in a)
                {
                    registres.Text += s + "\n";
                }
            }
        }
    }
}
