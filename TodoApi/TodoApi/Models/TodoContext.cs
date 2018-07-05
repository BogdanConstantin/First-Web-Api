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
        private System.Collections.Generic.List<FootBaller> ListItem;

        public void Seed()
        {
            ListItem = new System.Collections.Generic.List<FootBaller>();
            ListItem.Add(new FootBaller(1,"Cristi","Real"));
            ListItem.Add(new FootBaller(2, "Leo", "Barca"));
            ListItem.Add(new FootBaller(3, "Romelu", "United"));
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
            return ListItem;
        }

        public void add(FootBaller item)
        {
            if (item.Id <= ListItem.Count)
                item.Id = ListItem.Count+1;
            ListItem.Add(item);
        }

        public FootBaller SearchItem(long id)
        {
            for (int i = 0; i < ListItem.Count; i++)
                if (ListItem[i].Id == id)
                {
                    return ListItem[i];
                }

            return null;
 
        }

        public FootBaller updateItem(long id,FootBaller item)
        {
            for(int i =0; i<ListItem.Count; i++)
                if (ListItem[i].Id == id)
                {
                    ListItem[i].Team = item.Team;
                    ListItem[i].Name = item.Name;
                    return ListItem[i];
                }
            return null;
        }

        public bool deleteItem(long id)
        {
            for (int i = 0; i < ListItem.Count; i++)
                if (ListItem[i].Id == id)
                {
                    ListItem.RemoveAt(i);
                    return true;
                }

            return false;
        }
     
    }
}
