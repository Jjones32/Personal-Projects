using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase
{
    public class Movie
    {
        private string _title;
        private string _category;

        public Movie(string title, string category)
        {
            _title = title;
            _category = category;
        }

        public string GetTitle()
        {
            return _title;
        }

        public string GetCategory()
        {
            return _category;
        }
    }
}

