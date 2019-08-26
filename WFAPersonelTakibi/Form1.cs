namespace WFAPersonelTakibi
{
    #region Usings
    using MetroFramework;
    using MetroFramework.Controls;
    using MetroFramework.Forms;
    using Models.Context;
    using Models.Entities;
    using System;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    #endregion

    public partial class Form1 : MetroForm
    {
        #region constructor
        public Form1()
        {
            InitializeComponent();
        }
        #endregion

        MyContext context = new MyContext();

        #region LoadEmployee
        void LoadEmployee()
        {
            txtAddress.Text = FakeData.PlaceData.GetAddress();
            txtFirstName.Text = FakeData.NameData.GetFirstName();
            txtLastName.Text = FakeData.NameData.GetSurname();
            txtMail.Text = FakeData.NetworkData.GetEmail().ToLower();
            txtPhone.Text = FakeData.PhoneNumberData.GetPhoneNumber();
            dtBirthDate.Value = FakeData.DateTimeData.GetDatetime();
        }
        #endregion

        #region Form Load
        private void Form1_Load(object sender, EventArgs e)
        {
            cmbDepartment.DataSource = context.Departments.ToList();
            cmbDepartment.DisplayMember = "Name"; // kullanıcının göreceği alan, property adı ne ise, onu veriniz.
            cmbDepartment.ValueMember = "Id";     // her bir satırda, arka planda o değerin Id değerini tutar, property adı ne ise onu veriniz. 
        }
        #endregion

        #region Save Employee


        Employee employee;

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (employee == null)
            {
                employee = new Employee();
            }

            if (!employee.HasImage)
            {
                MetroMessageBox.Show(this, "Lütfen bir resim seçiniz!", "Kayıt Bildirimi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            employee.Mail = txtMail.Text;
            employee.Address = txtAddress.Text;
            employee.LastName = txtLastName.Text;
            employee.PhoneNumber = txtPhone.Text;
            employee.FirstName = txtFirstName.Text;
            employee.BirthDate = dtBirthDate.Value;

            foreach (var radioButton in metroPanel1.Controls)
            {
                if (radioButton is MetroRadioButton)
                {
                    MetroRadioButton radio = (MetroRadioButton)radioButton;
                    if (radio.Checked)
                    {
                        employee.Gender = (Gender)Enum.Parse(typeof(Gender), radio.Text);
                    }
                }
            }

            employee.DepartmentId = (Guid)cmbDepartment.SelectedValue;
            context.Employees.Add(employee);
            bool result = context.SaveChanges() > 0;

            MetroMessageBox.Show(this, result ? "Kayıt Eklendi" : "İşlem Hatası", "Kayıt Ekleme Bildirimi", MessageBoxButtons.OK, result ? MessageBoxIcon.Information : MessageBoxIcon.Error);
        }
        #endregion

        private void PcbImageUrl_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "jpg files (*.jpg)|*.jpg|png files (*.png)|*.png";
            if (openFile.ShowDialog() == DialogResult.OK)
            {

                if (employee == null)
                {
                    employee = new Employee();
                }

                pcbImageUrl.Image = Image.FromFile(openFile.FileName);
                employee.ImageUrl = $"{Guid.NewGuid()}{System.IO.Path.GetExtension(openFile.FileName)}";
                pcbImageUrl.Image.Save($@"{Environment.CurrentDirectory}\..\..\Images\{employee.ImageUrl}");
                employee.HasImage = true;
            }
        }

        private void LnkPersonelOlustur_Click(object sender, EventArgs e)
        {
            LoadEmployee();
        }
    }
}