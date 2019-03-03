using System;

namespace task2 {
    class Program {
        static void Main(string[] args) {
            var binaryTree = new BinaryTree<int>();
            binaryTree.add(7).add(1).add(-1).add(5).add(8);
            Console.WriteLine(binaryTree);
            Console.WriteLine(binaryTree.find(1));
            binaryTree.delete(7);
            Console.WriteLine(binaryTree);
            binaryTree.delete(1);
            Console.WriteLine(binaryTree);
        }
    }
}