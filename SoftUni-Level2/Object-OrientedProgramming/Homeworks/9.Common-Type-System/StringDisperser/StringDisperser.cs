using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringDisperser
{
    public class StringDisperser : ICloneable, IComparable, IEnumerable
    {
        private string firstString;
        private string secondString;
        private string thirdString;

        public StringDisperser(string firstString, string secondString, string thirdString)
        {
            this.FirstString = firstString;
            this.SecondString = secondString;
            this.ThirdString = thirdString;
        }

        public string FirstString { get; set; }
        public string SecondString { get; set; }
        public string ThirdString { get; set; }

        public override string ToString()
        {
            return string.Format(this.FirstString + " " + this.SecondString + " " + this.ThirdString);
        }

        public override bool Equals(object obj)
        {
            return this.ToString() == obj.ToString();
        }

        public override int GetHashCode()
        {
            return FirstString.GetHashCode() ^ SecondString.GetHashCode() ^ ThirdString.GetHashCode();
        }

        public static bool operator == (StringDisperser stringDisperser1, StringDisperser stringDisperser2)
        {
            return stringDisperser1.Equals(stringDisperser2);
        }

        public static bool operator != (StringDisperser stringDisperser1, StringDisperser stringDisperser2)
        {
            return !(stringDisperser1 == stringDisperser2);
        }

        public object Clone()
        {
            return new StringDisperser(
                      this.FirstString,
                      this.SecondString,
                      this.ThirdString);
        }

        public int CompareTo(object obj)
        {
            return System.String.Compare(this.ToString(), obj.ToString(), System.StringComparison.Ordinal);
        }

        public IEnumerator GetEnumerator()
        {
            var str = this.ToString();
            return str.ToCharArray().GetEnumerator();
        }
    }
}