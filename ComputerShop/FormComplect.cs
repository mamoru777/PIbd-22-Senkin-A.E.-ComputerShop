using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComputerShopContracts.BindingModels;
using ComputerShopContracts.BuisnessLogicContracts;
namespace ComputerShopView
{
    public partial class FormComplect : Form
    {
        public int Id { set { id = value; } }
        private readonly IComplectLogic _logic;
        private int? id;
        public FormComplect(IComplectLogic logic)
        {
            InitializeComponent();
            _logic = logic;
        }

        private void FormComplect_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    var view = _logic.Read(new ComplectBindingModel { Id = id })?[0];
                    if (view != null)
                    {
                        textBoxName.Text = view.ComplectName;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                _logic.CreateOrUpdate(new ComplectBindingModel
                {
                    Id = id,
                    ComplectName = textBoxName.Text,
                    Price = System.Convert.ToDecimal(textBoxPrice.Text)
                });
                MessageBox.Show("Сохранени прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
