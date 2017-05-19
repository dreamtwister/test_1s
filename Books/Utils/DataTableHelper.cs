using System.Linq;
using Books.Core;
using Mvc.JQuery.DataTables;

namespace Books
{
    public static class DataTableHelper
    {
        public static BookList ToBookList(DataTablesParam dataTableParam)
        {
            var list = new BookList
            {
                Orders = dataTableParam.iSortCol.Select((t, i) => new OrderViewModel
                {
                    Index = i,
                    Key = dataTableParam.sColumnNames[t],
                    Order = dataTableParam.sSortDir[i].Equals("asc") ? Order.ASC : Order.DESC
                }).ToList(),
                ItemStart = dataTableParam.iDisplayStart
            };
            return list;
        }
    }
}