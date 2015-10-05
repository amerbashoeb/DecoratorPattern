using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DecoratePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            IStack stack = new Stack();
            StackTraceDecorator std = new StackTraceDecorator(stack);
            for(int i=0;i<10; i++)
            {
                Console.WriteLine("----------------------");
                Console.WriteLine("----------------------");
                Console.WriteLine("Enter a String to Push");
                Console.WriteLine("----------------------");
                Console.WriteLine("----------------------");
                var a = Console.ReadLine();
                std.Push(a);
            }
            Console.WriteLine("--------------------------");
            Console.WriteLine("--------------------------");
            Console.WriteLine("Total pushed Items are " + std.ShowAll().Count.ToString());
            Console.WriteLine("--------------------------");
            Console.WriteLine("--------------------------");
            Console.ReadLine();
        }
    }
    /*
     * INTERFACE
     */
    public interface IStack
    {
        void Push(string value);
        string Pop();
        List<string> ShowAll();
    }

    /*
     * A CLASS
     */
    public class Stack: IStack
    {
        private List<string> list = new List<string>();
        public void Push(string value)
        {
            list.Add(value);
        }
        public string Pop()
        {
            string result = list.ElementAt(list.Count - 1);
            list.RemoveAt(list.Count - 1);
            return result;
        }
        public List<string> ShowAll()
        {
            return list;
        }
    }

    /*
     * A CLASS That Demonstrates Decorator Pattern.
     */
    public class StackTraceDecorator : IStack
    {
        IStack innerStack;
        public StackTraceDecorator(IStack stack)
        {
            innerStack = stack;
        }
        public void Push(string value)
        {
            innerStack.Push(value);
            
            // Below line as the DECORATOR
            Console.WriteLine("Push ("+value.ToString()+")");
        }
        public string Pop()
        {
            string result = innerStack.Pop();
            
            // Below line as the DECORATOR
            Console.WriteLine(result.ToString() + ":Pop()");
            return result;
        }
        public List<string> ShowAll()
        {
            // Below line as the DECORATOR
            Console.WriteLine("Showing the pushed items.");
            return innerStack.ShowAll();
        }
    }
}
