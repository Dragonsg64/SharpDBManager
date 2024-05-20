using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.ListViewItem;

namespace SharpDBManager
{
    public partial class TowersNameForm : Form
    {
        private int __formState;
        public int FormState => __formState;
        public ListView ListViewTowersNameForm => listViewTowersNameForm;
        public TowersNameForm()
        {
            InitializeComponent();
        }
        private void HandleFormState()
        {
            TowerNameForm towerForm = new TowerNameForm();

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
                FillListViewTowersNameForm();
            }
        }
        private void FillListViewTowersNameForm()
        {
            ListViewItem listviewItem = default;
            string request = "SELECT * FROM tower;";
            MySqlCommand cmd = new MySqlCommand(request, MainForm.mySqlConnection);
            MySqlDataReader rdr = cmd.ExecuteReader();

            listViewTowersNameForm.Items.Clear(); // On vide la liste, même si elle est vide
            while (rdr.Read())
            {
                ListViewSubItem[] listViewSubItems = new ListViewSubItem[2];

                for (int counter = 0; counter < 2; counter++)
                {
                    listViewSubItems[counter] = new ListViewSubItem
                    {
                        Text = rdr[counter].ToString()
                    };
                }
                listviewItem = new ListViewItem(listViewSubItems, null);
                ListViewTowersNameForm.Items.Add(listviewItem);
            }
            rdr.Close();
        }

        private void TowersNameForm_Load(object sender, EventArgs e)
        {
            FillListViewTowersNameForm();
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
