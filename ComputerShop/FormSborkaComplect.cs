using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComputerShopContracts.ViewModels;
using ComputerShopContracts.BuisnessLogicContracts;
using ComputerShopContracts.BindingModels;

namespace ComputerShopView
{
    public partial class FormSborkaComplect : Form
        
    {
        private IComplectLogic _logic;
        public int Id { get { return Convert.ToInt32(comboBox.SelectedValue); } set { comboBox.SelectedValue = value; } }
        public int Price { get { return Convert.ToInt32(textBox.Text); } set { } }
        public string ComplectName { get { return comboBox.Text; } }
        //public int Price { get { return Convert.ToInt32(textBox.Text); } set { textBox.Text = value.ToString(); } }
        public FormSborkaComplect(IComplectLogic logic)
        {
            _logic = logic;
            InitializeComponent();
            List<ComplectViewModel> list = logic.Read(null);
            if (list != null)
            {
                comboBox.DisplayMember = "ComplectName";
                comboBox.ValueMember = "Id";
                comboBox.DataSource = list;
                comboBox.SelectedItem = null;
                textBox.Text = null;
            }
        }

        private void PriceCal()
        {
            if (comboBox.SelectedValue != null)
            {
                int id = Convert.ToInt32(comboBox.SelectedValue);
                ComplectViewModel complect = _logic.Read(new ComplectBindingModel
                {
                    Id = id
                })?[0];
                textBox.Text = complect.Price.ToString();
            }         
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            PriceCal();
        }

        private void comoboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            PriceCal();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            /*if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Колличество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }*/
            if (comboBox.SelectedValue == null)
            {
                MessageBox.Show("Выберите коплектующее", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
