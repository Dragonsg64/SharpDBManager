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
    public partial class TowerLevelForm : Form
    {
        public string TextBoxId => textBoxId.Text;
        public string TextBoxLevel => textBoxLevel.Text;
        public string TextBoxPrice => textBoxPrice.Text;
        public string TextBoxDommage => textBoxDommage.Text;
        public string TextBoxFireRate => textBoxFireRate.Text;
        public string TextBoxScope => textBoxScope.Text;
        public string ComboBoxId_name => comboBoxId_tower.Text;
        public TowerLevelForm()
        {
            InitializeComponent();
        }
        private void TowerLevelForm_Load(object sender, EventArgs e)
        {
            TowersLevelForm towersLevelForm = Owner as TowersLevelForm;
            int formState = towersLevelForm.FormState;
            ListView listview = towersLevelForm.ListViewTowersLevelForm;

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
                        textBoxLevel.Text = listViewItem.SubItems[1].Text;
                        textBoxPrice.Text = listViewItem.SubItems[2].Text;
                        textBoxDommage.Text = listViewItem.SubItems[3].Text;
                        textBoxFireRate.Text = listViewItem.SubItems[4].Text;
                        textBoxScope.Text = listViewItem.SubItems[5].Text;
                        comboBoxId_tower.Text = listViewItem.SubItems[6].Text;


                        if (formState == 3)
                        {
                            textBoxId.Enabled = false;
                            textBoxLevel.Enabled = false;
                            textBoxPrice.Enabled = false;
                            textBoxDommage.Enabled = false;
                            textBoxFireRate.Enabled = false;
                            textBoxScope.Enabled = false;
                            comboBoxId_tower.Enabled = false;

                        }
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        private void ComboBox(ComboBox comboBox, string displayMember, string valueMember, object dataSource, object selectedValue)
        {
            comboBox.BeginUpdate();
            comboBox.DisplayMember = displayMember;
            comboBox.ValueMember = valueMember;
            comboBox.DataSource = dataSource;
            comboBox.BindingContext = new BindingContext();
            comboBox.SelectedValue = selectedValue;
            comboBox.EndUpdate();
        }

        private void buttonValidate_Click(object sender, EventArgs e)
        {
            // Récupérer "qui" a ouvert ce formulaire
            TowersLevelForm towersForm = Owner as TowersLevelForm;
            // Modification ou création ? Donc on récupère l'état d'ouverture du formulaire
            int formState = towersForm.FormState;
            switch (formState)
            {
                case 1:
                    {
                        // Insert
                        string request;
                        MySqlCommand mySqlCommand;


                        request = $"INSERT INTO tower_level (level, price, dommage, fireRate, scope, id_tower) VALUES ('{textBoxLevel.Text}', '{textBoxPrice.Text}', '{textBoxDommage.Text}', '{textBoxFireRate.Text}', '{textBoxScope.Text}', '{comboBoxId_tower.Text}');";
                        mySqlCommand = new MySqlCommand(request, MainForm.mySqlConnection);
                        mySqlCommand.ExecuteNonQuery();
                        break;
                    }
                case 2:
                    {
                        // Update
                        string request;
                        MySqlCommand mySqlCommand;

                        request = $"UPDATE tower_level SET level = '{textBoxLevel.Text}', price = '{textBoxPrice.Text}', dommage = '{textBoxDommage.Text}', firerate = '{textBoxFireRate.Text}', scope = '{textBoxScope.Text}', id_tower = '{comboBoxId_tower.Text}' WHERE Id = {textBoxId.Text}";
                        mySqlCommand = new MySqlCommand(request, MainForm.mySqlConnection);
                        mySqlCommand.ExecuteNonQuery();
                        break;
                    }
                case 3:
                    {
                        // Delete
                        string request;
                        MySqlCommand mySqlCommand;

                        request = $"DELETE FROM tower_level WHERE Id = {textBoxId.Text}";
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
