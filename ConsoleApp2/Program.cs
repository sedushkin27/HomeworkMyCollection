namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyCollection myCollection = new MyCollection();
            myCollection.Add(43);
            myCollection.Add(3);
            myCollection.Add(54);

            foreach (var item in myCollection)
            {
                Console.WriteLine(item);
            }
        }
    }
}