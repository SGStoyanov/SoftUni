using System;
using System.Collections.Generic;

namespace SchoolSystem
{
    public class School
    {
        public School(IList<SchoolClass> classes)
        {
            this.Classes = classes;
        }

        public IList<SchoolClass> Classes { get; set; } 
    }
}