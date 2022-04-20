using System;
using System.Collections.Generic;
using System.Linq;

namespace ToDo_App
{
    class Cards
    {
        public string title{get;set;}
        public string content{get;set;}
        public Members appointMember{get;set;}
        public size size{get;set;}
        
        public Cards(string title,string content,Members appointMember,size size)
        {
            this.title = title;
            this.content = content;
            this.appointMember = appointMember;
            this.size = size;
        }
        public Cards(){}
    }
    
}