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

            bool programOn = true;
            while (programOn)
            {
                try
                {
                    manager.ShowMenu();
                    int choice = int.Parse(Console.ReadLine());


                    switch (choice)
                    {
                        case 1: manager.InputData(); break;
                        case 2: manager.ListData(); break;
                        case 3: manager.SearchData(); break;
                        case 4: manager.DeleteData(); break;
                        case 5: manager.AlterData(); break;
                        case 6: manager.SortData(); break;
                        case 7:
                            Console.WriteLine("프로그램을 종료합니다.");
                            programOn = false;
                            break;
                        default:
                            throw new Exception("1에서 6값을 입력하시오");
                    }
                }
                catch (FormatException err)
                {
                    Console.WriteLine($"입력값이 잘못 되었습니다. {err.Message}");
                }
                catch (Exception err)
                {

                    Console.WriteLine($"처리중 에러: { err.Message}");
                }
            }
        }
    }
}
