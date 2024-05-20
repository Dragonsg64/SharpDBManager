using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.ListViewItem;

namespace SharpDBManager
{
    public partial class TowersLevelForm : Form
    {
        private int __formState;
        public int FormState => __formState;
        public ListView ListViewTowersLevelForm => listViewTowersLevelForm;
        public TowersLevelForm()
        {
            InitializeComponent();
        }
        private void HandleFormState()
        {
            TowerLevelForm towerForm = new TowerLevelForm();

            switch (__formState)
            {
                case 1:
                    {
                        towerForm.Text = "Formulaire de Création";
                        break;
                    }
                case 2:
                    {
                        towerForm.Text = "Formulaire de modification";
                        break;
                    }
                case 3:
                    {
                        towerForm.Text = "Formulaire de suppression";
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            DialogResult result = towerForm.ShowDialog(this);
            if (DialogResult.OK == result)
            {
                FillListViewTowersLevelForm();
            }
        }
        private void FillListViewTowersLevelForm()
        {
            ListViewItem listviewItem = default;
            string request = "SELECT * FROM tower_level;";
            MySqlCommand cmd = new MySqlCommand(request, MainForm.mySqlConnection);
            MySqlDataReader rdr = cmd.ExecuteReader();

            listViewTowersLevelForm.Items.Clear(); // On vide la liste, même si elle est vide
            while (rdr.Read())
            {
                ListViewSubItem[] listViewSubItems = new ListViewSubItem[7];

                for (int counter = 0; counter < 7; counter++)
                {
                    listViewSubItems[counter] = new ListViewSubItem
                    {
                        Text = rdr[counter].ToString()
                    };
                }
                listviewItem = new ListViewItem(listViewSubItems, null);
                ListViewTowersLevelForm.Items.Add(listviewItem);
            }
            rdr.Close();
        }

        private void TowersLevelForm_Load(object sender, EventArgs e)
        {
            FillListViewTowersLevelForm();
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            __formState = 1;
            HandleFormState();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            __formState = 2;
            HandleFormState();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            __formState = 3;
            HandleFormState();
        }
    }
}
