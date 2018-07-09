﻿using System;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc.Html;
using DocumentFormat.OpenXml.Spreadsheet;

namespace MVC_Homework1.ViewModels
{
    public class QueryOption : ICloneable
    {
        private int pageCount = 0;
        public string Keyword { get; set; } = "";
        public int Page { get; set; } = 1;
        public SortOrder SortOrder { get; set; } = SortOrder.ASC;
        public string SortField { get; set; } = "Id";


        public virtual int GetPageSize() => 10;

        public void SetPageCount(int count)
        {
            this.pageCount = count;
        }

        public int GetPageCount() =>
            this.pageCount;

        /// <summary>
        /// Dynamic Linq 用的Sort 參數
        /// </summary>
        /// <returns></returns>
        public string GetSortString() => $"{SortField} {SortOrder}";

        /// <summary>
        /// 產生分頁用的QueryOption
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public QueryOption ClonePageOption(int page)
        {
            var clone = this.Clone();
            clone.Page = page;
            return clone;
        }

        public QueryOption Clone() => 
            (this as ICloneable).Clone() as QueryOption;

        object ICloneable.Clone()
        {
            return this.MemberwiseClone();
        }
    }

    public class 客戶資料QueryOption : QueryOption
    {
        public string Category { get; set; } = "";
    }

    public class 客戶聯絡人QueryOption : QueryOption
    {
        public string Job { get; set; }
    }

    public enum SortOrder
    {
        ASC,
        DESC
    }
}