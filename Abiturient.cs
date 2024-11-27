using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba4
{
    [Serializable]
    public class Abiturient
    {
        private string surname;
        private string name;
        private int res1;
        private int res2;
        private int res3;

        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Res1
        {
            get { return res1; }
            set { res1 = value; }
        }

        public int Res2
        {
            get { return res2; }
            set { res2 = value; }
        }

        public int Res3
        {
            get { return res3; }
            set { res3 = value; }
        }
        public Abiturient() { }
        public Abiturient(string surname, string name, int res1, int res2, int res3)
        {
            this.surname = surname;
            this.name = name;
            this.res1 = res1;
            this.res2 = res2;
            this.res3 = res3;
        }
    }
}
