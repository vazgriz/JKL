using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace JKL {
    public class Parser {
        List<Token> tokens;
        int index;
        int indentLevel;

        bool HasTokens {
            get {
                return index < tokens.Count;
            }
        }

        Token Peek(int distance = 0) {
            return tokens[index + distance];
        }

        Token Read() {
            var result = tokens[index];
            index++;
            return result;
        }

        Token Match(TokenType type) {
            var token = Peek();
            if (token.Type == type) {
                return Read();
            }

            throw new Exception();
        }

        public Node Parse(Stream stream) {
            tokens = new Lexer(stream).Lex();

            var token = Peek();

            if (token.Type == TokenType.Whitespace) {
                indentLevel = token.WhitespaceLength;
                token = Peek(1);
            }

            if (token.Type == TokenType.LeftBracket) {
                return ParseArray();
            } else if (token.Type == TokenType.Identifier) {
                return ParseTable();
            }

            return null;
        }

        Node ParseObject() {
            var token = Peek();

            if (token.Type == TokenType.Whitespace) {
                indentLevel = token.WhitespaceLength;
                token = Peek(1);
            }

            if (token.Type == TokenType.LeftBracket) {
                return ParseArray();
            } else if (token.Type == TokenType.Identifier) {
                return ParseTable();
            } else if (token.Type == TokenType.String) {
                return ParseString();
            } else if (token.Type == TokenType.Number) {
                return ParseNumber();
            } else if (token.Type == TokenType.Bool) {
                return ParseBool();
            }

            throw new NotImplementedException();
        }

        Node ParseTable() {
            var table = new Table(new Dictionary<string, Node>());
            int currentIndentLevel = indentLevel;

            while (HasTokens) {
                var whitespace = Peek();

                if (whitespace.Type == TokenType.Whitespace) {
                    if (whitespace.WhitespaceLength == currentIndentLevel) {
                        Read();
                    } else if (whitespace.WhitespaceLength < currentIndentLevel) {
                        break;
                    }
                }

                var identifier = Peek();

                if (identifier.Type == TokenType.Identifier) {
                    Read();
                    var key = identifier.Lexeme;
                    Match(TokenType.Colon);
                    var value = ParseObject();

                    table.Add(key, value);
                }
            }

            return table;
        }

        Node ParseArray() {
            return null;
        }

        Node ParseString() {
            var token = Read();
            return new String(token.Lexeme);
        }

        Node ParseNumber() {
            var token = Read();
            return new Integer(long.Parse(token.Lexeme));
        }

        Node ParseBool() {
            var token = Read();
            return new Bool(bool.Parse(token.Lexeme));
        }
    }
}
