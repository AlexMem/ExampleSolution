using System;
using System.Text;

namespace task2 {
    public class BinaryTree<E> where E: IComparable<E> {
        private class TreeNode<T> where T: IComparable<T> {
            private TreeNode<T> left;
            public T element { get; }
            private TreeNode<T> right;

            public TreeNode(T newElement) {
                left = null;
                element = newElement;
                right = null;
            }

            public bool isLeaf() {
                return left == null && right == null;
            }

            private TreeNode<T> connectLeft(T leftElement) {
                return connectLeft(new TreeNode<T>(leftElement));
            }

            private TreeNode<T> connectLeft(TreeNode<T> leftNode) {
                left = leftNode;
                return left;
            }

            private TreeNode<T> connectRight(T rightElement) {
                return connectRight(new TreeNode<T>(rightElement));
            }

            private TreeNode<T> connectRight(TreeNode<T> rightNode) {
                right = rightNode;
                return right;
            }

            private TreeNode<T> rotateLeft() {
                TreeNode<T> k = right;
                right = k.left;
                k.left = this;
                return k;
            }

            private TreeNode<T> rotateRight() {
                TreeNode<T> k = left;
                left = k.right;
                k.right = this;
                return k;
            }

            public TreeNode<T> insert(T newElement) {
                if (newElement.CompareTo(element) < 0) {
                    if (left != null) {
                        left = left.insert(newElement);
                    } else {
                        connectLeft(newElement);
                    }
                } else {
                    if (right != null) {
                        right = right.insert(newElement);
                    } else {
                        connectRight(newElement);
                    }
                }

                return balance();
            }
            
            public TreeNode<T> search(T sElement) {
                if (element.Equals(sElement)) return this;
                if (isLeaf()) throw new Exception("Element not found");
                return element.CompareTo(sElement) < 0 ? left.search(sElement) : right.search(sElement);
            }

            public int height() {
                if (isLeaf()) return 1;
                if (left == null) return right.height() + 1;
                if (right == null) return left.height() + 1;
                int leftHeight = left.height();
                int rightHeight = right.height();
                return (leftHeight >= rightHeight ? leftHeight : rightHeight) + 1;
            }

            public TreeNode<T> balance() {
                if (balanceFactor() == 2) {
                    if (right.balanceFactor() < 0) {
                        right = right.rotateRight();
                    }
                    return rotateLeft();
                }
                
                if(balanceFactor() == -2) {
                    if (left.balanceFactor() > 0) {
                        left = left.rotateLeft();
                    }
                    return rotateRight();
                }

                return this;
            }

            private TreeNode<T> getMin() {
                return left != null ? left.getMin() : this;
            }

            private TreeNode<T> removeMin() {
                if (left == null) {
                    return right;
                }

                left = left.removeMin();
                return balance();
            }

            public TreeNode<T> remove(T delElement) {
                if (delElement.CompareTo(element) < 0) {
                    left = left.remove(delElement);
                } else if (delElement.CompareTo(element) > 0) {
                    right = right.remove(delElement);
                } else {
                    TreeNode<T> q = left;
                    TreeNode<T> r = right;
                    if (r == null) {
                        return q;
                    }

                    TreeNode<T> min = r.getMin();
                    min.right = r.removeMin();
                    min.left = q;
                    return min.balance();
                }

                return balance();
            }

            public void output(StringBuilder stringBuilder) {
                left?.output(stringBuilder);
                stringBuilder.Append(" " + element + " ");
                right?.output(stringBuilder);
            }
            
            private int balanceFactor() {
                if (left == null && right == null) return 0;
                if (left == null) return right.height();
                if (right == null) return -left.height();
                return right.height() - left.height();
            }
        }

        private TreeNode<E> root;

        public BinaryTree() {
            root = null;
        }

        public BinaryTree<E> add(E element) {
            if (root != null) {
                root = root.insert(element);
            } else {
                root = new TreeNode<E>(element);
            }

            return this;
        }

        public BinaryTree<E> delete(E element) {
            root = root.remove(element);
            return this;
        }

        public E find(E element) {
            return root.search(element).element;
        }

        public override string ToString() {
            var result = new StringBuilder();
            root.output(result);
            return result.ToString();
        }
    }
}
