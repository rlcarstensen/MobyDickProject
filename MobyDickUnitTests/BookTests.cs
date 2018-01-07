using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using MobyDickProject;
using System.IO;
using System.Linq;
using System.Diagnostics;

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

        [TestMethod]
        public void completeProgramTest()
        {
            int count = 0;
            String bookPath = "mobydick.txt";
            String stopWordsPath = "stop-words.txt";
            List<String> readLines = new List<String>();
            List<String> bookWords = new List<String>();
            List<String> stopWords = new List<String>();
            List<String> myWordsList = new List<String>();
            List<int> myWordsCountsList = new List<int>();
            List<Tuple<String, int>> wordsWithCounts = new List<Tuple<String, int>>();

            File.WriteAllText("stopWordsOutput.txt", String.Empty);
            File.WriteAllText("nonStopWordsOutput.txt", String.Empty);

            readLines = File.ReadAllLines(bookPath).ToList<String>();

            foreach(String line in readLines)
            {
                String storageString = new String(line.Where(x => char.IsWhiteSpace(x) || char.IsLetterOrDigit(x)).ToArray());
                bookWords.AddRange( storageString.Split(' ').ToArray<String>());
            }

            readLines = File.ReadAllLines(stopWordsPath).ToList<String>();

            foreach (String line in readLines)
            {

                if (!String.IsNullOrWhiteSpace(line) && !line.Contains("#"))
                {
                    stopWords.Add(line);
                }

            }

            Book myBook = new Book(bookWords);

            myWordsCountsList = myBook.getWordsCounts(stopWords);

            //FileStream stopWordsOutPutFile = File.OpenWrite("stopWordsOutput.txt");

            for (int i = 0; i<stopWords.Count; i++)
            {
                File.AppendAllText("stopWordsOutput.txt", stopWords[i] + " " + myWordsCountsList[i] + "\n");
                //Debug.WriteLine(stopWords[i] + " " + myWordsCountsList[i]);
            }

            myWordsList = myBook.getDistinctWords();

            while(count < myWordsList.Count)
            {
                foreach(String stopWord in stopWords)
                {
                    if (stopWord.Equals(myWordsList[count]))
                    {
                        //Debug.WriteLine(myWordsList.Count);
                        myWordsList.RemoveAt(count);
                        //Debug.WriteLine(myWordsList.Count);
                        count--;
                    }
                }

                count++;
            }
            
            myWordsCountsList = myBook.getWordsCounts(myWordsList);

            for(int i = 0; i<myWordsList.Count; i++)
            {
                wordsWithCounts.Add(new Tuple<String, int>(myWordsList[i], myWordsCountsList[i])); 
            }

            wordsWithCounts = wordsWithCounts.OrderByDescending(x => x.Item2).ToList();

            for(int i = 0; i<100; i++)
            {
                File.AppendAllText("nonStopWordsOutput.txt", wordsWithCounts[i].Item1 + " " + wordsWithCounts[i].Item2 + "\n");
                Debug.WriteLine(wordsWithCounts[i].Item1 + " " + wordsWithCounts[i].Item2);
            }
            
        }
    }
}
