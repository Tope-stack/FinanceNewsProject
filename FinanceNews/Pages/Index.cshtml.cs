using FinanceNews.Models;
using FinanceNews.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FinanceNews.Pages
{
    public class IndexModel : PageModel
    {
        public News _news;
        private readonly ILogger<IndexModel> _logger;
        private readonly INewsService _newsService;

        public IndexModel(ILogger<IndexModel> logger, INewsService newsService)
        {
            _logger = logger;
            _newsService = newsService; 
        }

        public void OnGet()
        {
            _news = _newsService.GetFinanceNews(0);
        }

        public void OnGetLoadMoreNews(int offset)
        {
            _news = _newsService.GetFinanceNews(offset);
        }
    }
}