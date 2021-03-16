using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePhoneBookGangsa
{
    // 사용자 정의 익셉션
    public class MenuChoiceException : Exception
    {
        public MenuChoiceException() : base("다시 메뉴를 선택하여주십시오") { }
        public MenuChoiceException(string message): base(message) { }

        // 그냥 메인에서 throw new exception 메세지 해도 되지만
        // 익셉션을 구체적으로 나누어 통계를 내고 싶을때 사용함

    }
}
