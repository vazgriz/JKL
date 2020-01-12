using System;
using System.Collections.Generic;
using System.Text;

namespace JKL {
    enum TokenType {
        None,
        Whitespace,
        Identifier,
        Colon,
        Number,
        String,
        LeftBracket,
        RightBracket
    }

    class Token {
        public TokenType Type { get; private set; }
        public string Lexeme { get; private set; }
        public int Line { get; private set; }
        public int Column { get; private set; }
        public int WhitespaceLength { get; private set; }

        public Token(TokenType type, string lexeme, int line, int column) {
            Type = type;
            Lexeme = lexeme;
            Line = line;
            Column = column;
        }

        public Token(TokenType type, string lexeme, int line, int column, int whitespaceLength) {
            Type = type;
            Lexeme = lexeme;
            Line = line;
            Column = column;
            WhitespaceLength = whitespaceLength;
        }
    }
}
