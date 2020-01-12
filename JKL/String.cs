using System;
using System.Collections.Generic;
using System.Text;

namespace JKL {
    public class String : Node {
        public string Value { get; set; }

        public String() {
            //nothing
        }

        public String(string value) {
            Value = value;
        }

        public static String Parse(string token) {
            return new String(token);
        }
    }
}
