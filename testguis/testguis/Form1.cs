namespace testguis
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var wert1 = textBox1.Text;
            var wert2 = textBox2.Text;

            try
            {
                double produkt = Int32.Parse(wert1) * Int32.Parse(wert2);
                richTextBox1.Text = produkt.ToString();
            }
            catch (FormatException)
            {

                richTextBox1.Text = ("Kein Gültiger wert");
            }
            
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}