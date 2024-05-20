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
    public partial class TowerNameForm : Form
    {
        private string selectQuery;

        public string TextBoxId => textBoxId.Text;
        public string TextBoxName => textBoxName.Text;
        public TowerNameForm()
        {
            InitializeComponent();
        }

        private void TowerNameForm_Load(object sender, EventArgs e)
        {
            TowersNameForm towersNameForm = Owner as TowersNameForm;
            int formState = towersNameForm.FormState;
            ListView listview = towersNameForm.ListViewTowersNameForm;

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
                        ListViewItem listViewItem = listview.SelectedItems[0];

                        textBoxId.Text = listViewItem.SubItems[0].Text;
                        textBoxName.Text = listViewItem.SubItems[1].Text;


                        if (formState == 3)
                        {
                            textBoxId.Enabled = false;
                            textBoxName.Enabled = false;

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
            TowersNameForm towersNameForm = Owner as TowersNameForm;
            // Modification ou création ? Donc on récupère l'état d'ouverture du formulaire
            int formState = towersNameForm.FormState;
            switch (formState)
            {
                case 1:
                    {
                        // Insert
                        string request;
                        MySqlCommand mySqlCommand;

                        request = $"INSERT INTO tower (name) VALUES ('{textBoxName.Text}');";
                        mySqlCommand = new MySqlCommand(request, MainForm.mySqlConnection);
                        mySqlCommand.ExecuteNonQuery();
                        break;
                    }
                case 2:
                    {
                        // Update
                        string request;
                        MySqlCommand mySqlCommand;

                        request = $"UPDATE tower SET name = '{textBoxName.Text}'  WHERE Id = {textBoxId.Text}";
                        mySqlCommand = new MySqlCommand(request, MainForm.mySqlConnection);
                        mySqlCommand.ExecuteNonQuery();
                        break;
                    }
                case 3:
                    {
                        // Delete
                        string request;
                        MySqlCommand mySqlCommand;

                        request = $"DELETE FROM tower WHERE Id = {textBoxId.Text}";
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
