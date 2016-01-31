using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Server.Controllers
{
    public class BotController : Controller
    {
        /*
            Думаю одним контроллером мы сможем управлять юотом. Как и договаривались раньше друг-друга методы не трогам.
            Так же думаю что нужно использовать авторизацию бота, чтобы если кто-то пронюхал как отправить запрос, то не смог бы получить ответ с заданием.
        */
        // GET: Bot
        public string GetTask()
        {

            return ""; //Потому что нам не нужен только текст, а не html документ
        }
    }
}