﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shijra.Model;

namespace Shijra.Helpers
{
    public class PersonComparer : IEqualityComparer<Person>
    {

        public bool Equals(Person x, Person y)
        {
            return (x.FirstName.Trim() == y.FirstName.Trim()
                    && x.FatherId == y.FatherId
                    && ((string.IsNullOrEmpty(x.LastName) && string.IsNullOrEmpty(y.LastName)) || x.LastName.Trim() == y.LastName.Trim())
                    && ((string.IsNullOrEmpty(x.MiddleName) && string.IsNullOrEmpty(y.MiddleName)) || x.MiddleName.Trim() == y.MiddleName.Trim()));

        }

        public int GetHashCode(Person obj)
        {
            return obj.GetHashCode();
        }
    }
}

namespace Shijra.Model
{
    public partial class Person
    {
        public string Name
        {
            get
            {
                var name = FirstName + (MiddleName != null ? $" {MiddleName}" : "") + (LastName != null ? $" {LastName}" : "");
                return name;
            }
        }

        
    }
}
