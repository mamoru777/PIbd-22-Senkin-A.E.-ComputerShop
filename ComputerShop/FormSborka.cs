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
using ComputerShopContracts.ViewModels;
using ComputerShopView.Programs;
using Unity;


namespace ComputerShopView
{
    public partial class FormSborka : Form  
    {
        public int Id { set { Id = value; } }
        private readonly ISborkaLogic _logic;
        private int? id;
        private Dictionary<int, (string, int)> sborkaComplect;
        public FormSborka(ISborkaLogic logic)
        {
            InitializeComponent();
            _logic = logic;
        }

        private void FormSborka_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    SborkaViewModel view = _logic.Read(new SborkaBindingModel { Id = id.Value })?[0];
                    if (view != null)
                    {
                        textBoxName.Text = view.SborkaName;
                        sborkaComplect = view.SborkaComplect;
                        textBoxSum.Text = view.Sum.ToString();
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                sborkaComplect = new Dictionary<int, (string, int)>();
            }
        }

        private void LoadData()
        {
            try
            {
                if (sborkaComplect != null)
                {
                    dataGridView.Rows.Clear();
                    foreach(var pc in sborkaComplect)
                    {
                        dataGridView.Rows.Add(new object[] { pc.Key, pc.Value.Item1, pc.Value.Item2 });
                        SumCalc();
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SumCalc()
        {
            if (dataGridView.RowCount != 0)
            {
                int sum = 0;
                foreach (var row in sborkaComplect)
                {
                    sum += row.Value.Item2;
                }

                textBoxSum.Text = sum.ToString();
                //SborkaBindingModel model = new SborkaBindingModel({ Id = id.Value });
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormSborkaComplect>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (sborkaComplect.ContainsKey(form.Id))
                {
                    sborkaComplect[form.Id] = (form.ComplectName, form.Price);
                }
                else
                {
                    sborkaComplect.Add(form.Id, (form.ComplectName, form.Price));
                }
                LoadData();
            }
        }

        private void buttonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = Program.Container.Resolve<FormSborkaComplect>();
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                form.Id = id;
                form.Price = sborkaComplect[id].Item2;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    sborkaComplect[form.Id] = (form.ComplectName, form.Price);
                    LoadData();
                }
            }
        }
        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        sborkaComplect.Remove(Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void buttonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (sborkaComplect == null || sborkaComplect.Count == 0)
            {
                MessageBox.Show("Заполните компоненты", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                _logic.CreateOrUpdate(new SborkaBindingModel
                {
                    Id = id,
                    SborkaName = textBoxName.Text,
                    Sum = Convert.ToInt32(textBoxSum.Text),
                    SborkaComplect = sborkaComplect
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
