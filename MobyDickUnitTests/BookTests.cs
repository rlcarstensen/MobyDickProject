using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using MobyDickProject;

namespace MobyDickUnitTests
{
    [TestClass]
    public class BookTests
    {
        [TestMethod]
        public void containsWords_HasWords_returnsTrue()
        {
            List<String> bookWords = new List<String>();
            bookWords.Add("Word");
            bookWords.Add("Hello");
            bookWords.Add("World");

            Book myBook = new Book(bookWords);

            List<String> checkWords = new List<String>();
            checkWords.Add("Hello");
            checkWords.Add("World");

            bool result = myBook.containsWords(checkWords);

            Assert.IsTrue(result);




            
        }

        [TestMethod]
        public void containsWords_DoesNotHaveWords_returnsFalse()
        {
            List<String> bookWords = new List<String>();
            bookWords.Add("Word");
            bookWords.Add("Hello");
            bookWords.Add("World");

            Book myBook = new Book(bookWords);

            List<String> checkWords = new List<String>();
            checkWords.Add("Good");
            checkWords.Add("By");

            bool result = myBook.containsWords(checkWords);

            Assert.IsFalse(result);

        }

        [TestMethod]
        public void wordCounts_HasWords_returns_2()
        {
            List<String> bookWords = new List<String>();
            bookWords.Add("Word");
            bookWords.Add("Hello");
            bookWords.Add("World");
            bookWords.Add("Word");

            Book myBook = new Book(bookWords);
            
            bool result = (myBook.wordCounts("Word") == 2);

            Assert.IsTrue(result);

        }

        [TestMethod]
        public void wordCounts_DoesNotHaveWords_returns_0()
        {
            List<String> bookWords = new List<String>();
            bookWords.Add("Word");
            bookWords.Add("Hello");
            bookWords.Add("World");
            bookWords.Add("Word");

            Book myBook = new Book(bookWords);

            bool result = (myBook.wordCounts("Not") == 0);

            Assert.IsTrue(result);

        }
    }
}
