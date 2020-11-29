namespace Thenewboston.Common.Api.Models
{
    public class PaginationParams
    {
        public int? Page { get; set; } 
        public int? Limit { get; set; }
        public int? Offset { get; set; }

        public void Deconstruct(out int? page, out int? offset, out int? limit)
        {
            page = Page;
            offset = Offset;
            limit = Limit;
        }
    }
}