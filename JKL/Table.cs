using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace JKL {
    public class Table : Node, IDictionary<string, Node> {
        IDictionary<string, Node> table;

        public Table(IDictionary<string, Node> table) {
            this.table = table;
        }

        public Node this[string key] {
            get {
                return table[key];
            }
            set {
                table[key] = value;
            }
        }

        public ICollection<string> Keys => table.Keys;

        public ICollection<Node> Values => table.Values;

        public int Count => table.Count;

        public bool IsReadOnly => false;

        public void Add(string key, Node value) {
            table.Add(key, value);
        }

        public void Add(KeyValuePair<string, Node> item) {
            table.Add(item);
        }

        public void Clear() {
            table.Clear();
        }

        public bool Contains(KeyValuePair<string, Node> item) {
            return table.Contains(item);
        }

        public bool ContainsKey(string key) {
            return table.ContainsKey(key);
        }

        public void CopyTo(KeyValuePair<string, Node>[] array, int arrayIndex) {
            table.CopyTo(array, arrayIndex);
        }

        public IEnumerator<KeyValuePair<string, Node>> GetEnumerator() {
            return table.GetEnumerator();
        }

        public bool Remove(string key) {
            return table.Remove(key);
        }

        public bool Remove(KeyValuePair<string, Node> item) {
            return table.Remove(item);
        }

        public bool TryGetValue(string key, out Node value) {
            return table.TryGetValue(key, out value);
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return table.GetEnumerator();
        }
    }
}
