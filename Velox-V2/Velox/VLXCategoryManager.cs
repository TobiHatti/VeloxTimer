using Syncfusion.WinForms.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WrapSQL;

namespace Velox
{
    public partial class VLXCategoryManager : SfForm
    {
        public WrapSQLite Sql = null;
        public List<VLXCategory> Categories = null;

        public VLXCategoryManager()
        {
            InitializeComponent();
            VLXLib.SetFormStyle(this);

            this.DialogResult = DialogResult.OK;
        }

        private void VLXCategoryManager_Load(object sender, EventArgs e)
        {
            UpdateCategoryList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Categories.Add(VLXCategory.CreateCategory(Sql));
            UpdateCategoryList();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            VLXCategory selectedCategory = (VLXCategory)lbxCategories.SelectedItem;

            if (MessageBox.Show("Are you sure you want to delete this category and all saved records?\r\n\r\nWarning: This action cannot be undone!", "Delete Category", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {

                if (selectedCategory != null)
                {
                    Categories.Remove(selectedCategory);
                    selectedCategory.Delete(Sql);
                    ToggleFormState(false);

                    txbName.Text = string.Empty;
                    txbDescription.Text = string.Empty;
                }

                UpdateCategoryList();
            }
        }

        private void btnSafeChanges_Click(object sender, EventArgs e)
        {
            VLXCategory selectedCategory = (VLXCategory)lbxCategories.SelectedItem;

            selectedCategory.Name = txbName.Text;
            selectedCategory.Description = txbDescription.Text;

            selectedCategory.UpdateCategoryInfo(Sql);

            UpdateCategoryList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lbxCategories_SelectedIndexChanged(object sender, EventArgs e) => SelectListboxItem();

        private void lbxCategories_Click(object sender, EventArgs e) => SelectListboxItem();

        private void SelectListboxItem()
        {
            VLXCategory selectedCategory = (VLXCategory)lbxCategories.SelectedItem;

            if (selectedCategory != null)
            {
                txbName.Text = selectedCategory.Name;
                txbDescription.Text = selectedCategory.Description;

                ToggleFormState(true);
            }
        }

        private void UpdateCategoryList()
        {
            lbxCategories.Items.Clear();
            lbxCategories.Items.AddRange(Categories.ToArray());
        }

        private void ToggleFormState(bool enabled)
        {
            txbName.Enabled = enabled;
            txbDescription.Enabled = enabled;
            btnDelete.Enabled = enabled;
            btnSafeChanges.Enabled = enabled;
        }
    }
}
