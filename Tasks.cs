using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba4
{
    internal class Tasks
    {
        public void Task1<T>()
        {
            Console.WriteLine("Сколько элементов будет содержать список?");
            int k = int.Parse(Console.ReadLine());
            try
            {
                List<T> list1 = Methods.MakeList<T>(Math.Abs(k));
                Console.WriteLine("Исходный список:");
                Methods.PrintList<T>(list1);
                Methods.Reverse(list1);
                Console.WriteLine("Перевернутый список:");
                Methods.PrintList<T>(list1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void Task2<T>()
        {
            Console.WriteLine("Сколько элементов будет содержать двусвязный список?");
            int k = int.Parse(Console.ReadLine());
            LinkedList<T> linked_list = Methods.MakeLinkedList<T>(Math.Abs(k));
            Console.WriteLine("Исходный список");
            Methods.PrintLinkedList<T>(linked_list);
            try
            {
                Console.WriteLine("Список со вставленными перед и после E элементами F:");
                Methods.InsertF(linked_list);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Task3<T>()
        {
            HashSet<T> all_disco = Methods.ListOfDisco<T>();
            Dictionary<string, HashSet<T>> students_disco = Methods.Students_Disco<T>();
            var all_visited = Methods.Disco_AllStudents<T>(students_disco);
            var somebody_visited = Methods.Disco_SomeStudents<T>(students_disco);
            var nobody_visited = Methods.Disco_NotVisited<T>(students_disco, all_disco);
            Console.WriteLine("\nДискотеки, на которые ходили все студенты группы:");
            foreach (var student in all_visited)
            {
                Console.WriteLine(student);
            }
            Console.WriteLine("\nДискотеки, на которые ходили некоторые студенты группы:");
            foreach (var student in somebody_visited)
            {
                Console.WriteLine(student);
            }
            Console.WriteLine("\nДискотеки, на которые не ходил ни один из студентов группы:");
            foreach (var student in nobody_visited)
            {
                Console.WriteLine(student);
            }
        }

        public void Task4<T>()
        {
            string FilePath = "task4.txt";
            try
            {
                Methods.FillTxtFile(FilePath);
                List<T> textFromFile = Methods.ReadTxtFile<T>(FilePath);
                HashSet<T> unique_symbols = Methods.Symbols(textFromFile);
                List<T> sorted_symbols = new List<T>(unique_symbols);
                sorted_symbols.Sort();
                Console.WriteLine("Символы, которые встречаются хотя бы однажды в словах с четными номерами, в алфавитном порядке:");
                foreach (T symb in sorted_symbols) { Console.Write(symb + " "); }
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Task5()
        {
            string filepath = "task5.xml";
            try
            {
                List<Abiturient> abituruents = Methods.ListOfAbiturients();
                Methods.FillXmlFile(filepath, abituruents);
                Dictionary<string, string> admittedStudents = Methods.AdmittedStudents(abituruents);
                Console.WriteLine("\nАбитуриенты, допущенные к сдаче экзаменов в первом потоке, отсортированные по фамилии в алфавитном порядке:");
                SortedDictionary<string, string> sort_admitted = new SortedDictionary<string, string>(admittedStudents);
                foreach (var admitted in sort_admitted)
                {
                    Console.WriteLine($"{admitted.Key} {admitted.Value}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
