using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorldDomination.Models
{
    public class Exeptions
    {
        public int exeptionId;
        public string exeptionText;

        public Exeptions(int exeptionId, string exeptionText)
        {
            this.exeptionId = exeptionId;
            this.exeptionText = exeptionText;
        }
    }
}