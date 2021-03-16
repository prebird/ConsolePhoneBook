using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePhoneBook
{
    class Program
    {
        static void Main(string[] args)
        {
            PhoneBookManager manager = PhoneBookManager.CreateManagerInstance();

            while(true)
            {
                try
                {
                    manager.ShowMenu();
                    int choice = int.Parse(Console.ReadLine());  
                    if (choice < 1 || choice > 6)
                    {
                        throw new MenuChoiceException("1~6번 사이의 메뉴를 선택하세요.");
                        //throw new Exception("1~6번 사이의 메뉴를 선택하세요.");
                    }
                    switch(choice)
                    {
                        case 1: manager.InputData(); break;
                        case 2: manager.ListData(); break;
                        case 3: manager.SearchData(); break;
                        case 4: manager.SortData(); break;
                        case 5: manager.DeleteData(); break;
                        case 6: Console.WriteLine("프로그램을 종료합니다."); return;
                    }
                }
                catch(Exception err)
                {
                    Console.WriteLine("오류발생 - " + err.Message);
                }
            }
        }
    }
}
