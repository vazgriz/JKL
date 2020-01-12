using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace JKL {
    public class Integer : Node {
        public long Value { get; set; }

        public Integer() {
            //nothing
        }

        public Integer(long value) {
            Value = value;
        }

        public static Integer Parse(string token) {
            return new Integer(long.Parse(token, NumberStyles.AllowLeadingSign));
        }
    }
}
