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
        }

        private void VLXCategoryManager_Load(object sender, EventArgs e)
        {
            lbxCategories.Items.AddRange(Categories.ToArray());
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnSafeChanges_Click(object sender, EventArgs e)
        {
            VLXCategory selectedCategory = (VLXCategory)lbxCategories.SelectedItem;

            selectedCategory.Name = txbName.Text;
            selectedCategory.Description = txbDescription.Text;

            selectedCategory.SaveCategoryInfo(Sql);
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

            txbName.Text = selectedCategory.Name;
            txbDescription.Text = selectedCategory.Description;
        }
    }
}
