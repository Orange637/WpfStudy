namespace WpfStudy.Bindings
{
    using WpfStudy.Model.Persons;

    /// <summary>
    /// Interaction logic for ValidateStudyView.xaml.
    /// </summary>
    public partial class ValidateStudyView
    {
        private PersonValidateInSetter personValidateInSetter;

        private PersonDerivedFromIDataErrorInfo personDerivedFromIDataErrorInfo;

        private Person person;

        private PersonUseDataAnnotation personUseDataAnnotation;

        public ValidateStudyView()
        {
            this.InitializeComponent();

            this.PersonValidateInSetter = new PersonValidateInSetter();

            this.PersonDerivedFromIDataErrorInfo = new PersonDerivedFromIDataErrorInfo();

            this.Person = new Person();

            this.PersonUseDataAnnotation = new PersonUseDataAnnotation();
        }

        public PersonValidateInSetter PersonValidateInSetter
        {
            get
            {
                return this.personValidateInSetter;
            }

            set
            {
                this.SetProperty(ref this.personValidateInSetter, value, () => this.PersonValidateInSetter);
            }
        }

        public PersonDerivedFromIDataErrorInfo PersonDerivedFromIDataErrorInfo
        {
            get
            {
                return this.personDerivedFromIDataErrorInfo;
            }

            set
            {
                this.SetProperty(ref this.personDerivedFromIDataErrorInfo, value, () => this.PersonDerivedFromIDataErrorInfo);
            }
        }

        public Person Person
        {
            get
            {
                return this.person;
            }

            set
            {
                this.SetProperty(ref this.person, value, () => this.Person);
            }
        }

        public PersonUseDataAnnotation PersonUseDataAnnotation
        {
            get
            {
                return this.personUseDataAnnotation;
            }

            set
            {
                this.SetProperty(ref this.personUseDataAnnotation, value, () => this.PersonUseDataAnnotation);
            }
        }
    }
}
