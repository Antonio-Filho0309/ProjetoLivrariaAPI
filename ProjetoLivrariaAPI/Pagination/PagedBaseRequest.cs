namespace ProjetoLivrariaAPI.Pagination
{
    public class PagedBaseRequest
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string OrderByProperty { get; set; }
        public bool Desc { get;set; }

        public PagedBaseRequest()
        {
            PageNumber = 1;
            PageSize = 5;
            OrderByProperty = "Id";
            Desc = false;
        }
    }

    public class FilterDb : PagedBaseRequest { 
    public string? FilterValue {get; set; } 
    }
}
