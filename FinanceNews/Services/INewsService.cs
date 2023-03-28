using FinanceNews.Models;

namespace FinanceNews.Services
{
    public interface INewsService
    {
        News GetFinanceNews(int offset);
    }
}
