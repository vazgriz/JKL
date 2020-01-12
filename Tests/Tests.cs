using NUnit.Framework;
using System;
using System.IO;

using JKL;

namespace Tests {
    public class Tests {
        [Test]
        public void Test1() {
            using (FileStream stream = File.Open("input1.txt", FileMode.Open)) {
                Parser parser = new Parser();
                parser.Parse(stream);
            }
            Assert.Pass();
        }
    }
}