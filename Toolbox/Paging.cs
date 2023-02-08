using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Toolbox.DataTools;

namespace Toolbox
{
    public class Paging<T> where T : class
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int Total { get; set; }
        public List<T> PageData { get; set; }
        public Paging(IEnumerable<T> data, int currentPage = 1, int pageSize = 20)
        {
            CurrentPage=currentPage;
            PageSize=pageSize;
            Total = data.Count();
            TotalPages=Total%PageSize!=0 ? Total/pageSize+1 : Total/pageSize;
            PageData = data.Skip((CurrentPage-1)*PageSize).Take(PageSize).ToList();
        }
    }
}
