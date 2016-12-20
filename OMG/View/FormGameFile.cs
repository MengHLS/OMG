using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HJZBYSJ.DataBase;

namespace HJZBYSJ.View
{
    public partial class FormGameFile : Form
    {
        private int SelectedIndex = 0;
        public int SelectedGameName = 0;
        public FormGameFile()
        {
            InitializeComponent();
        }

        private void FormGameFile_Load(object sender, EventArgs e)
        {
            FillComponent(gridGameView);
            UpdateProjectList();
        }

        private static void FillComponent(DataGridView grid)
        {
            //grid.Columns["GameID"].DataPropertyName = "GameID";
            grid.Columns["GameName"].DataPropertyName = "GameName";
            grid.AutoGenerateColumns = false;
        }

        private void UpdateProjectList()
        {
            gridGameView.DataSource = GameUtil.GetAllGame();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (gridGameView.SelectedRows.Count > 0)
            {
                SelectedIndex = gridGameView.SelectedRows[0].Index;
                this.SelectedGameName = Convert.ToInt32(gridGameView.Rows[SelectedIndex].Cells["GameName"].Value);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (gridGameView.SelectedRows.Count > 0)
            {
                SelectedIndex = gridGameView.SelectedRows[0].Index;
                this.SelectedGameName = Convert.ToInt32(gridGameView.Rows[SelectedIndex].Cells["GameName"].Value);
                GameUtil.Delete(this.SelectedGameName);
                UpdateProjectList();
            }
        }
    }
}
