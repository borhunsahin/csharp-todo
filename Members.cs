using System;
using System.Collections.Generic;
using System.Linq;

namespace ToDo_App
{
    class Members
    {
        public List<Members> memberList = new List<Members>();
        public int id {get;set;}
        public string fullName {get;set;}
        public Members(int id,string fullName)
        {
            this.id=id;
            this.fullName = fullName;
        }
        public Members(){}
    }  
}