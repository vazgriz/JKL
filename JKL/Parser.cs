using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace JKL {
    public class Parser {
        public Node Parse(Stream stream) {
            Lexer lexer = new Lexer(stream);

            int line = 1;
            foreach (var token in lexer.Lex()) {
                if (token.Line != line) {
                    line = token.Line;
                    Console.WriteLine();
                }
                Console.Write("[{0}: {1}]", token.Type, token.Lexeme);
            }

            return null;
        }

        Node ParseObject(Stream stream) {
            return null;
        }
    }
}
