namespace WpfStudy.Views
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Windows.Data;

    using WpfStudy.Model;

    /// <summary>
    /// Interaction logic for GridStudy.xaml.
    /// </summary>
    public partial class GridStudy
    {
        private List<Employee> employees;

        public GridStudy()
        {
            this.InitializeComponent();

            this.EmployeesView = CollectionViewSource.GetDefaultView(this.employees);
            this.NotifyPropretyChanged(() => this.Employees);
        }

        public ObservableCollection<Employee> Employees { get; set; }

        public ICollectionView EmployeesView { get; set; }

        public override void BeginInit()
        {
            base.BeginInit();

            this.employees = new List<Employee>
                                 {
                                     new Employee
                                         {
                                             Id = "abn",
                                             FirstName = "Andreas",
                                             LastName = "Boerngen",
                                             Birthday = new DateTime(1990, 5, 5),
                                             Mobile = "+86(186)62604413",
                                             CompanyTel = "+86(512)62994421",
                                             Email = "abn@mm-software.com",
                                             DepartmentId = 1,
                                             PhotoId = "abn2.jpg",
                                             JobTitleId = 1,
                                             Remark = "General Manager Of MM Suzhou."
                                         },
                                     new Employee
                                         {
                                             Id = "jzg",
                                             FirstName = "Jerry",
                                             LastName = "Zhang",
                                             Birthday = new DateTime(1990, 5, 5),
                                             Mobile = "18626273722",
                                             CompanyTel = "512-68075718-1005",
                                             Email = "jzg@mm-software.com",
                                             DepartmentId = 1,
                                             PhotoId = "jzg.jpg",
                                             JobTitleId = 2,
                                             Remark = "Technology manager of mm suzhou."
                                         },
                                     new Employee
                                         {
                                             Id = "ylu",
                                             FirstName = "Yanmei",
                                             LastName = "Lu",
                                             Birthday = new DateTime(1990, 5, 5),
                                             Mobile = "18662290678",
                                             CompanyTel = "512-68075718-1002",
                                             Email = "ylu@mm-software.com",
                                             DepartmentId = 1,
                                             PhotoId = "ylu.jpg",
                                             JobTitleId = 3,
                                             Remark = "Human Resource Manager and Administator."
                                         },
                                     new Employee
                                         {
                                             Id = "xwzhu",
                                             FirstName = "Xiangwen",
                                             LastName = "Zhu",
                                             Birthday = new DateTime(1990, 5, 5),
                                             Mobile = "15850195582",
                                             CompanyTel = "512-68075718-1055",
                                             Email = "xwzhu@mm-software.com",
                                             DepartmentId = 1,
                                             PhotoId = "xwzhu.jpg",
                                             JobTitleId = 4,
                                             Remark = "Vice Technology manager."
                                         },
                                     new Employee
                                         {
                                             Id = "yma",
                                             FirstName = "Yi",
                                             LastName = "Ma",
                                             Birthday = new DateTime(1990, 5, 5),
                                             Mobile = "18662290678",
                                             CompanyTel = "512-68075718-1002",
                                             Email = "yma@mm-software.com",
                                             DepartmentId = 1,
                                             PhotoId = "yma.jpg",
                                             JobTitleId = 5,
                                             Remark = "Group manager of offshore2."
                                         },
                                     new Employee
                                         {
                                             Id = "dcn",
                                             FirstName = "David",
                                             LastName = "Chen",
                                             Birthday = new DateTime(1990, 5, 5),
                                             Mobile = "18662290678",
                                             CompanyTel = "512-68075718-1002",
                                             Email = "dcn@mm-software.com",
                                             DepartmentId = 1,
                                             PhotoId = "dcn.jpg",
                                             JobTitleId = 5,
                                             Remark = "Group manager of Embedded and Offshore3."
                                         },
                                     new Employee
                                         {
                                             Id = "ssi",
                                             FirstName = "Steven",
                                             LastName = "Shi",
                                             Birthday = new DateTime(1990, 5, 5),
                                             DepartmentId = 9,
                                             Email = "ssi@mm-software.com",
                                             Mobile = "13812645004",
                                             PhotoId = "ssi.jpg",
                                             JobTitleId = 12,
                                             Remark = "mmcademy instructor"
                                         },
                                     new Employee
                                         {
                                             Id = "jcg",
                                             FirstName = "Johnson",
                                             LastName = "Cheng",
                                             Birthday = new DateTime(1990, 5, 5),
                                             DepartmentId = 9,
                                             Email = "jcg@mm-software.com",
                                             Mobile = "13812645004",
                                             PhotoId = "jcg.jpg",
                                             JobTitleId = 13,
                                             Remark = "2013 trainee"
                                         }
                                 };

            this.Employees = new ObservableCollection<Employee>(this.employees);
            this.NotifyPropretyChanged(() => this.Employees);
        }
    }
}
