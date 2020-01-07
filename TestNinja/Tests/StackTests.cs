using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.Tests
{
    [TestFixture]
    class StackTests
    {
        [Test]
        public void Push_InputIsEmptyObject_ThrowsArgumentNullException()
        {
            var stack = new Fundamentals.Stack<string>();
            Assert.That(() => stack.Push(null), Throws.ArgumentNullException);
        }

        [Test]
        public void Push_InputIsCorrectObject_AddObjectToStack()
        {
            var stack = new Fundamentals.Stack<string>();
            stack.Push("aaa");
            Assert.That(stack.Count == 1);
        }

        [Test]
        public void Pop_StackCountIsZero_ThrowsInvalidOperationException()
        {
            var stack = new Fundamentals.Stack<string>();
            Assert.That(() => stack.Pop(), Throws.InvalidOperationException);
        }

        [Test]
        public void Pop_StackIsNotEmpty_ReturnsObjectFromStack()
        {
            var stack = new Fundamentals.Stack<string>();
            stack.Push("1");
            stack.Push("2");
            stack.Push("3");
            var lastElement = stack.Pop();
            Assert.That(lastElement == "3");
        }
        [Test]
        public void Pop_StackIsNotEmpty_RemoveObjectFromStack()
        {
            var stack = new Fundamentals.Stack<string>();
            stack.Push("1");
            stack.Push("2");
            stack.Push("3");
            stack.Pop();
            Assert.That(stack.Count == 2);
        }

        [Test]
        public void Peek_StackIsEmpty_ThrowsInvalidOperationException()
        {
            var stack = new Fundamentals.Stack<string>();
            Assert.That(() => stack.Peek(), Throws.InvalidOperationException);
        }


        [Test]
        public void Peek_StackIsNotEmpty_PickElementFromStack()
        {
            var stack = new Fundamentals.Stack<string>();
            stack.Push("1");
            stack.Push("2");
            stack.Push("3");
            var lastElement = stack.Peek();
            Assert.That(lastElement == "3");
        }

        [Test]
        public void Peek_StackIsNotEmpty_DoesNotRemoveObjectOfTheStack()
        {
            var stack = new Fundamentals.Stack<string>();
            stack.Push("1");
            stack.Push("2");
            stack.Push("3");
            stack.Peek();
            Assert.That(stack.Count == 3);
        }
        [Test]
        public void Count_StackIsEmpty_ReturnsZero()
        {
            var stack = new Fundamentals.Stack<string>();
            Assert.That(stack.Count == 0);
        }
    }
}
