using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePhoneBook
{
    public class PhoneInfo
    {
        string name;            //필수 // private
        string phoneNumber;     //필수
        string birth;           //선택

        public string Name { get { return name; } } // set안쓰이니 지우기

        public PhoneInfo(string name, string phoneNumber) // 필수인 부분만 넣어서 하나 만들기
        {
            this.name = name;
            this.phoneNumber = phoneNumber;
            this.birth = null;
        }

        public PhoneInfo(string name, string phoneNumber, string birth)
        {
            this.name = name;
            this.phoneNumber = phoneNumber;
            this.birth = birth;
        }

        public void ShowPhoneInfo() // 이 메서드를 안만들면 다른 클래스에서 get 할때 모든 prop를 만들어야함
        {
            Console.Write("name :" + this.name);
            Console.Write("\tphone :" + this.phoneNumber);
            Console.Write("\tbirth :" + this.birth+"\n");
        }



    }
}
