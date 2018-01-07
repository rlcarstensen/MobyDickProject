using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobyDickProject
{
    public class Book
    {
        public List<String> BookWords { get; set; }

        public Book()
        {

        }

        public Book(List<String> words)
        {
            this.BookWords = words;
            
        }

        public bool containsWords(List<String> searchWords)
        {
            int count = 0;
            for(int i = 0; i<searchWords.Count; i++)
            {
                count = BookWords.Where(x => x.Equals(searchWords[i])).Count();

                if (count == 0) return false;

            }


            return true;

        }

        public int wordCounts(String countWord)
        {

            return BookWords.Where(x => x.Equals(countWord)).Count();

        }


        public List<String> getDistinctWords()
        {
            List<String> returnList = new List<String>();

            foreach(String word in BookWords)
            {
                if(returnList.Where(x => x.Equals(word)).Count() == 0)
                {
                    returnList.Add(word);
                }
            }

            return returnList;
        }

        public List<int> getWordsCounts(List<String> countWords)
        {
            List<int> returnList = new List<int>();

            foreach (String countWord in countWords)
            {
                returnList.Add(BookWords.Where(x => x.Equals(countWord)).Count());
            }

            return returnList;

        }

    }
}
