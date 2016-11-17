namespace LessonReflection
{
    class TestType
    {
        int res;
        public int a;
        public int b;

        public int Res
        {
            get { return res; }
            set { res = value; }
        }

        public int Calc()
        {
            return a + b;
        }
    }
}
