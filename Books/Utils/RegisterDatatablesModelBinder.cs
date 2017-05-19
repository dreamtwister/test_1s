using System.Web;
using System.Web.Mvc;
using Mvc.JQuery.DataTables;

[assembly: PreApplicationStartMethod(typeof(Books.RegisterDataTablesModelBinder), "Start")]
namespace Books
{
    public static class RegisterDataTablesModelBinder
    {
        public static void Start()
        {
            if (!ModelBinders.Binders.ContainsKey(typeof(DataTablesParam)))
                ModelBinders.Binders.Add(typeof(DataTablesParam), new Mvc.JQuery.DataTables.DataTablesModelBinder());
        }
    }
}