using HuaweiAPI;

namespace Sample
{
    class Program
    {
        static void RT(Action action, int seconds, CancellationToken token) 
        {
            if (action == null)
                return;
            Task.Run(async () => {
                while (!token.IsCancellationRequested)
                {
                    action();
                    await Task.Delay(TimeSpan.FromSeconds(seconds), token);
                }
            }, token);
        }

        static void Main(string[] args)
        {
            var cts = new CancellationTokenSource();
            RT(() => DoWork(), 15, cts.Token);
            Console.ReadLine();
        }

        static void DoWork(){
            string ip = "192.168.8.1";
            string username = "admin";
            string password = "Jmamp32a&Jmamp32a&";

            //check login state
            Console.WriteLine("Checking login state..");
            if(HuaweiAPI.HuaweiAPI.Api.loginState(ip) == true)
            { 
                Console.WriteLine("Already logged in."); 
            }
            else 
            {
                Console.WriteLine("Not logged in, logging in..");
                var login = HuaweiAPI.HuaweiAPI.Api.UserLogin(ip, username, password);
                if (login == false)
                { 
                    Console.WriteLine("Failed to log in."); 
                    Console.ReadLine(); 
                    return; 
                }
            }

            //logged in
            Console.WriteLine("Logged in.");
            Console.WriteLine();

            //lets try sending GET request
            HuaweiAPI.HuaweiAPI.Tools.GET(ip, "api/device/information");

            //lets try sending POST request
            var data = @"<request>
  <CurrentLanguage>en-us</CurrentLanguage>
</request>";
            HuaweiAPI.HuaweiAPI.Tools.POST(ip, data, "api/language/current-language");

            HuaweiAPI.HuaweiAPI.Api.UserLogout(ip, username, password);
            
        }  
    }
}

