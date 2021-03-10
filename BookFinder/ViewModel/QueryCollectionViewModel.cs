using BookFinder.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookFinder.ViewModel
{
    public class QueryCollectionViewModel
    {
        public QueryCollection QueryCollection { get; set; }
        public NavigationPagesViewModel NavigationPagesViewModel { get; set; }
        public string TextQuery { get; set; }
    }
}
