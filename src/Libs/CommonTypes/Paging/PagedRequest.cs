using System;
using System.Collections.Generic;
using System.Text;

namespace DemoShop.Libs.CommonTypes.Paging
{
    public class PagedRequest<T> where T: class
    {
        /// <summary>
        /// number of rows requested on one page
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int PageNumber { get; set; }

        /// <summary>
        /// data
        /// </summary>
        public T Data { get; }

        public PagedRequest(T data)
        {
            Data = data;
        }
    }
}
