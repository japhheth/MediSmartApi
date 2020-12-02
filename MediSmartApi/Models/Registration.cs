using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediSmartApi.Models
{
    public class Registration
    {
        public int itbid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OtherName { get; set; }
        public string MaidenName { get; set; }
        public string Sex { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string Next_Of_Kin { get; set; }
        public string Email { get; set; }
    }
}