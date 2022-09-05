using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TorneioWeb.Models
{
    public class FighterModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int QtyMartialArts { get; set; }
        public int QtyFights { get; set; }
        public int QtyDefeats { get; set; }
        public int QtyVictories { get; set; }
    }
}
