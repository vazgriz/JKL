using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections;

namespace JKL {
    class Lexer {
        Stream stream;
        StringBuilder builder = new StringBuilder();
        int line = 1;
        int column = 0;

        StreamReader reader;

        char Peek() {
            return (char)reader.Peek();
        }

        char Read() {
            char c = (char)reader.Read();
            column++;
            return c;
        }

        static bool IsWhitespace(char c) {
            return c == ' ' || c == '\t';
        }

        static bool IsDigit(char c) {
            return c >= '0' && c <= '9';
        }

        static bool IsNumber(char c) {
            return IsDigit(c) || c == '.' || c == '-' || c == '+';;
        }

        static bool IsAlpha(char c) {
            return (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || c == '_';
        }

        static bool IsAlphaDigit(char c) {
            return IsAlpha(c) || IsDigit(c);
        }

        public Lexer(Stream stream) {
            this.stream = stream;
        }

        Token ReadWhitespace() {
            int columnStart = column;
            int whitespaceCount = 0;

            while (!reader.EndOfStream) {
                char c = Peek();

                if (IsWhitespace(c)) {
                    Read();
                    builder.Append(c);
                    whitespaceCount++;
                } else {
                    break;
                }
            }

            return new Token(TokenType.Whitespace, builder.ToString(), line, columnStart, whitespaceCount);
        }

        Token ReadChar(TokenType type) {
            int columnStart = column;
            char c = Read();
            return new Token(type, new string(c, 1), line, columnStart);
        }

        Token ReadNumber() {
            int columnStart = column;

            while (!reader.EndOfStream) {
                char c = Peek();

                if (IsNumber(c)) {
                    Read();
                    builder.Append(c);
                } else {
                    break;
                }
            }

            return new Token(TokenType.Number, builder.ToString(), line, columnStart);
        }

        Token ReadString() {
            int columnStart = column;
            bool foundEnd = false;
            Read(); //skip first "

            while (!reader.EndOfStream) {
                char c = Read();

                if (c == '"') {
                    foundEnd = true;
                    break;
                } else {
                    builder.Append(c);
                }
            }

            if (!foundEnd) {
                //error
            }

            return new Token(TokenType.String, builder.ToString(), line, columnStart);
        }

        Token ReadIdentifier() {
            int columnStart = column;

            while (!reader.EndOfStream) {
                char c = Peek();

                if (IsAlphaDigit(c)) {
                    Read();
                    builder.Append(c);
                } else {
                    break;
                }
            }

            return new Token(TokenType.Identifier, builder.ToString(), line, columnStart);
        }

        public List<Token> Lex() {
            List<Token> results = new List<Token>();
            bool newline = false;

            using (reader = new StreamReader(stream, Encoding.UTF8, false)) {
                while (!reader.EndOfStream) {
                    char c = Peek();
                    builder.Clear();

                    if (c == '\r') {
                        Read();
                        c = Peek();

                        if (c != '\n') {
                            //error
                        }
                    }

                    if (c == '\n') {
                        reader.Read();
                        line++;
                        column = 1;
                        newline = true;
                        continue;
                    } else if (IsWhitespace(c)) {
                        if (newline) {
                            results.Add(ReadWhitespace());
                            newline = false;
                        } else {
                            Read();
                        }
                    } else if (c == ':') {
                        results.Add(ReadChar(TokenType.Colon));
                    } else if (c == '[') {
                        results.Add(ReadChar(TokenType.LeftBracket));
                    } else if (c == ']') {
                        results.Add(ReadChar(TokenType.RightBracket));
                    } else if (IsNumber(c)) {
                        results.Add(ReadNumber());
                    } else if (c == '"') {
                        results.Add(ReadString());
                    } else if (IsAlpha(c)) {
                        results.Add(ReadIdentifier());
                    }
                }
            }

            return results;
        }
    }
}
