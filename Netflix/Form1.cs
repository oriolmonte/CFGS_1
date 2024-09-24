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
            dao.SelectByGenre("drama", "outdrama.txt");
        }
    }
}
