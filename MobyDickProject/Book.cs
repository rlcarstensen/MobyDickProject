using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobyDickProject
{
    public class Book
    {
        public List<String> Words { get; set; }

        public Book()
        {

        }

        public Book(List<String> words)
        {
            this.Words = words;
        }

        public bool containsWords(List<String> searchWords)
        {

            return false;

        }

        public int wordCounts(String countWord)
        {

            return 0;

        }

    }
}
