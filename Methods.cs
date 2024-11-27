using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Laba4
{
    internal class Methods
    {
        //задание 1
        //метод для создания списка
        public static List<T> MakeList<T>(int k)
        {
            List<T> list = new List<T>();
            Console.WriteLine("Введите " + k + " элементов списка");
            for (int i = 0; i < k; i++)
            {
                T input = (T)Convert.ChangeType(Console.ReadLine(), typeof(T));
                list.Add(input);
            }
            return list;
        }
        //метод для переворота списка
        public static void Reverse<T>(List<T> list)
        {
            if (list.Count == 0 || list.Count == 1)
            {
                throw new Exception("Для переворота списка недостаточно элементов");
            }
            int left_index = 0;
            int right_index = list.Count - 1;
            //переворачиваем список меняя местами элементы
            while (left_index < right_index)
            {
                Swap(list, left_index, right_index);
                left_index++;
                right_index--;
            }
        }
        //вспомогательный метод для переворота списка
        private static void Swap<T>(List<T> list, int index1, int index2)
        {
            T temp = list[index1];
            list[index1] = list[index2];
            list[index2] = temp;
        }        
        //метод для вывода списка
        public static void PrintList<T>(List<T> list)
        {
            if (list.Count == 0)
            {
                throw new Exception("Список пуст");
            }
            foreach (T item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        //задание 2
        //метод для создания двусвязного списка
        public static LinkedList<T> MakeLinkedList<T>(int k)
        {
            LinkedList<T> list = new LinkedList<T>();
            Console.WriteLine("Введите " + k + " элементов списка");
            for (int i = 0; i < k; i++)
            {
                T input = (T)Convert.ChangeType(Console.ReadLine(), typeof(T));
                list.AddLast(input);
            }
            return list;
        }
        //метод для вставки справа и слева от элемента E элемента F
        public static void InsertF<T>(LinkedList<T> list)
        {
            if (!list.Contains((T)Convert.ChangeType("E", typeof(T))))
            {
                throw new Exception("В списке нет ни одного элемента 'E'");
            }
            LinkedList<T> new_list = new LinkedList<T>();
            foreach (T item in list)
            {
                if (!item.Equals("E"))
                {
                    new_list.AddLast(item);
                }
                else
                {
                    new_list.AddLast((T)Convert.ChangeType("F", typeof(T)));
                    new_list.AddLast(item);
                    new_list.AddLast((T)Convert.ChangeType("F", typeof(T)));
                }
            }
            foreach(T item in new_list)
            {
                Console.Write(item + " ");
            }
        }
        //метод для вывода двусвязного списка
        public static void PrintLinkedList<T>(LinkedList<T> list)
        {
            if (list.Count == 0)
            {
                throw new Exception("Список пуст");
            }
            foreach (T item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        //задание 3
        //метод для создания списка дискотек
        public static HashSet<T> ListOfDisco<T>()
        {
            HashSet<T> AllDiscos = new HashSet<T>
            {
                (T)Convert.ChangeType("I_SayDisco", typeof(T)),
                (T)Convert.ChangeType("YouSayParty", typeof(T)),
                (T)Convert.ChangeType("DiscoDisco", typeof(T)),
                (T)Convert.ChangeType("PartyParty", typeof(T)),
                (T)Convert.ChangeType("Дискотека 60+", typeof(T)),
                (T)Convert.ChangeType("SuperParty", typeof(T)),
                (T)Convert.ChangeType("Дискотека века", typeof(T))
            };
            Console.WriteLine("Все дискотеки:");
            foreach (var disco_name in AllDiscos)
            {
                Console.WriteLine(disco_name);
            }
            return AllDiscos;
        }
        public static Dictionary<string, HashSet<T>> Students_Disco<T>()
        {
            //словарь студенты - посещенные дискотеки
            Dictionary<string, HashSet<T>> students_disco = new Dictionary<string, HashSet<T>>()
            {
                {"Иванов И.И", new HashSet<T>{
                    (T)Convert.ChangeType("I_SayDisco", typeof(T)),
                    (T)Convert.ChangeType("YouSayParty", typeof(T)),
                    (T)Convert.ChangeType("PartyParty", typeof(T))
                } },
                {"Смагин М.В", new HashSet<T>
                {
                    (T)Convert.ChangeType("I_SayDisco", typeof(T)),
                    (T)Convert.ChangeType("YouSayParty", typeof(T)),
                    (T)Convert.ChangeType("PartyParty", typeof(T)),
                    (T)Convert.ChangeType("SuperParty", typeof(T)),
                } },
                {"Сюзева А.И", new HashSet<T>{
                    (T)Convert.ChangeType("I_SayDisco", typeof(T))
                } },
                {"Аверин А.Д", new HashSet<T>{
                    (T)Convert.ChangeType("I_SayDisco", typeof(T)),
                    (T)Convert.ChangeType("PartyParty", typeof(T))
                } },
                {"Смирнова И.С", new HashSet<T>{
                    (T)Convert.ChangeType("I_SayDisco", typeof(T)),
                    (T)Convert.ChangeType("PartyParty", typeof(T))
                } }
            };
            Console.WriteLine("\nCтуденты и посещенные дискотеки");
            foreach (var student in students_disco)
            {
                Console.WriteLine($"{ student.Key }: {string.Join(", ", student.Value)}");
            }
            return students_disco;
        }

        //метод для получения дискотек, которые посетили все студенты
        public static HashSet<T> Disco_AllStudents<T>(Dictionary<string, HashSet<T>> students)
        {
            //проверкка есть ли вообще студенты в словаре
            if (students.Count == 0) return new HashSet<T>();
            HashSet<T> result = new HashSet<T>(students.Values.First());
            //проходим по всем значениям в словаре
            foreach (var disco in students.Values)
            {
                result.IntersectWith(disco);
            }
            return result;
        }

        //метод для получения дискотек, на которые ходили некоторые студенты группы
        public static HashSet<T> Disco_SomeStudents<T>(Dictionary<string, HashSet<T>> students)
        {
            if (students.Count == 0) return new HashSet<T>();
            HashSet<T> result = new HashSet<T>(students.Values.First());
            foreach (var disco in students.Values)
            {
                result.UnionWith(disco);
            }
            return result;
        }

        //метод для получения дискотек, которые не были никем посещены
        public static HashSet<T> Disco_NotVisited<T>(Dictionary<string, HashSet<T>> students, HashSet<T> all_disco)
        {
            if (students.Count == 0) return new HashSet<T>();
            HashSet<T> visited_disco = Disco_SomeStudents(students);
            HashSet<T> result = new HashSet<T>(all_disco);
            result.ExceptWith(visited_disco);
            return result;
        }

        //задание 4
        //метод для заполнения файла текстом
        public static void FillTxtFile(string FilePath)
        {
            Console.WriteLine("Введите текст, который будет записан в файл");
            using (StreamWriter writer = new StreamWriter(File.Open(FilePath, FileMode.Create)))
            {
                writer.WriteLine(Console.ReadLine());
            }
            Console.WriteLine("Данные успешно записаны в файл\n");
        }
        //метод для считывания текста из файла
        public static List<T> ReadTxtFile<T> (string FilePath)
        {
            List<T> words = new List<T>();
            using (StreamReader reader = new StreamReader(File.Open(FilePath, FileMode.Open)))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    string[] WordsInLine = line.Split(new[] { ' ', ',', '.', '!', '?', '-' }, StringSplitOptions.RemoveEmptyEntries); // разбиваем слова в строке
                    foreach (string word in WordsInLine)
                    {
                        words.Add((T)Convert.ChangeType(word, typeof(T)));
                    }
                    line = reader.ReadLine();
                }
            }
            Console.WriteLine("Содержимое файла:");
            foreach (T word in words) { Console.WriteLine(word); }
            Console.WriteLine();
            return words;
        }
        public static HashSet<T> Symbols<T>(List<T> words)
        {
            if (words.Count == 0) throw new Exception("Файл пустой");
            if (words.Count == 1) throw new Exception("В файле нет слов с нечетными номерами");
            List<T> words_withEvenNumbers = new List<T>();
            HashSet<T> all_unique_symbols = new HashSet<T>(); // для сохранения всех уникальных символов из слов с четными номерами
            for (int i = 1; i <= words.Count; i+=2)
            {
                words_withEvenNumbers.Add(words[i]);
                string word = words[i].ToString();
                foreach(char symbol in word)
                {
                    all_unique_symbols.Add((T)Convert.ChangeType(symbol, typeof(T)));
                }
            }
            Console.WriteLine("\nСписок слов с четными номерами:");
            foreach (T word in words_withEvenNumbers) { Console.WriteLine(word); }
            Console.WriteLine("\nВсе символы, которые встречаются хотя бы однажды в словах с четными номерами");
            foreach (T symb in all_unique_symbols) { Console.Write(symb + " "); }
            Console.WriteLine();
            return all_unique_symbols;
        }

        //задание 5
        public static List<Abiturient> ListOfAbiturients()
        {
            Console.WriteLine("Введите количество абитуриентов, принимавших участие в тестировании");
            int N = int.Parse(Console.ReadLine());
            if (N > 500) throw new Exception("Общее количество участников тестирования не должно превосходить 500");
            List<Abiturient> abiturients = new List<Abiturient>(); //список для хранения всех абитуриентов
            for (int i = 1; i <= N; i++)
            {
                Console.WriteLine("\nВведите данные о студенте " + i + " (фамилия, имя, баллы за каждый из трех экзаменов)");
                string surname = Console.ReadLine();
                string name = Console.ReadLine();
                int res1 = int.Parse(Console.ReadLine());
                int res2 = int.Parse(Console.ReadLine());
                int res3 = int.Parse(Console.ReadLine());
                if (surname.Length > 20) throw new Exception("Фамилия не должна содержать больше 20 символов");
                if (name.Length > 15) throw new Exception("Имя не должно содержать больше 15 символов");
                if (res1 < 0 || res1 > 100 || res2 < 0 || res2 > 100 || res3 < 0 || res3 > 100) throw new Exception("Значения баллов должны лежать в пределах от 0 до 100");
                Abiturient new_abiturient = new Abiturient(surname, name, res1, res2, res3); // создали нового абитуриента
                abiturients.Add(new_abiturient); // добавили его в список абитуры
            }
            return abiturients;
        }
        public static void FillXmlFile(string FilePath, List<Abiturient> abiturients)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Abiturient>));
            using (FileStream stream = new FileStream(FilePath, FileMode.Create))
            {
                serializer.Serialize(stream, abiturients);
            }
            Console.WriteLine("Данные успешно записаны в xml файл");
        }

        public static Dictionary<string, string> AdmittedStudents(List<Abiturient> abiturients)
        {
            Dictionary<string, string> admidtted = new Dictionary<string, string>(); // словарь для сохранения данных о студентах, допущенных к к сдаче в первом потоке
            foreach (var abiturient in abiturients)
            {
                if (abiturient.Res1 >= 30 && abiturient.Res2 >= 30 && abiturient.Res3 >= 30 && (abiturient.Res1 + abiturient.Res2 + abiturient.Res3 >= 140))
                    admidtted.Add(abiturient.Surname, abiturient.Name);
            }
            return admidtted;
        }
    }
}
