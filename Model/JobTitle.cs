// --------------------------------------------------------------------------------------------------------------------
// <copyright file="JobTitle.cs" company="mm-software">
//   mm-software
// </copyright>
// <summary>
//   The job title.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WpfStudy.Model
{
    using WpfStudy.Infrastructure;

    public class JobTitle : ObservableObject
    {
        private int id;

        private string name;

        private string description;

        public int Id
        {
            get { return this.id; }
            set { this.SetProperty(ref this.id, value, () => this.Id); }
        }

        public string Name
        {
            get { return this.name; }
            set { this.SetProperty(ref this.name, value, () => this.Name); }
        }

        public string Description
        {
            get { return this.description; }
            set { this.SetProperty(ref this.description, value, () => this.Description); }
        }

        public void Copy(JobTitle jobTitle)
        {
            if (this.name == null || !this.name.Equals(jobTitle.name))
            {
                this.Name = jobTitle.name;
            }

            if (this.description == null || !this.description.Equals(jobTitle.description))
            {
                this.Description = jobTitle.description;
            }
        }
    }
}