using System;

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
            
            public TreeNode<T> connectLeft(T leftElement) {
                return connectLeft(new TreeNode<T>(leftElement));
            }

            public TreeNode<T> connectLeft(TreeNode<T> leftNode) {
                left = leftNode;
                return left;
            }
            
            public TreeNode<T> connectRight(T rightElement) {
                return connectRight(new TreeNode<T>(rightElement));
            }

            public TreeNode<T> connectRight(TreeNode<T> rightNode) {
                right = rightNode;
                return right;
            }

            public TreeNode<T> rotateLeft() {
                TreeNode<T> k = right;
                right = k.left;
                k.left = this;
                return k;
            }

            public TreeNode<T> rotateRight() {
                TreeNode<T> k = left;
                left = k.right;
                k.right = this;
                return k;
            }

            public void insert(T newElement) {
                if (newElement.CompareTo(element) < 0) {
                    if (left != null) {
                        left.insert(newElement);
                    } else {
                        connectLeft(newElement);
                    }
                } else {
                    if (right != null) {
                        right.insert(newElement);
                    } else {
                        connectRight(newElement);
                    }
                }

                balance();
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

            public TreeNode<T> getMin() {
                return left != null ? left.getMin() : this;
            }
            
            private int balanceFactor() {
                return right.height() - left.height();
            }
        }

        private TreeNode<E> root;
        private int size { get; }

        public BinaryTree() {
            root = null;
            size = 0;
        }

        public BinaryTree<E> add(E element) {
            if (root != null) {
                root.insert(element);
            } else {
                root = new TreeNode<E>(element);
            }

            return this;
        }

        public BinaryTree<E> delete(E element) {
            var node = root.search(element);
            var minNode = node.getMin();
            //TODO
            return this;
        }

        public E find(E element) {
            return root.search(element).element;
        }

        private void balance() {
            root.balance();
        }
    }
}
    