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
using static System.Windows.Forms.ListViewItem;

namespace SharpDBManager
{
    public partial class UsersForm : Form
    {
        private int __formState;
        public int FormState => __formState;
        public ListView ListViewUsersForm => listViewUsersForm;

        public UsersForm()
        {
            InitializeComponent();
        }

        private void HandleFormState()
        {
            UserForm userForm = new UserForm();

            switch (__formState)
            {
                case 1:
                    {
                        userForm.Text = "Formulaire de Création";
                        break;
                    }
                case 2:
                    {
                        userForm.Text = "Formulaire de modification";
                        break;
                    }
                case 3:
                    {
                        userForm.Text = "Formulaire de suppression";
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            DialogResult result = userForm.ShowDialog(this);
            if (DialogResult.OK == result)
            {
                FillListViewUsersForm();
            }

        }
        private void FillListViewUsersForm()
        {
            ListViewItem listviewItem = default;
            string request = "SELECT * FROM player;";
            MySqlCommand cmd = new MySqlCommand(request, MainForm.mySqlConnection);
            MySqlDataReader rdr = cmd.ExecuteReader();

            listViewUsersForm.Items.Clear(); // On vide la liste, même si elle est vide
            while (rdr.Read())
            {
                ListViewSubItem[] listViewSubItems = new ListViewSubItem[6];

                for (int counter = 0; counter < 6; counter++)
                {
                    listViewSubItems[counter] = new ListViewSubItem
                    {
                        Text = rdr[counter].ToString()
                    };
                }
                listviewItem = new ListViewItem(listViewSubItems, null);
                ListViewUsersForm.Items.Add(listviewItem);
            }
            rdr.Close();
        }

        private void UsersForm_Load(object sender, EventArgs e)
        {
            FillListViewUsersForm();
        }

        private void CreateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            __formState = 1;
            HandleFormState();
        }

        private void UpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            __formState = 2;
            HandleFormState();
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            __formState = 3;
            HandleFormState();
        }
    }
}
