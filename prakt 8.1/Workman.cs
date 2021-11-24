using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prakt_8._1
{
    class Workman : IHuman, IComparable, ICloneable
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public int Age { get; set; }
        public string Position { get; set; }
        public Workman(string initName, string initSurname, string initPatronymic, int initAge, string initPosition)
        {
            Name = initName;
            Surname = initSurname;
            Patronymic = initPatronymic;
            Age = initAge;
            Position = initPosition;
        }
        public string EmployeeInformation()
        {
            string info = $" Фамилия: {Surname} \n Имя: {Name} \n Отчество: {Patronymic} \n Возраст: {Age} \n Должность: {Position} \n Кол-во детей: 0";
            return info;
        }
        public Workman WorkmanClone()
        {
            return (Workman)this.MemberwiseClone();
        }
        public object Clone()
        {
            Workman workman = new Workman(this.Name, this.Surname, this.Patronymic, this.Age, this.Position);
            return workman;
        }
        public int CompareTo(object obj)
        {
            IHuman workman = (IHuman)obj;
            if (this.Surname.Length > workman.Surname.Length) return 1;
            if (this.Surname.Length < workman.Surname.Length) return -1;
            return 0;
        }
    }
}
