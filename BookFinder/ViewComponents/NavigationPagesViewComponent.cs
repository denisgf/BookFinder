using BookFinder.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookFinder.ViewComponents
{
    public class NavigationPagesViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(NavigationPagesViewModel navigationPagesViewModel)
        {
            //var navigationPagesViewModel = new NavigationPagesViewModel() { startIndex = startIndex, TotalItemsPerPage = totalItemsPerPage };
            return View(navigationPagesViewModel);
        }
    }
}
