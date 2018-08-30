using System;
using System.Collections.Generic;
using System.Text;
using UtilityLibrary;

namespace Rent.Data.Entity
{
    public class LanguageLevel : BaseEntity<int>, ISoftDeletable
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public string Description { get; set; }
    }
}
