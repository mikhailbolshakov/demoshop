using System;
using System.Collections.Generic;
using System.Text;

namespace DemoShop.Libs.CommonTypes.Paging
{
    public class PagedResponse<T> where T: class
    {
        /// <summary>
        /// how many pages might be obtained by the query
        /// </summary>
        public int NumberOfPages { get; set; }

        /// <summary>
        /// index of current page
        /// </summary>
        public int CurrentPage { get; set; }

        /// <summary>
        /// data
        /// </summary>
        public T Data { get; }

        public PagedResponse(T data)
        {
            Data = data;
        }
    }
}
