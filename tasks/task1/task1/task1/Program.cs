using System;

namespace task1 {
    class Program {
        static void Main(string[] args) {
            var linkedList = new LinkedList<String>();
            linkedList.add("one").add("two").add("three").add("four").add("five");
            Console.WriteLine(linkedList);
            
            linkedList.reverse();
            Console.WriteLine(linkedList);

            linkedList.delete(0);
            Console.WriteLine(linkedList);
            
            linkedList.delete(linkedList.getSize()-1);
            Console.WriteLine(linkedList);
            
            linkedList.delete(1);
            Console.WriteLine(linkedList);
            
            Console.WriteLine(linkedList.find("four"));
        }
    }
}
