using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookFinder.ViewModel
{
    public class NavigationPagesViewModel
    {
        public NavigationPagesViewModel(int totalNavigationPages, int startIndex, int totalItems, int totalItemsPerPage, string searchQuery)
        {
            TotalNavigationPages = totalNavigationPages;
            TotalItemsPerPage = totalItemsPerPage;
            StartIndexPage = CalculateStartIndexPage(startIndex,totalItemsPerPage, totalNavigationPages, totalItems);
            SelectedPage = CalculateSelectedPage();
            TotalItems = totalItems;

            SearchQuery = searchQuery;
        }

        private int CalculateStartIndexPage(int startIndex, int totalItemsPerPage, int totalNavigationPages, int totalItems)
        {
            int currentPage = (startIndex / totalItemsPerPage) + 1;
            int maxNavigationPage = (totalItems / totalItemsPerPage) + 1;

            if (currentPage <= totalNavigationPages / 2)
            {
                return 1;
            }

            if(currentPage >= maxNavigationPage - totalNavigationPages / 2)
            {
                return maxNavigationPage - totalNavigationPages + 1;
            }

            return currentPage - (totalNavigationPages / 2);
        }

        private int CalculateSelectedPage()
        {
            return 1;
        }        

        public int TotalNavigationPages { get; set; }
        public int StartIndexPage { get; set; }
        public int SelectedPage { get; set; }
        public int TotalItems { get; set; }
        public int TotalItemsPerPage { get; set; }
        public string SearchQuery { get; set; }

    }
}
