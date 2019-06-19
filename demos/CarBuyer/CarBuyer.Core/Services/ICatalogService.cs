using CarBuyer.Core.Models;
using System.Threading.Tasks;

namespace CarBuyer.Core.Services
{
    public interface ICatalogService
    {
        Task<ProductCatalog> FetchCatalogAsync();
    }
}
