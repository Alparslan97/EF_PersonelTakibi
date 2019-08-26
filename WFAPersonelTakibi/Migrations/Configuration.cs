namespace WFAPersonelTakibi.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<WFAPersonelTakibi.Models.Context.MyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(WFAPersonelTakibi.Models.Context.MyContext context)
        {
            string[] departmanlar = { "Yazılım","Sistem","Grafik","Dijital Pazarlama","3D Görselleştirme"};

            for (int i = 0; i < departmanlar.Length; i++)
            {
                Models.Entities.Department department = new Models.Entities.Department();
                department.Name = departmanlar[i];
                context.Departments.Add(department);
                context.SaveChanges();
            }
        }
    }
}
