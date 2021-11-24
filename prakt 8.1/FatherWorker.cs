using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prakt_8._1
{
    class FatherWorker : IHuman, IComparable, ICloneable
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public int Age { get; set; }
        public int Children { get; set; }
        public string Position { get; set; }
        public FatherWorker(string initName, string initSurname, string initPatronymic, int initChildren, int initAge, string initPosition)
        {
            Name = initName;
            Surname = initSurname;
            Patronymic = initPatronymic;
            Age = initAge;
            Children = initChildren;
            Position = initPosition;
        }
        public string EmployeeInformation()
        {
            string info = $" Фамилия: {Surname} \n Имя: {Name} \n Отчество: {Patronymic} \n Возраст: {Age} \n Должность: {Position} \n Кол-во детей: {Children}";
            return info;
        }
        public FatherWorker WatherWorkerClone()
        {
            return (FatherWorker)this.MemberwiseClone();
        }
        public object Clone()
        {
            FatherWorker father = new FatherWorker(this.Name, this.Surname, this.Patronymic, this.Children, this.Age, this.Position);
            return father;
        }
        public int CompareTo(object obj)
        {
            IHuman father = (IHuman)obj;
            if (this.Surname.Length > father.Surname.Length) return 1;
            if (this.Surname.Length < father.Surname.Length) return -1;
            return 0;
        }
    }
}
