using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace JKL {
    public class Float : Node {
        public double Value { get; set; }

        public Float() {
            //nothing
        }

        public Float(double value) {
            Value = value;
        }

        public static Float Parse(string token) {
            return new Float(double.Parse(token, NumberStyles.AllowExponent | NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign));
        }
    }
}
