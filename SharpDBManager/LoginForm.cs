using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;

namespace SharpDBManager
{
    public partial class LoginForm : Form
    {

        public string TextBoxHost
        {
            get { return textBoxHost.Text; }
        }

        public string TextBoxUser
        {
            get { return textBoxUser.Text; }
        }

        public string TextBoxPassword
        {
            get { return textBoxPassword.Text; }
        }

        public string TextBoxDatabase
        {
            get { return textBoxDatabase.Text; }
        }
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            textBoxHost.Text = "localhost";
            textBoxUser.Text = "root";
            textBoxPassword.Text = "";
            textBoxDatabase.Text = "tower_defense";
        }

        private void buttonValidate_Click(object sender, EventArgs e)
        {
            MySqlConnectionStringBuilder builder = default;

            builder = new MySqlConnectionStringBuilder
            {
                Server = textBoxHost.Text,
                UserID = textBoxUser.Text,
                Password = textBoxPassword.Text,
                Database = textBoxDatabase.Text
            };
            MainForm.mySqlConnection = new MySqlConnection(builder.ConnectionString);
            try
            {
                MainForm.mySqlConnection.Open();
            }
            catch (Exception exception)
            {
                Console.WriteLine($"La connexion à la base de données a échouée : {exception.Message}");
            }
        }
    }
}
