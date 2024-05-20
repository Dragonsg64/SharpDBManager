namespace SharpDBManager
{
    partial class UsersForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.actionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CreateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listViewUsersForm = new System.Windows.Forms.ListView();
            this.Idcolumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Nicknamecolumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PasswordColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AvatarColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PixelColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LevelColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Tower_idColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.actionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // actionsToolStripMenuItem
            // 
            this.actionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CreateToolStripMenuItem,
            this.UpdateToolStripMenuItem,
            this.DeleteToolStripMenuItem});
            this.actionsToolStripMenuItem.Name = "actionsToolStripMenuItem";
            this.actionsToolStripMenuItem.Size = new System.Drawing.Size(70, 24);
            this.actionsToolStripMenuItem.Text = "actions";
            // 
            // CreateToolStripMenuItem
            // 
            this.CreateToolStripMenuItem.Name = "CreateToolStripMenuItem";
            this.CreateToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.CreateToolStripMenuItem.Text = "créer";
            this.CreateToolStripMenuItem.Click += new System.EventHandler(this.CreateToolStripMenuItem_Click);
            // 
            // UpdateToolStripMenuItem
            // 
            this.UpdateToolStripMenuItem.Name = "UpdateToolStripMenuItem";
            this.UpdateToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.UpdateToolStripMenuItem.Text = "modifier";
            this.UpdateToolStripMenuItem.Click += new System.EventHandler(this.UpdateToolStripMenuItem_Click);
            // 
            // DeleteToolStripMenuItem
            // 
            this.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem";
            this.DeleteToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.DeleteToolStripMenuItem.Text = "supprimer";
            this.DeleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItem_Click);
            // 
            // listViewUsersForm
            // 
            this.listViewUsersForm.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Idcolumn,
            this.Nicknamecolumn,
            this.PasswordColumn,
            this.AvatarColumn,
            this.PixelColumn,
            this.LevelColumn,
            this.Tower_idColumn});
            this.listViewUsersForm.HideSelection = false;
            this.listViewUsersForm.Location = new System.Drawing.Point(0, 32);
            this.listViewUsersForm.Name = "listViewUsersForm";
            this.listViewUsersForm.Size = new System.Drawing.Size(800, 419);
            this.listViewUsersForm.TabIndex = 1;
            this.listViewUsersForm.UseCompatibleStateImageBehavior = false;
            this.listViewUsersForm.View = System.Windows.Forms.View.Details;
            // 
            // Idcolumn
            // 
            this.Idcolumn.Text = "Id";
            this.Idcolumn.Width = 31;
            // 
            // Nicknamecolumn
            // 
            this.Nicknamecolumn.Text = "Pseudo";
            // 
            // PasswordColumn
            // 
            this.PasswordColumn.Text = "mot de passe";
            this.PasswordColumn.Width = 98;
            // 
            // AvatarColumn
            // 
            this.AvatarColumn.Text = "avatar";
            // 
            // PixelColumn
            // 
            this.PixelColumn.Text = "Pixel";
            // 
            // LevelColumn
            // 
            this.LevelColumn.Text = "Level";
            // 
            // Tower_idColumn
            // 
            this.Tower_idColumn.Text = "Tower_id";
            this.Tower_idColumn.Width = 75;
            // 
            // UsersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listViewUsersForm);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "UsersForm";
            this.Text = "UsersForm";
            this.Load += new System.EventHandler(this.UsersForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem actionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CreateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UpdateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteToolStripMenuItem;
        private System.Windows.Forms.ListView listViewUsersForm;
        private System.Windows.Forms.ColumnHeader Idcolumn;
        private System.Windows.Forms.ColumnHeader Nicknamecolumn;
        private System.Windows.Forms.ColumnHeader PasswordColumn;
        private System.Windows.Forms.ColumnHeader AvatarColumn;
        private System.Windows.Forms.ColumnHeader PixelColumn;
        private System.Windows.Forms.ColumnHeader LevelColumn;
        private System.Windows.Forms.ColumnHeader Tower_idColumn;
    }
}