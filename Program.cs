namespace lab_2
{
    internal class Program
    {
        class Singleton
        {
            private static Singleton? instance;
            private Singleton() { }
            public static Singleton getInstance()
            {
                if (instance == null)
                    instance = new Singleton();
                return instance;
            }
        }

        static void Main(string[] args) {}
    }
}
