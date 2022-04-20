using System;
using System.Collections.Generic;
using System.Linq;

namespace ToDo_App
{
    class Program
    {
        public bool isActive=true;
        static void Main(string[] args)
        {
            bool isActive=true;
  
            Members members = new Members();
            Cards cards = new Cards();      
            Board board = new Board();
            Menu menu = new Menu();

            members.memberList.Add(new Members(0,"Gabe Newell"));
            members.memberList.Add(new Members(1,"Bill Gates"));
            members.memberList.Add(new Members(2,"Vinton Gray Cerf"));
            members.memberList.Add(new Members(3,"Steve Jobs"));
            members.memberList.Add(new Members(4,"Jeff Bezos"));

            board.colonToDo.Add(new Cards("Game Development","Counter-Strike",members.memberList[0],size.M));
            board.colonInProgress.Add(new Cards("Operating System","Windows",members.memberList[1],size.L));
            board.colonDone.Add(new Cards("TCP/IP","Arpanet",members.memberList[2],size.XL));          


            while(isActive)
            {   
                menu.mainMenu();               
                Console.Write("Seçiminiz            : ");
                string choice = Console.ReadLine();

                if(choice=="1")
                {
                    board.listTheBoard();
                }
                else if(choice=="2")
                {
                    
                    board.addCard();
                }
                else if(choice=="3")
                {
                    board.deleteCard();
                }
                else if(choice=="4")
                {
                    board.moveCard();
                }
                else if(choice=="5")
                {
                    board.updateCard();
                }  
            }
        }      
    } 
    enum size
    {
        XS=1,
        S=2,
        M=3,
        L=4,
        XL=5
    }   
}
