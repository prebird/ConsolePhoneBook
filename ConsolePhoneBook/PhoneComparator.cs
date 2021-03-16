using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePhoneBook
{
    class PhoneComparator : IComparer
    {
        public int Compare(object x, object y)
        {
            PhoneInfo first = (PhoneInfo)x;
            PhoneInfo second = (PhoneInfo)y;

            return first.Phone.CompareTo(second.Phone);
        }
    }

    class NameComparator : IComparer
    {
        public int Compare(object x, object y)
        {
            PhoneInfo first = (PhoneInfo)x;
            PhoneInfo second = (PhoneInfo)y;

            return first.Name.CompareTo(second.Name);
        }
    }
}
