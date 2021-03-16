using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePhoneBook
{
    public class MenuChoiceException : Exception
    {
        public MenuChoiceException() : base("다시 메뉴를 선택하여 주십시오") { }

        public MenuChoiceException(string message) : base(message)  {     }
        
    }
}
