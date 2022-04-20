using System;
using System.Collections.Generic;
using System.Linq;

namespace ToDo_App
{
    class Menu
    {
        public void mainMenu()
        {
            Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz :)");
            Console.WriteLine("*******************************************");
            Console.WriteLine("(1) Board Listelemek");
            Console.WriteLine("(2) Board'a Kart Eklemek");
            Console.WriteLine("(3) Board'dan Kart Silmek");
            Console.WriteLine("(4) Kart Taşımak");
            Console.WriteLine("(5) Kart Güncelleme");
        }
    }
}