using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePhoneBook
{
    class PhoneBookManager
    {
        const int MAX_CNT = 100;
        PhoneInfo[] infoStorage = new PhoneInfo[MAX_CNT];
        int curCnt = 0;

        public void ShowMenu()
        {
            Console.WriteLine("-------------------주소록--------------------------");
            Console.WriteLine("  1.입력 |  2.목록  |  3.검색 |  4.삭제  |  5.종료   ");
            Console.WriteLine("-------------------주소록--------------------------");
            Console.Write("선택: ");
        }

        public void InputData()
        {
            Console.WriteLine("구분을 선택해 주세요");
            Console.WriteLine("      1.일반 |  2.대학  |  3.회사    ");
            Console.Write("선택: ");
            int choice;
            while (true)
            {
                int.TryParse(Console.ReadLine(), out choice);
                break;
            }
            if (choice <1 || choice >3)
            {
                Console.WriteLine("1~3 중 선택하시오");
                return;
            }

            PhoneInfo info = null; // 부모로 받음
            switch (choice)
            {
                case 1: info = InPutFriendsInfo();
                    break;
                case 2: info = InPutUnivInfo();
                    break;
                case 3: info = InPutCompanyInfo();
                    break;
            }
            if (info != null)
            {
                infoStorage[curCnt++] = info;
                Console.WriteLine("입력이 완료되었습니다.");
            }


        }

        private int CheckName(string name) // private으로 해도 됨 *****************중요******
        {
            // 이름중복체크
            for (int index = 0; index < curCnt; index++) // 놓쳤다
            {
                if (infoStorage[index].Name == name)
                {
                    return index; // return 써줘야함 (break 쓰면 전화번호입력으로, return쓰면 다시 반복 처음가서 이름입력받음)
                }
            }
            return -1; // 못찾을 경우 무슨 값을 반환할 거냐
        }



        public string[] InputCommpnInfo() 
        {
            // 입력값에 대한 유효성을 체크
            Console.Write("이름: ");
            string name = Console.ReadLine().Trim(); // 공백 제거
            if (string.IsNullOrEmpty(name)) // 필수 입력  if (name.Length < 1)--> 선언만 하고 비교를 했을때 에러가 남
            {
                Console.WriteLine("이름은 필수 입력입니다.");
                return null;
            }
            else
            {
                int dataIdx = CheckName(name);
                if (dataIdx >= 0)
                {
                    Console.WriteLine("이미 등록된 이름입니다. 다른이름으로 입력하세요");
                    return null;
                }
            }

            Console.Write("전화번호: ");
            string phone = Console.ReadLine().Trim(); // 공백 제거
            if (string.IsNullOrEmpty(phone)) // if (name.Length < 1)--> 선언만 하고 비교를 했을때 에러가 남
            {
                Console.WriteLine("전화번호는 필수 입력입니다.");
                return null;
            }
            Console.Write("생일");
            string birth = Console.ReadLine().Trim();

            string[] arr = new string[3];
            arr[0] = name;
            arr[1] = phone;
            arr[2] = birth;

            return arr;
        }

        public PhoneInfo InPutFriendsInfo()
        {
            string[] comInfo = InputCommpnInfo();

            if (comInfo ==null || comInfo.Length != 3)
            {
                return null;
            }
           
            return new PhoneInfo(comInfo[0], comInfo[1], comInfo[2]);
        }

        public PhoneInfo InPutUnivInfo()
        {
            string[] comInfo = InputCommpnInfo();

            if (comInfo == null || comInfo.Length != 3)
            {
                return null;
            }

            Console.Write("전공:");
            string major = Console.ReadLine();

            Console.Write("학년:");
            int year = int.Parse(Console.ReadLine());

            return new PhoneUnivInfo(comInfo[0], comInfo[1], comInfo[2], major, year);
        }

        public PhoneInfo InPutCompanyInfo()
        {
            string[] comInfo = InputCommpnInfo();

            if (comInfo == null || comInfo.Length != 3)
            {
                return null;
            }

            Console.Write("회사명:");
            string company = Console.ReadLine();

            return new PhoneCompanyInfo(comInfo[0], comInfo[1], comInfo[2], company);
        }


        public void ListData()
        {
            if (curCnt == 0) //검색결과가 없는건지 오류난건지 구분하기 위해
            {
                Console.WriteLine("입력된 주소록이 없습니다.");
                return; // 밑에 실행되면 안되니까 return!!!
            }

            for (int i = 0; i < curCnt; i++)
            {
                infoStorage[i].ShowPhoneInfo();
                Console.WriteLine();
            }
        }


       


        public void SearchData()
        {
            Console.WriteLine("검색하실 이름: ");
            string name = Console.ReadLine().Trim();
            int dataIdx = CheckName(name);
            if (dataIdx < 0)
            {
                Console.WriteLine("검색된 데이터가 없습니다.");
            }
            else
            {
                infoStorage[dataIdx].ShowPhoneInfo();
            }
        }

        public void DeleteData()
        {
            Console.WriteLine("삭제하실 이름: ");
            string name = Console.ReadLine().Trim();
            int dataIdx = CheckName(name);
            if (dataIdx < 0)
            {
                Console.WriteLine("삭제할 데이터가 없습니다.");
            }
            else
            {
                for (int i = dataIdx; i < curCnt; i++)
                {
                    infoStorage[i] = infoStorage[i + 1];
                }
                curCnt--;
                Console.WriteLine($"{name} 번호가 삭제되었습니다.");
            }

        }

       
    }
}
