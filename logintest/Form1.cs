using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace logintest
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Set the time zone
            TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById("UTC");

            // Get the current date in the specified time zone
            DateTime currentDate = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow.Date, timeZone);

            // Convert the date to a string
            string dateString = currentDate.ToString("yyyy-MM-dd");

            // Hash the string using SHA256
            byte[] hashBytes = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(dateString));

            // Truncate the hash to 64 bits (8 bytes)
            byte[] truncatedHash = new byte[8];
            Array.Copy(hashBytes, truncatedHash, 8);

            // Convert the truncated hash to a string in hexadecimal format
            string hashString = BitConverter.ToString(truncatedHash).Replace("-", "");

            if (txtkey.Text == hashString)
            {
                new Form2().Show();
                this.Hide();
            }

            else
            {
                MessageBox.Show("Invalid key");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
