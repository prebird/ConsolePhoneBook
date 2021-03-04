using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePhoneBook
{
    class CompanyPhoneInfo : PhoneInfo
    {
        string companyId;
        string department;

        public CompanyPhoneInfo(string name, string phonNumber)
        {
            base.Name = name;
            base.PhoneNumber = phonNumber;
        }

        public CompanyPhoneInfo(string name, string phonNumber, string birth)
        {
            base.Name = name;
            base.PhoneNumber = phonNumber;
            base.Birth = birth;
        }

        public CompanyPhoneInfo(string name, string phonNumber, string birth ,string companyId)
        {
            base.Name = name;
            base.PhoneNumber = phonNumber;
            base.Birth = birth;
            this.companyId = companyId;
        }

        public CompanyPhoneInfo(string name, string phonNumber, string birth, string id, string depart)
        {
            base.Name = name;
            base.PhoneNumber = phonNumber;
            base.Birth = birth;
            this.companyId = id;
            this.department = depart;
        }

        public void ShowPhoneInfo() // 이 메서드를 안만들면 다른 클래스에서 get 할때 모든 prop를 만들어야함
        {
            Console.WriteLine("구분: 회사");
            Console.Write("name :" + base.Name);
            Console.Write("\tphone :" + base.PhoneNumber);
            Console.Write("\tbirth :" + base.Birth);
            Console.WriteLine("사번 :" + this.companyId);
            Console.Write("부서 :" + this.department);
            Console.WriteLine();
        }


    }
}
