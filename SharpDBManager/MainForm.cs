using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BCrypt.Net;

namespace SharpDBManager
{
    public partial class MainForm : Form
    {
        static public MySqlConnection mySqlConnection = default;
        public MainForm()
        {
            InitializeComponent();
        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsersForm usersForm = new UsersForm();
            usersForm.ShowDialog();
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            DialogResult result;

            result = loginForm.ShowDialog();
            if (DialogResult.OK == result)
            {
                MySqlConnectionStringBuilder builder = default;

                builder = new MySqlConnectionStringBuilder
                {
                    Server = loginForm.TextBoxHost,
                    UserID = loginForm.TextBoxUser,
                    Password = loginForm.TextBoxPassword,
                    Database = loginForm.TextBoxDatabase,
                };
                MainForm.mySqlConnection = new MySqlConnection(builder.ConnectionString);
                MainForm.mySqlConnection.Open();

                if (default != mySqlConnection)
                {
                    ConnectButton.Enabled = false;
                    DisconnectButton.Enabled = true;
                    userToolStripMenuItem.Enabled = true;
                }
            }
        }

        private void DisconnectButton_Click(object sender, EventArgs e)
        {
            if (default != mySqlConnection)
            {
                mySqlConnection.Close();
                mySqlConnection = default;
                ConnectButton.Enabled = true;
                DisconnectButton.Enabled = false;
                userToolStripMenuItem.Enabled = false;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            DisconnectButton.Enabled = false;
            userToolStripMenuItem.Enabled = false;
        }

        private void nameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TowersNameForm towersNameForm = new TowersNameForm();
            towersNameForm.ShowDialog();
        }

        private void levelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TowersLevelForm towersLevelForm = new TowersLevelForm();
            towersLevelForm.ShowDialog();
        }

        private void leaveStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
