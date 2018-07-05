using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace TodoApi.Models
{


    public class Singleton
    {
        private static Singleton instance;
        private System.Collections.Generic.List<FootBaller> FootBallers;
       

        public void Seed()
        {
            FootBallers = new System.Collections.Generic.List<FootBaller>();
            FootBallers.Add(new FootBaller(Guid.NewGuid().ToString(), "Cristi","Real"));
            FootBallers.Add(new FootBaller(Guid.NewGuid().ToString(), "Leo", "Barca"));
            FootBallers.Add(new FootBaller(Guid.NewGuid().ToString(), "Romelu", "United"));
        }

        private Singleton()
        {
            try
            {
                Seed();   
            }
            catch { }
        

        }

        public static Singleton Instance
        {
            get
            {
                if(instance==null)
                    instance=new Singleton();
                return instance;
            }
        }

        public List<FootBaller> getAll()
        {
            return FootBallers;
        }

        public void add(FootBaller item)
        {
            Guid id = Guid.NewGuid();
            item.Id = id.ToString();
            FootBallers.Add(item);
        }

        public FootBaller SearchItem(string id)
        {
            for (int i = 0; i < FootBallers.Count; i++)
                if (FootBallers[i].Id == id)
                {
                    return FootBallers[i];
                }

            return null;
 
        }

        public FootBaller updateItem(string id,FootBaller item)
        {
            for(int i =0; i<FootBallers.Count; i++)
                if (FootBallers[i].Id == id)
                {
                    FootBallers[i].Team = item.Team;
                    FootBallers[i].Name = item.Name;
                    return FootBallers[i];
                }
            return null;
        }

        public bool deleteItem(string id)
        {
            for (int i = 0; i < FootBallers.Count; i++)
                if (FootBallers[i].Id == id)
                {
                    FootBallers.RemoveAt(i);
                    return true;
                }

            return false;
        }
     
    }
}
