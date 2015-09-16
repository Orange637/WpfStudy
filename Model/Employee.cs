// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Employee.cs" company="mm-software">
//   mm-software
// </copyright>
// <summary>
//   The employee.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace WpfStudy.Model
{
    using System;

    using Contacts.Model.Entity;

    using WpfStudy.Infrastructure;

    public class Employee : ObservableObject
    {
        private string id;

        private string firstName;

        private string lastName;

        private DateTime? birthday;

        private string mobile;

        private string email;

        private string companyTel;

        private WorkStatus status;

        private string photoId;

        private int departmentId;

        private int jobTitleId;

        private string remark;

        public Employee()
        {
            this.status = WorkStatus.Normal;
        }

        public string Email
        {
            get
            {
                return this.email;
            }

            set
            {
                this.SetProperty(ref this.email, value, () => this.Email);
            }
        }

        public WorkStatus Status
        {
            get { return this.status; }
            set { this.SetProperty(ref this.status, value, () => this.Status); }
        }

        public int JobTitleId
        {
            get
            {
                return this.jobTitleId;
            }

            set
            {
                this.SetProperty(ref this.jobTitleId, value, () => this.JobTitleId);
            }
        }

        public string Remark
        {
            get { return this.remark; }
            set { this.SetProperty(ref this.remark, value, () => this.Remark); }
        }


        public string Id
        {
            get
            {
                return this.id;
            }

            set
            {
                this.SetProperty(ref this.id, value, () => this.Id);
            }
        }

        public DateTime? Birthday
        {
            get { return this.birthday; }
            set { this.SetProperty(ref this.birthday, value, () => this.Birthday); }
        }

        public string CompanyTel
        {
            get
            {
                return this.companyTel;
            }
            
            set
            {
                this.SetProperty(ref this.companyTel, value, () => this.CompanyTel);
            }
        }

        public string Mobile
        {
            get
            {
                return this.mobile;
            }

            set
            {
                this.SetProperty(ref this.mobile, value, () => this.Mobile);
            }
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                this.SetProperty(ref this.firstName, value, () => this.FirstName);
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                this.SetProperty(ref this.lastName, value, () => this.LastName);
            }
        }

        public string PhotoId
        {
            get
            {
                return this.photoId;
            }

            set
            {
                this.SetProperty(ref this.photoId, value, () => this.PhotoId);

                // this.OnPropertyChanged(() => this.Photo);
            }
        }

        public int DepartmentId
        {
            get { return this.departmentId; }
            set { this.SetProperty(ref this.departmentId, value, () => this.DepartmentId); }
        }
    }
}