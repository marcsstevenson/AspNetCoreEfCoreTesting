﻿using System.ComponentModel.DataAnnotations;
using Generic.Framework.AbstractClasses;
using Generic.Framework.Interfaces.Personal;

namespace Finance.Logic.Crm
{
    public class Customer : Entity, IPerson
    {
        [Required]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        [Required]
        public string LastName { get; set; }
    }
}
