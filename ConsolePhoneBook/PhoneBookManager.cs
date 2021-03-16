using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePhoneBook
{
    public class PhoneBookManager
    {
        const int MAX_CNT = 100;
        PhoneInfo[] infoStorage = new PhoneInfo[MAX_CNT];
        int curCnt = 0;
        static PhoneBookManager manager;

        private PhoneBookManager() 
        {

        }

        public static PhoneBookManager CreateManagerInstance()
        {
            if (manager == null)
            {
                manager = new PhoneBookManager();
            }
            return manager;
        }

        public void ShowMenu()
        {
            Console.WriteLine("------------------------주소록-------------------------------");
            Console.WriteLine("   1. 입력 | 2. 목록 | 3. 검색 | 4. 정렬 | 5. 삭제 | 6. 종료");
            Console.WriteLine("-------------------------------------------------------------");
            Console.Write("선택: ");
        }

        public void SortData()
        {
            int choice;
            while (true)
            {
                try
                {
                    Console.WriteLine("1.이름ASC   2.이름DESC   3.전화번호ASC   4.전화번호DESC");
                    Console.Write("선택 >>>  ");

                    while (true)
                    {
                        if (int.TryParse(Console.ReadLine(), out choice))
                            break;
                    }
                    if (choice < 1 || choice > 4)
                    {
                        throw new MenuChoiceException("1.이름ASC 2.이름DESC 3.전화번호ASC 4.전화번호DESC 중에 선택하십시오.");
                        //Console.WriteLine("1.이름ASC 2.이름DESC 3.전화번호ASC 4.전화번호DESC 중에 선택하십시오.");
                        //return;
                    }
                    else
                        break;
                }
                catch(Exception err)
                {
                    Console.WriteLine(err.Message);
                }
            }
            //선택된 조건에 따라 정렬
            PhoneInfo[] newArr = new PhoneInfo[curCnt];
            Array.Copy(infoStorage, 0, newArr, 0, curCnt);
            //Array.Copy(infoStorage, newArr, curCnt);
            if (choice == 1)
            {
                Array.Sort(newArr, new NameComparator());
            }
            else if (choice == 2)
            {
                Array.Sort(newArr, new NameComparator());
                Array.Reverse(newArr);
            }
            else if (choice == 3)
            {
                Array.Sort(newArr, new PhoneComparator());
            }
            else
            {
                Array.Sort(newArr, new PhoneComparator());
                Array.Reverse(newArr);
            }

            foreach(PhoneInfo info in newArr)
            {
                Console.WriteLine(info.ToString());
            }
        }

        public void InputData()
        {
            Console.WriteLine("1.일반   2.대학   3.회사");
            Console.Write("선택 >>>  ");
            int choice;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out choice))
                    break;
            }
            if (choice < 1 || choice > 3)
            {
                Console.WriteLine("1.일반   2.대학   3.회사 중에 선택하십시오.");
                return;
            }

            PhoneInfo info = null;
            switch (choice)
            {
                case 1: info = IuPutFriendInfo(); break;
                case 2: info = IuPutUnivInfo(); break;
                case 3: info = IuPutCompanyInfo(); break;
            }

            if (info != null)
            {
                infoStorage[curCnt++] = info;
                Console.WriteLine("데이터 입력이 완료되었습니다.");
            }            
        }

        private string[] InputCommonInfo()
        {
            //입력값을 받은 후에 PhoneInfo 객체를 생성해서 배열에 저장
            Console.Write("이름: ");
            string name = Console.ReadLine().Trim();
            if (string.IsNullOrEmpty(name))  //if (name.Length < 1)
            {
                Console.WriteLine("이름은 필수입력입니다.");
                return null;
            }
            else
            {
                //이름 중복체크
                int dataIdx = SearchName(name);
                if (dataIdx >= 0)
                {
                    Console.WriteLine("이미 등록된 이름입니다. 다른 이름으로 입력하세요.");
                    return null;
                }
            }

            Console.Write("전화번호: ");
            string phone = Console.ReadLine().Trim();
            if (string.IsNullOrEmpty(phone))
            {
                Console.WriteLine("전화번호는 필수입력입니다.");
                return null;
            }

            Console.Write("생일: ");
            string birth = Console.ReadLine().Trim();

            string[] arr = new string[3];
            arr[0] = name;
            arr[1] = phone;
            arr[2] = birth;

            return arr;
        }

        private PhoneInfo IuPutFriendInfo()
        {
            string[] cominfo = InputCommonInfo();            
            if (cominfo == null || cominfo.Length != 3)
                return null;

            return new PhoneInfo(cominfo[0], cominfo[1], cominfo[2]);
        }

        private PhoneInfo IuPutUnivInfo()
        {
            string[] cominfo = InputCommonInfo();
            if (cominfo == null || cominfo.Length != 3)
                return null;

            Console.Write("전공: ");
            string major = Console.ReadLine();

            Console.Write("학년: ");
            int year = int.Parse(Console.ReadLine());

            return new PhoneUnivInfo(cominfo[0], cominfo[1], cominfo[2], major, year);
        }

        private PhoneInfo IuPutCompanyInfo()
        {
            string[] cominfo = InputCommonInfo();
            if (cominfo == null || cominfo.Length != 3)
                return null;

            Console.Write("회사명: ");
            string company = Console.ReadLine();

            return new PhoneCompanyInfo(cominfo[0], cominfo[1], cominfo[2], company);
        }

        public void ListData()
        {
            if (curCnt == 0)
            {
                Console.WriteLine("입력된 주소록이 없습니다");
                return;
            }

            for (int i = 0; i < curCnt; i++)
            {
                infoStorage[i].ShowPhoneInfo();
                Console.WriteLine();
            }
        }

        public void SearchData()
        {
            Console.Write("검색하실 이름: ");
            string name = Console.ReadLine().Trim();
            int dataIdx = SearchName(name);
            if (dataIdx < 0)
            {
                Console.WriteLine("검색된 데이터가 없습니다");
            }
            else
            {
                infoStorage[dataIdx].ShowPhoneInfo();
                Console.WriteLine();
            }
        }

        private int SearchName(string name)
        {
            for (int i = 0; i < curCnt; i++)
            {
                if (infoStorage[i].Name == name)
                {
                    return i;
                }
            }
            return -1;
        }

        public void DeleteData()
        {
            Console.Write("삭제하실 이름: ");
            string name = Console.ReadLine().Trim();
            int dataIdx = SearchName(name);
            if (dataIdx < 0)
            {
                Console.WriteLine("삭제할 데이터가 없습니다");
            }
            else
            {
                for(int i=dataIdx; i<curCnt; i++)
                {
                    infoStorage[i] = infoStorage[i + 1];
                }
                curCnt--;
                Console.WriteLine("데이터 삭제가 완료되었습니다");
            }
        }
    }
}
