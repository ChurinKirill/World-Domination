using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorldDomination.Models
{
    public class LoginModel
    {
        public int Status;
        public string AlertMessage;
        public LoginModel(int Status, string AlertMessage)
        {
            this.Status = Status;
            this.AlertMessage = AlertMessage;
        }
    }
}