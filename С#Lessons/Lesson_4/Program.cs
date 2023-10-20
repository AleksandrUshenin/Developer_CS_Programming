namespace Lesson_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person0 = new Person("God", Gender.Man, null, null);
            Person person1 = new Person("Adam", Gender.Man, null, person0);
            Person person2 = new Person("Eva", Gender.Woman, null, person0);
            Person person3 = new Person("Test", Gender.Woman, person2, person1);

            Console.WriteLine(new String('-', 20));
            Console.WriteLine(person0);
            Console.WriteLine(person1);
            Console.WriteLine(person2);
            Console.WriteLine(person3);
            person1.PrintParants();
            person2.PrintParants();
            Famaly.Widing(person1, person2);
            person1.Children.Add(person3);
            person1.Children.Print();
            person2.Children.Print();
            Console.WriteLine(new String('-', 20));

            //Console.ReadLine();
        }
    }
}