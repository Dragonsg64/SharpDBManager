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
using Org.BouncyCastle.Crypto.Generators;
using BCryptNet = BCrypt.Net.BCrypt;

namespace SharpDBManager
{
    public partial class UserForm : Form
    {
        public string TextBoxId => textBoxId.Text;
        public string TextBoxNickname => textBoxNickname.Text;
        public string TextBoxPassword => textBoxPassword.Text;
        public string TextBoxAvatar => textBoxAvatar.Text;
        public string TextBoxCoin => textBoxPixel.Text;
        public string TextBoxLevel => textBoxLevel.Text;
        public UserForm()
        {
            InitializeComponent();
        }
        private void UserForm_Load(object sender, EventArgs e)
        {
            // Récupérer "qui" a ouvert ce formulaire
            UsersForm usersForm = Owner as UsersForm;
            // Modification ou création ? Donc on récupère l'état d'ouverture du formulaire
            int formState = usersForm.FormState;
            // Récupérer la Liste des utilisateurs
            ListView listView = usersForm.ListViewUsersForm;

            // Clef primaire TextBoxId n'est pas modifiable... 
            textBoxId.Enabled = false;

            switch (formState)
            {
                case 1:
                    {
                        break;
                    }
                case 2:
                case 3:
                    {
                        ListViewItem listViewItem = listView.SelectedItems[0];

                        textBoxId.Text = listViewItem.SubItems[0].Text;
                        textBoxNickname.Text = listViewItem.SubItems[1].Text;
                        textBoxPassword.Text = listViewItem.SubItems[2].Text;
                        textBoxAvatar.Text = listViewItem.SubItems[3].Text;
                        textBoxPixel.Text = listViewItem.SubItems[4].Text;
                        textBoxLevel.Text = listViewItem.SubItems[5].Text;
                        if (formState == 3)
                        {
                            textBoxId.Enabled = false;
                            textBoxNickname.Enabled = false;
                            textBoxPassword.Enabled = false;
                            textBoxAvatar.Enabled = false;
                            textBoxPixel.Enabled = false;
                            textBoxLevel.Enabled = false;
                        }
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
        private void buttonValidate_Click(object sender, EventArgs e)
        {
            // Récupérer "qui" a ouvert ce formulaire
            UsersForm usersForm = Owner as UsersForm;
            // Modification ou création ? Donc on récupère l'état d'ouverture du formulaire
            int formState = usersForm.FormState;
            switch (formState)
            {
                case 1:
                    {
                        string passwordHash = BCrypt.Net.BCrypt.HashPassword(textBoxPassword.Text);
                        // Insert
                        string request;
                        MySqlCommand mySqlCommand;

                        request = $"INSERT INTO player (nickname, password, avatar, pixel, level) VALUES ('{textBoxNickname.Text}', '{passwordHash}', '{textBoxAvatar}', '{textBoxPixel.Text}', '{textBoxLevel.Text}');";
                        mySqlCommand = new MySqlCommand(request, MainForm.mySqlConnection);
                        mySqlCommand.ExecuteNonQuery();
                        break;
                    }
                case 2:
                    {
                        string passwordHash = BCrypt.Net.BCrypt.HashPassword(textBoxPassword.Text);
                        // Update
                        string request;
                        MySqlCommand mySqlCommand;

                        request = $"UPDATE player SET nickname = '{textBoxNickname.Text}', password = '{passwordHash}', avatar = '{textBoxAvatar.Text}' , pixel = '{textBoxPixel.Text}' , level = '{textBoxLevel.Text}'  WHERE Id = {textBoxId.Text}";
                        mySqlCommand = new MySqlCommand(request, MainForm.mySqlConnection);
                        mySqlCommand.ExecuteNonQuery();
                        break;
                    }
                case 3:
                    {
                        // Delete
                        string request;
                        MySqlCommand mySqlCommand;

                        request = $"DELETE FROM player WHERE Id = {textBoxId.Text}";
                        mySqlCommand = new MySqlCommand(request, MainForm.mySqlConnection);
                        mySqlCommand.ExecuteNonQuery();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
    }
}
