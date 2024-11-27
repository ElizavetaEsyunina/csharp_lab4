using Laba4;
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Введите номер задания");
        short num = short.Parse(Console.ReadLine());
        switch (num)
        {
            case 1:
                Console.WriteLine("Задание 1");
                Tasks t1 = new Tasks();
                t1.Task1<object>();
                break;
            case 2:
                Console.WriteLine("Задание 2");
                Tasks t2 = new Tasks();
                t2.Task2<object>();
                break;
            case 3:
                Console.WriteLine("Задание 3");
                Tasks t3 = new Tasks();
                t3.Task3<string>();
                break;
            case 4:
                Console.WriteLine("Задание 4");
                Tasks t4 = new Tasks();
                t4.Task4<string>();
                break;
            case 5:
                Console.WriteLine("Задание 5");
                Tasks t5 = new Tasks();
                t5.Task5();
                break;
            default:break;
        }
    }
}