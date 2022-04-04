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
using ComputerShopView.Programs;
using Unity;

namespace ComputerShopView
{
    public partial class FormGlav : Form
    {
        public FormGlav()
        {
            InitializeComponent();
        }
        private void buttonComplects_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormComplects>();
            form.ShowDialog();
        }
        private void buttonSborkas_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormSborkas>();
            form.ShowDialog();
        }

        private void buttonZakupkas_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormZakupkas>();
            form.ShowDialog();
        }

        private void buttonGetSpisok_Click(object sender, EventArgs e)
        {
            /*Код для получения списка*/
        }

        private void buttonOtchet_Click(object sender, EventArgs e)
        {
            /*Код для отчета*/
        }
    }
}
