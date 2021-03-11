using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePhoneBook
{
    public class PhoneInfo : IComparable
    {
        string name;            // 필수 // private
        string phoneNumber;     // 필수
        string birth;           // 선택

        public string Name { get { return name; } set { name = value; } } // set안쓰이니 지우기
        public string PhoneNumber { get {return phoneNumber; } set { phoneNumber = value; } }
        public string Birth { get { return birth; } set { birth = value; } }

        public PhoneInfo()
        {
        }

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

        public override string ToString()
        {
            string birth_null = (string.IsNullOrEmpty(birth)) ? "나이 미상" : birth;
            return $"name : {name} \t phone:{phoneNumber} \t birth:{birth_null} \n";
        }

        /*
        public virtual void ShowPhoneInfo() // 이 메서드를 안만들면 다른 클래스에서 get 할때 모든 prop를 만들어야함
        {
            Console.Write("name :" + this.name);
            Console.Write("\tphone :" + this.phoneNumber);
            Console.Write("\tbirth :" + this.birth);
            Console.WriteLine();
        }
        */

        public virtual void AlterPhonInfo( string num, string value )
        {
            
            if (num == "1")
            {
                this.name = value;
            }
            else if (num == "2")
            {
                this.phoneNumber = value;
            }
            else if (num =="3")
            {
                this.birth = value;
            }
        }

        public virtual int CompareTo(object obj)
        {
            PhoneInfo other = (PhoneInfo)obj;
            return this.Name.CompareTo(other.Name); // 1->1, -1->-1
            
        }
    }


    public class PhoneUnivInfo : PhoneInfo

    {
        string major;
        int year;

        public PhoneUnivInfo(string name, string phoneNumber, string birth, string major, int year):base(name, phoneNumber, birth)
        {
            this.major = major;
            this.year = year;
        }

        public override string ToString()
        {
            return $"{base.ToString()}major: {major}\tyear: {year}\n";
        }


        /*
        public override void ShowPhoneInfo()
        {
            base.ShowPhoneInfo();
            Console.Write("\tmajor: " + this.major);
            Console.Write("\tyear: " + this.year);
            Console.WriteLine();
        }
        */
        public override void AlterPhonInfo(string num, string value)
        {

            base.AlterPhonInfo( num, value);
            if (num == "4")
            {
                this.major = value;
            }
            else if (num == "5")
            {
                bool isNum = int.TryParse(value, out this.year);
                if (!isNum)
                {
                    return;
                }
            }
        }

        public override int CompareTo(object obj)
        {
            PhoneUnivInfo other = (PhoneUnivInfo)obj;
            return this.Name.CompareTo(other);
        }
    }

    public class PhoneCompanyInfo : PhoneInfo
    {
        string company;

        public PhoneCompanyInfo(string name, string phoneNumber, string birth, string company):base(name, phoneNumber, birth)
        {
            this.company = company;
        }

        public override string ToString()
        {
            return $"{base.ToString()}company: {company}\n";
        }


        /*
        public override void ShowPhoneInfo()
        {
            base.ShowPhoneInfo();
            Console.Write("\tcompany: " + this.company);
            Console.WriteLine();
        }
        */
        public override void AlterPhonInfo(string num, string value)
        {
            base.AlterPhonInfo(num, value);
            if (num == "4")
            {
                this.company = value;
            }
        }

        public override int CompareTo(object obj)
        {
            PhoneCompanyInfo other = (PhoneCompanyInfo)obj;
            return this.Name.CompareTo(other);
        }
    }
}
