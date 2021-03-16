using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePhoneBook
{
    class PhoneComparator : IComparer<PhoneInfo>
    {
        public int Compare(PhoneInfo x, PhoneInfo y)
        {
            PhoneInfo first = x;
            PhoneInfo second = y;

            return first.Phone.CompareTo(second.Phone);
        }
    }

    class NameComparator : IComparer<PhoneInfo>
    {
        public int Compare(PhoneInfo x, PhoneInfo y)
        {
            PhoneInfo first = x;
            PhoneInfo second = y;

            return first.Name.CompareTo(second.Name);
        }

        
    }
}
