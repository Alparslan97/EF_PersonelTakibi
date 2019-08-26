using MetroFramework.Forms;
using System;
using System.Linq;
using System.Windows.Forms;

namespace WFAPersonelTakibi
{
    using MetroFramework;
    using MetroFramework.Controls;
    using Models.Context;
    using Models.Entities;
    public partial class Form1 : MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        MyContext context = new MyContext();
        private void Form1_Load(object sender, EventArgs e)
        {
            cmbDepartment.DataSource = context.Departments.ToList();
            cmbDepartment.DisplayMember = "Name"; // kullanıcının göreceği alan, property adı ne ise, onu veriniz.
            cmbDepartment.ValueMember = "Id";     // her bir satırda, arka planda o değerin Id değerini tutar, property adı ne ise onu veriniz. 
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            employee.Mail = txtMail.Text;
            employee.Address = txtAddress.Text;
            employee.LastName = txtLastName.Text;
            employee.PhoneNumber = txtPhone.Text;
            employee.FirstName = txtFirstName.Text;
            employee.BirthDate = dtBirthDate.Value;

            foreach (MetroRadioButton radioButton in metroPanel1.Controls)
            {
                if (radioButton.Checked)
                {
                    employee.Gender = (Gender)Enum.Parse(typeof(Gender), radioButton.Text);
                }
            }
            employee.DepartmentId = (Guid)cmbDepartment.SelectedValue;
            context.Employees.Add(employee);
            bool result = context.SaveChanges() > 0;

            MetroMessageBox.Show(this, result ? "Kayıt Eklendi" : "İşlem Hatası", "Kayıt Ekleme Bildirimi", MessageBoxButtons.OK, result ? MessageBoxIcon.Information : MessageBoxIcon.Error);
        }
    }
}
