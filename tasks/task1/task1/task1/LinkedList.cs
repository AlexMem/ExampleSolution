using System;

namespace task1 {
    public class LinkedList<E> {
        private class Node<T> {
            public Node<T> prev { get; set; }
            public T element { get; set; }
            public Node<T> next { get; set; }

            private Node(T element) {
                prev = null;
                this.element = element;
                next = null;
            }

            public Node() {
                prev = null;
                element = default(T);
                next = null;
            }
            
            public Node<T> connect(T newElement) {
                next = new Node<T>(newElement) {prev = this};
                return next;
            }

            public Node<T> clearNext() {
                next = null;
                return this;
            }
            
            public Node<T> clearPrev() {
                prev = null;
                return this;
            }
        }

        private Node<E> head { get; set; }
        private Node<E> end { get; set; }
        private int size { get; set; }

        public LinkedList() {
            reinstanceHead();
            size = 0;
        }

        public E get(int index) {
            return getNode(index).element;
        }

        public E find(E element) {
            Node<E> ptr = head;
            for (int i = 0; i < size; i++) {
                if (ptr.element.Equals(element)) {
                    return ptr.element;
                }
            }
            
            throw new Exception("Element not found");
        }
        
        public LinkedList<E> add(E newElement) {
            if (size != 0) {
                end = end.connect(newElement);
            }
            else {
                head.element = newElement;
            }
            ++size;
            return this;
        }


        public LinkedList<E> delete(int index) {
            if (index == 0) {
                return deleteFirst();
            }

            if (index == size - 1) {
                return deleteLast();
            }
            
            var deletableNode = getNode(index);
            deletableNode.prev.next = deletableNode.next;
            deletableNode.next.prev = deletableNode.prev;
            deletableNode.clearPrev().clearNext();

            --size;
            return this;
        }

        public LinkedList<E> reverse() {
            var ptr = end;
            for (int i = size - 1; i >= 0; --i, ptr = ptr.next) {
                var ptrPrev = ptr.prev;
                ptr.prev = ptr.next;
                ptr.next = ptrPrev;
            }

            ptr = head;
            head = end;
            end = ptr;
            return this;
        }
        
        private LinkedList<E> deleteFirst() {
            var deletableNode = head;
            head = head.next;
            head.prev = null;
            if (size == 1) {
                reinstanceHead();
            }

            deletableNode.clearNext();
            --size;
            return this;
        }

        private LinkedList<E> deleteLast() {
            var deletableNode = end;
            end = end.prev;
            end.next = null;
            if (size == 1) {
                reinstanceHead();
            }

            deletableNode.clearPrev();
            --size;
            return this;
        }

        public int getSize() {
            return size;
        }
        
        public override string ToString() {
            string str = "[ ";
            var ptr = head;
            for (int i = 0; i < size; ++i, ptr = ptr.next) {
                str += ptr.element + " ";
            }

            str += "]";
            return str;
        }
        
        private Node<E> getNode(int index) {
            if(index < 0 || index >= size ) throw new IndexOutOfRangeException();

            Node<E> ptr;
            if (index < size / 2) {
                ptr = head;
                for (int i = 0; i < index; i++) {
                    ptr = ptr.next;
                }
            } else {
                ptr = end;
                for (int i = size-1; i > index; --i) {
                    ptr = ptr.prev;
                }
            }
            
            return ptr;
        }

        private Node<E> reinstanceHead() {
            head = new Node<E>();
            end = head;
            return head;
        }
    }
}
