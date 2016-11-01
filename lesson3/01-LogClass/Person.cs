using System;
using System.ComponentModel;
using System.Threading;

namespace _01_LogClass
{
    class Person : INotifyPropertyChanged
    {
        string firstname;
        string lastname;
        DateTime birthday;

        public string Firstname
        {
            get { return firstname; }
            set
            {
                firstname = value;
                OnPropertyChanged("Firstname");
            }
        }

        public string Lastname
        {
            get { return firstname; }
            set
            {
                lastname = value;
                OnPropertyChanged("Lastname");
            }
        }

        public DateTime Birthday
        {
            get { return birthday; }
            set
            {
                birthday = value;
                OnPropertyChanged("Birthday");
            }
        }

        public Person()
        {
            PropertyChanged += Person_PropertyChanged;
        }

        private void Person_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Console.WriteLine("{0} propertie has been changed.", e.PropertyName);
            Log log = new Log(e.PropertyName.ToString(), "person.log");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if(handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
