using System;
using System.Collections.Generic;
using System.Text;

namespace JKL {
    public class Bool : Node {
        public bool Value { get; set; }

        public Bool() {
            //nothing
        }

        public Bool(bool value) {
            Value = value;
        }

        public static Bool Parse(string token) {
            return new Bool(bool.Parse(token));
        }
    }
}
