using ProductCatalog.Application.Dto.Response;

namespace ProductCatalog.Web.Response
{
    public class ProductResponse
    {
        public int TotalCount { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public IEnumerable<ProductResponseDto> Products { get; set; }
    }
}
