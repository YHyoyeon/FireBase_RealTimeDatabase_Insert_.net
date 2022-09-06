using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;

namespace DigiLab.PushNotification
{
    public class Manager
    {
        IFirebaseConfig fcon = new FirebaseConfig()
        {
            AuthSecret = "iuW9XHClQgLjeHtkZSbud2uYzSYX9yx6rtD2jevj",    // 프로젝트 설정 -> 데이터베이스 비밀번호 
            BasePath = "https://pushtest-1b434-default-rtdb.firebaseio.com/"
        };

        IFirebaseClient client;

        public void Connect()
        {
            try
            {
                client = new FireSharp.FirebaseClient(fcon);
            }
            catch
            {
                Console.WriteLine("인터넷 연결 문제"); //there was problem in the internet.
            }
        }

        public void Insert()
        {
            Tb_Send_Push_Log data = new Tb_Send_Push_Log()
            {
                Idx = 0,
                User_Sn = 0,
                Push_Type = 0,
                Subject = "Subject0",
                Contents = "Contents0",
                IsSend = true,
                Sendtime = DateTime.UtcNow.ToString(),
            };
            Console.WriteLine(DateTime.Now.ToString());
            for (int i = 0; i < 1000; i++)
            {
                var setter = client.Push("PushTest", data);
            }
            Console.WriteLine(DateTime.Now.ToString());
            Console.WriteLine("데이터 전송 성공"); //data inserted successfully
        }

        // https://www.youtube.com/watch?v=QE5UV8NyYqg
        // 원하는 기능이 아니라 드롭
        public void Select()
        {
            try
            {
                var result = client.Get("PushTest");
                Console.WriteLine(result.Body.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
