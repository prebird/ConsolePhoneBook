using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsolePhoneBook
{
    class Programs
    {
        static void Main(string[] args)
        {
            PhoneBookManager manager = new PhoneBookManager();

            while (true)
            {
                manager.ShowMenu();
                int choice = int.Parse(Console.ReadLine());
                

                switch(choice)
                {
                    case 1: //manager.InputData(); break;
                        manager.ShowSelectMenu();
                        int choice2 = int.Parse(Console.ReadLine());
                        bool bFlag = true;
                        while (bFlag)
                        {
                            switch (choice2)
                            {
                                case 1:          // 일반
                                    manager.InputData();
                                    bFlag = false;
                                    break;
                                case 2:          //대학
                                    manager.InputUnivData();
                                    bFlag = false;
                                    break;
                                case 3:          //회사
                                    manager.InputCompanyData();
                                    bFlag = false;
                                    break;
                                default:         //다시선택
                                    Console.WriteLine("다시 선택하시오");
                                    break;
                            } 
                        }
                        break;
                    case 2: manager.ListData(); break;
                    case 3: manager.SearchData(); break;
                    case 4: manager.DeleteData(); break;
                    case 5:
                        Console.WriteLine("프로그램을 종료합니다.");
                        return; // 반복문 까지 종료

                }
            }
        }
    }
}
