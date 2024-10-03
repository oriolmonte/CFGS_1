namespace A2Vehicles
{
    public partial class Form1 : Form
    {
        private XMLManagerFactory factory = new XMLManagerFactory();
        private IXMLManager dao = null;
        public Form1()
        {
            dao = factory.CreateXMLImpl();
            InitializeComponent();
            var doc = dao.GetDistinctYears();
            var doc2 = dao.GetSalesByYear(2002);
            Console.WriteLine();
        }
    }
}
