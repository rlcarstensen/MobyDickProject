using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using MobyDickProject;
using System.IO;
using System.Linq;

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

        [TestMethod]
        public void getDistinctWordsTest()
        {
            bool result = true;
            List<String> myWordsList = new List<String>();
            List<String> bookWords = new List<String>();
            bookWords.Add("Word");
            bookWords.Add("Hello");
            bookWords.Add("World");
            bookWords.Add("Word");

            List<String> correctList = new List<String>();
            correctList.Add("Word");
            correctList.Add("Hello");
            correctList.Add("World");

            Book myBook = new Book(bookWords);

            myWordsList = myBook.getDistinctWords();

            for(int i = 0; i<correctList.Count; i++)
            {
                if (!correctList[i].Equals(myWordsList[i]))
                {
                    result = false;
                }
            }
            
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void getWordCountsTest()
        {
            bool result = true;
            List<String> myWordsList = new List<String>();
            List<int> myWordsCountsList = new List<int>();
            List<String> bookWords = new List<String>();
            bookWords.Add("Word");
            bookWords.Add("Hello");
            bookWords.Add("World");
            bookWords.Add("Word");

            List<int> correctList = new List<int>();
            correctList.Add(2);
            correctList.Add(1);
            correctList.Add(1);

            Book myBook = new Book(bookWords);

            myWordsList = myBook.getDistinctWords();
            myWordsCountsList = myBook.getWordsCounts(myWordsList);

            for (int i = 0; i < correctList.Count; i++)
            {
                if (!(correctList[i] == myWordsCountsList[i]))
                {
                    result = false;
                }
            }

            Assert.IsTrue(result);

        }
    }
}
