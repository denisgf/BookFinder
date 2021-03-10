using BookFinder.ViewModel;
using Microsoft.AspNetCore.Mvc;
using BookFinder.Utils;

namespace BookFinder.Controllers
{
    public class SearchController : Controller
    {
        private const int totalItemsPerPage = 40;
        private const int totalNavigationPages = 15;

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NewSearch()
        {
            return View();
        }     
        
        private QueryCollectionViewModel GetQueryCollectionViewModel(string queryText, int startIndex)
        {
            var queryCollection = WebServices.QueryApi(queryText, startIndex, totalItemsPerPage);

            if (queryCollection != null)
            {
                QueryCollectionViewModel viewModel = new QueryCollectionViewModel
                {
                    QueryCollection = queryCollection,
                    NavigationPagesViewModel = new NavigationPagesViewModel(totalNavigationPages, startIndex, queryCollection.TotalItems, totalItemsPerPage, queryText),
                    TextQuery = queryText
                };

                return viewModel;
            }

            return null;
        }

        public IActionResult ShowResults(SearchOptionsViewModel model, int startIndex = 1, string queryString = "")        
        {
            if (!string.IsNullOrEmpty(model.QueryText))
            {
                QueryCollectionViewModel viewModel = GetQueryCollectionViewModel(model.QueryText, startIndex);
                return View(viewModel);                
            }
            else if (!string.IsNullOrEmpty(queryString))
            {
                QueryCollectionViewModel viewModel = GetQueryCollectionViewModel(queryString, startIndex);
                return View(viewModel);                
            }

            return NotFound();
        }       

        public IActionResult Details(string volumeId)
        {
            Volume volume = WebServices.GetVolumeById(volumeId);
            return View(volume);
        }
    }
}
