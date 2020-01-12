using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace JKL {
    public class Array : Node, IList<Node> {
        List<Node> items;

        public Array() {
            items = new List<Node>();
        }

        public Node this[int index] {
            get {
                return items[index];
            }
            set {
                items[index] = value;
            }
        }

        public int Count => items.Count;

        public bool IsReadOnly => false;

        public void Add(Node item) {
            items.Add(item);
        }

        public void Clear() {
            items.Clear();
        }

        public bool Contains(Node item) {
            return items.Contains(item);
        }

        public void CopyTo(Node[] array, int arrayIndex) {
            items.CopyTo(array, arrayIndex);
        }

        public IEnumerator<Node> GetEnumerator() {
            return items.GetEnumerator();
        }

        public int IndexOf(Node item) {
            return items.IndexOf(item);
        }

        public void Insert(int index, Node item) {
            items.Insert(index, item);
        }

        public bool Remove(Node item) {
            return items.Remove(item);
        }

        public void RemoveAt(int index) {
            items.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return items.GetEnumerator();
        }
    }
}
