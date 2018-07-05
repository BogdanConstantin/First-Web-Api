using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class FootBaller
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Team { get; set; }

        public FootBaller(string v1, string v2, string v3)
        {
            this.Id = v1;
            this.Name = v2;
            this.Team = v3;
        }
    }
}
