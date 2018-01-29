using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public const int FirstRusBigWord = 1040;
        public const int LastRusSmallWord = 1103;
        Models.Cipher[] ciph = new Models.Cipher[LastRusSmallWord];
        [HttpGet]
        public ViewResult RsvpForm()
        {
            return View();
        }

        [HttpPost]
        public ViewResult RsvpForm(MvcApplication1.Models.MessageFromClient client)
        {
            Models.Context test = new Models.Context();
            Models.Cipher temp = new Models.Cipher();
            //TypeCipher();

            foreach (Models.Cipher a in test.CipherTable)
            {
                temp = a;
            }
            int hour = DateTime.Now.Hour;
            int min = DateTime.Now.Minute;
            int sec = DateTime.Now.Second; int moun = DateTime.Now.Month; int year = DateTime.Now.Year;
            string time = hour.ToString() + ":" + min.ToString() + ":" + sec.ToString() + ":" + moun.ToString() + ":" + year.ToString();
           // ViewBag.Greeting = time;
            client.Time = time;
            if (ModelState.IsValid)
            {
                Models.Context contx = new Models.Context();
                string code = "";
                code = ToDoCode(client.Message);
                ViewBag.Greeting = code;
                contx.DateMessage.Add(client);
                contx.SaveChanges();
                int index = 0;
                List<string> allcipher = new List<string>();
                List<string> alltime = new List<string>();
                foreach (Models.MessageFromClient c in contx.DateMessage)
                {
                    var k = c;
                    allcipher.Add(ToDoCode(k.Message));
                    alltime.Add(k.Time);
                }
                ViewBag.AllCipher = allcipher;
                ViewBag.AllTime = alltime;
                
                return View("Thanks", client);
            }
            else return View();
        }

        public string ToDoCode(string message)
        {
            string code = "";
            Models.Context contx = new Models.Context();
            char[] mess = message.ToCharArray();
            for (int i =0; i < mess.Count(); i++)
            {
               // Models.Cipher ciph2 = new Models.Cipher();
                //contx.CipherTable.Find(Convert.ToInt32( mess[i]));
                Models.Context context = new Models.Context();
                string tmpword ="";
                int inttmp = Convert.ToInt32(mess[i]);
                var name = context.CipherTable.Where(c => c.oldSymbolId == inttmp);
                foreach (Models.Cipher c in name)
                {
                    tmpword = c.newSymbol;
                }
                code += tmpword;
            }
            return code;
        }
        public void TypeCipher()
        {
            for (int i = 0; i < LastRusSmallWord; i++)
            {
                ciph[i] = new Models.Cipher();

            }
            Models.Context contx = new Models.Context();
            for (int i = 1; i < LastRusSmallWord +1; i++)
            {
                ciph[i-1].Id = i;
                ciph[i-1].oldSymbolId = ((FirstRusBigWord + i - 1));
                int place = FirstRusBigWord + i + 6;
                if (place > LastRusSmallWord) place = place - 64;
                ciph[i - 1].newSymbol = ((char)place).ToString();
                contx.CipherTable.Add(ciph[i-1]); 
            }
            contx.SaveChanges();
            Models.Context test = new Models.Context();
            Models.Cipher temp = new Models.Cipher();
            foreach (Models.Cipher a in test.CipherTable)
            { temp = a; }
        }
 
    }
}
