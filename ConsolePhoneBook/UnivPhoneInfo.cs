using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePhoneBook
{
    class UnivPhoneInfo : PhoneInfo
    {
        string univId;
        string major;

        public UnivPhoneInfo(string name, string phonNumber)
        {
            base.Name = name;
            base.PhoneNumber = phonNumber;
        }

        public UnivPhoneInfo(string name, string phonNumber, string birth)
        {
            base.Name = name;
            base.PhoneNumber = phonNumber;
            base.Birth = birth;
        }

        public UnivPhoneInfo(string name, string phonNumber, string birth , string univId)
        {
            base.Name = name;
            base.PhoneNumber = phonNumber;
            base.Birth = birth;
            this.univId = univId;
        }

        public UnivPhoneInfo(string name, string phonNumber, string birth, string univId, string major)
        {
            base.Name = name;
            base.PhoneNumber = phonNumber;
            base.Birth = birth;
            this.univId = univId;
            this.major = major;
        }

        public void ShowPhoneInfo() // 이 메서드를 안만들면 다른 클래스에서 get 할때 모든 prop를 만들어야함
        {
            Console.WriteLine("구분: 대학");
            Console.Write("name :" + base.Name);
            Console.Write("\tphone :" + base.PhoneNumber);
            Console.Write("\tbirth :" + base.Birth);
            Console.WriteLine("학번 :" + this.univId);
            Console.Write("전공 :" + this.major);
            Console.WriteLine();
        }
    }
}
