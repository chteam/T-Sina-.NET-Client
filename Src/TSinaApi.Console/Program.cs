namespace TSinaApi.ConsoleTest
{
    using System;
 

    class Program
    {
        static void Main(string[] args)
        {
            TSinaClient client = new TSinaClient(ClientKey.AppKey, "chsword@eice.com.cn", "123456");
           /* var me = client.Users.Show("chsword@eice.com.cn");
            Console.WriteLine(me.StatusesCount);
            Console.WriteLine(me.Status.Text);*/
            //var user = client.Users.Show(1660678232);
           // Console.WriteLine("count:{0}", user.StatusesCount);
            //client.Statuses.Update("test2是啥里"+ DateTime.Now);
            var list = client.Statuses.Emotions();
            foreach (var s in list)
            {
                Console.WriteLine(s.Url);
            }
            //client.Users.Show("重典");
          //  var status = client.Statuses.Update("小开个会");
            System.Console.Read();
        }
    }
}
