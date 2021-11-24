using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prakt_8._1
{
    interface IHuman
    {
        string Name { get; set; }
        string Surname { get; set; }
        string Patronymic { get; set; }
        int Age { get; set; }
    }
}
