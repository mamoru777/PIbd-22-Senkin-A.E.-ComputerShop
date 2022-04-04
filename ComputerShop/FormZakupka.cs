using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComputerShopContracts.BuisnessLogicContracts;
using ComputerShopContracts.ViewModels;
using ComputerShopContracts.BindingModels;

namespace ComputerShopView
{
    public partial class FormZakupka : Form
    {
        private readonly IZakupkaLogic _logicZ;
        private readonly IComplectLogic _logicC;
        public FormZakupka(IZakupkaLogic logicZ, IComplectLogic logicC)
        {
            InitializeComponent();
            _logicZ = logicZ;
            _logicC = logicC;
        }

        private void FormZakupka_Load(object sender, EventArgs e)
        {
            List<ComplectViewModel> list = _logicC.Read(null);
            if (list != null)
            {
                comboBoxComplect.DisplayMember = "ComplectName";
                comboBoxComplect.ValueMember = "Id";
                comboBoxComplect.DataSource = list;
                comboBoxComplect.SelectedItem = null;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            _logicZ.CreateOrUpdate(new ZakupkaBindingModel
            {
                SborkaId = Convert.ToInt32(comboBoxComplect.SelectedValue),
                DateBuy = Convert.ToDateTime(textBox1.Text)

            });
            MessageBox.Show("Сохранени прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
