using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class MatchModel
    {
        public long MatchID { get; set; }
        public string TeamOne { get; set; }
        public string TeamTwo { get; set; }
        public string Location { get; set; }
        public string StadiumName { get; set; }
        public DateTime MatchDate { get; set; }
        public string MatchStartTime { get; set; }
        public string MatchEndTime { get; set; }
        public string Notes { get; set; }
        //public bina Image { get; set; }
        public string OpeningGatesTime { get; set; }

    }
}
