namespace _04_TaskReturnValue
{
    class Student
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public double Rate { get; set; }

        public Student(string firstname, string lastname, double rate)
        {
            Firstname = firstname;
            Lastname = lastname;
            Rate = rate;
        }

        public override string ToString()
        {
            return $"Firstname: {Firstname} \nLastname: {Lastname} \nRate: {Rate}";
        }
    }
}
