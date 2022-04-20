using System;
using System.Collections.Generic;
using System.Linq;

namespace ToDo_App
{
    class Board
    {
        public List<Cards> colonToDo = new List<Cards>();
        public List<Cards> colonInProgress = new List<Cards>();
        public List<Cards> colonDone = new List<Cards>();

        Members members = new Members();
        Cards cards = new Cards();

        public void addCard()
        {
            Console.WriteLine("Başlık Giriniz                                   :");
            string title = Console.ReadLine();
            Console.WriteLine("İçerik Giriniz                                   :");
            string content = Console.ReadLine();
            Console.WriteLine("Büyüklük Seçiniz -> XS(1),S(2),M(3),L(4),XL(5)   :");
            string size = Console.ReadLine();
            Console.WriteLine("Kişi Seçiniz                                     :");
            int id = Convert.ToInt32(Console.ReadLine());

            
            if(!checkId(id,colonToDo)&&!checkId(id,colonInProgress)&&!checkId(id,colonDone))
            {
                colonToDo.Add(new Cards(title,content,memberFinder(id),ToDo_App.size.L));
            }
            else
            {
                Console.WriteLine("Bu takım üyesi mevcut bir karta atanmış vaziyette!!!");
                Console.WriteLine("* İşlemi sonlandırmak için : (1)");
                Console.WriteLine("* Yeniden denemek için : (2)");
                Console.Write("Seçiminiz:");
                string choice = Console.ReadLine();

                if(choice == "2")
                {
                    addCard();
                }
                else
                {
                    
                }
            }
        }
        public void deleteCard()
        {
            Console.WriteLine("Öncelikle silmek istediğiniz kartı seçmeniz gerekiyor.");
            Console.Write("Lütfen kart başlığını yazınız:");
            string title = Console.ReadLine();

            if(checkCard(title,colonToDo)>-1)
            {
                colonToDo.RemoveAt(checkCard(title,colonToDo));
            }            
            else if (checkCard(title,colonInProgress)>-1)
            {
                colonInProgress.RemoveAt(checkCard(title,colonInProgress));
            }
            else if(checkCard(title,colonDone)>-1)
            {
                colonDone.RemoveAt(checkCard(title,colonDone));
            }            
            else
            {
                Console.WriteLine("Aradığınız krtiterlere uygun kart board'da bulunamadı. Lütfen bir seçim yapınız.");
                Console.WriteLine("* İşlemi sonlandırmak için : (1)");
                Console.WriteLine("* Yeniden denemek için : (2)");
                Console.Write("Seçiminiz:");
                string choice = Console.ReadLine();
                if(choice == "2")
                {
                    deleteCard();
                }
                else
                {
                    
                }
            }
        }  
        public void moveCard()
        {
            Console.WriteLine("Öncelikle silmek istediğiniz kartı seçmeniz gerekiyor.");
            Console.Write("Lütfen kart başlığını yazınız:");
            string title = Console.ReadLine();

            if(checkCard(title,colonToDo)>-1)
            {
                cardMover(title,colonToDo,colonInProgress,colonDone);
            }
            else if(checkCard(title,colonInProgress)>-1)
            {
                cardMover(title,colonInProgress,colonToDo,colonDone);
            }
            else if(checkCard(title,colonDone)<-1)
            {
                cardMover(title,colonDone,colonToDo,colonInProgress);
            }
            else
            {
                Console.WriteLine("Aradığınız krtiterlere uygun kart board'da bulunamadı. Lütfen bir seçim yapınız.");
                Console.WriteLine("* İşlemi sonlandırmak için : (1)");
                Console.WriteLine("* Yeniden denemek için : (2)");
                Console.Write("Seçiminiz:");
                string choice = Console.ReadLine();
                if(choice == "2")
                {
                    moveCard();
                }
                else
                {
                    
                }
            }
        }
        public void updateCard()
        {
            
        } 
        public void listTheBoard()
        {
            Console.WriteLine("TODO Line");
            Console.WriteLine("*******************************************");
            Console.WriteLine();
            if(colonToDo.Count()!=0)
            {
                foreach (var card in colonToDo)
                {
                    cardViewer(card);
                }
            }
            else
            {
                Console.WriteLine(" ~ BOŞ ~");
            }
            Console.WriteLine("IN PROGRESS Line");
            Console.WriteLine("*******************************************");
            Console.WriteLine();

            if(colonInProgress.Count()!=0)
            {
                foreach (var card in colonInProgress)
                {
                    cardViewer(card);
                }
            }
            else
            {
                Console.WriteLine(" ~ BOŞ ~");
            }
            Console.WriteLine("DONE Line");
            Console.WriteLine("*******************************************");
            Console.WriteLine();
            if(colonDone.Count()!=0)
            {
                foreach (var card in colonDone)
                {
                    cardViewer(card);
                }
            }
            else
            {
                Console.WriteLine(" ~ BOŞ ~");
            }
            Console.WriteLine();      
        }
        public int checkCard(string title,List<Cards> colon)
        {
            int index = -1;
            foreach (var card in colon)
            {
                if(card.title==title)
                {
                    index = colon.IndexOf(card);
                }
            }
            return index;
        }
        public bool checkId(int id,List<Cards> colon)
        {
            bool member = false;
            foreach (var card in colon)
            {
                if(card.appointMember.id==id)
                {
                    member = true;
                }
            }
            return member;
            
        }
        public void cardViewer(Cards card)
        {
            Console.WriteLine("Başlık                                  :"+card.title);
            Console.WriteLine("İçerik                                  :"+card.content);
            Console.WriteLine("Atanan Kişi                             :"+card.appointMember.fullName);
            Console.WriteLine("Büyüklük                                :"+card.size);
            Console.WriteLine();            
        }
        public void cardMover(string title,List<Cards> takeList,List<Cards> giveList1,List<Cards> giveList2)
        {
            cardViewer(takeList[checkCard(title,takeList)]);

            Console.WriteLine("Lütfen taşımak istediğiniz Line'ı seçiniz:");
            Console.WriteLine("(1) TODO");
            Console.WriteLine("(2) IN PROGRESS");
            Console.WriteLine("(3) DONE");

            string choice = Console.ReadLine();

            if(choice=="1")
            {
                Console.WriteLine("Taşımak istediğini kart zaten bu kolonda!!!");
            }
            else if(choice=="2")
            {
                giveList1.Add(takeList[checkCard(title,takeList)]);
                takeList.Remove(takeList[checkCard(title,takeList)]);
            }
            else if(choice=="3")
            {
                giveList2.Add(takeList[checkCard(title,takeList)]);
                takeList.Remove(takeList[checkCard(title,takeList)]);
            }
            else
            {
                Console.WriteLine("Hatalı giriş yaptınız!!!");
                Console.WriteLine("* İşlemi sonlandırmak için : (1)");
                Console.WriteLine("* Yeniden denemek için : (2)");
                Console.Write("Seçiminiz:");
                string newChoice = Console.ReadLine();
                if(newChoice == "2")
                {
                    moveCard();
                }
                else
                {
                        
                }
            }
        }
        public Members memberFinder(int id)
        {
            int memberIndex=0;

            foreach (var member in members.memberList)
            {        
                if(member.id == id)
                {
                    memberIndex = members.memberList.IndexOf(member);
                }
            }
            return members.memberList[memberIndex];
        }
    }   
}   