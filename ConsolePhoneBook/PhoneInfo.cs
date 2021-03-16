using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePhoneBook
{
    public class PhoneInfo //:IComparable
    {
        string name;        //필수
        string phoneNumber; //필수
        string birth;       //선택

        public string Name { get { return name; } }
        public string Phone { get { return phoneNumber; } }

        public PhoneInfo(string name, string phoneNumber)
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

        public virtual void ShowPhoneInfo()
        {
            Console.Write("name: " + this.name);
            Console.Write("\tphone: " + this.phoneNumber);
            Console.Write("\tbirth: " + this.birth);
            //Console.WriteLine();
        }

        public int CompareTo(object obj)
        {
            PhoneInfo other = (PhoneInfo)obj;
            return this.name.CompareTo(other.name);
        }

        public override string ToString()
        {
            string birth_null = birth == null ? "나이미상" : birth;
            return $"이름:{name}, 전번:{phoneNumber}, 생일;{birth_null}";
        }

        public override bool Equals(object obj)
        {
            PhoneInfo input = (PhoneInfo)obj;
            if (this.name == input.name)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return EqualityComparer<string>.Default.GetHashCode(Name);
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

        public override void ShowPhoneInfo()
        {
            base.ShowPhoneInfo();
            Console.Write("\tmajor: " + this.major);
            Console.Write("\tyear: " + this.year);
        }

        public override string ToString()
        {
            base.ShowPhoneInfo();
            return $"\nmajor:{major} year:{year}";
        }
    }

    public class PhoneCompanyInfo : PhoneInfo
    {
        string company;

        public PhoneCompanyInfo(string name, string phoneNumber, string birth, string company):base(name, phoneNumber, birth)
        {
            this.company = company;
        }

        public override void ShowPhoneInfo()
        {
            base.ShowPhoneInfo();
            Console.Write("\tcompany: " + this.company);
        }

        public override string ToString()
        {
            base.ShowPhoneInfo();
            return $"\tcompany:{company}";
        }
    }
}
