using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using System.Reflection;
using ClassLibrary1.Models;

namespace WebApplication1.Pages
{
    public class GridViewModel : PageModel
    {
        public class Column
        {
            public string ColumnName { get; set; }
            public string PropertyName { get; set; } = null;
            public PropertyInfo Property { get; private set; }
            public string Style { get; set; }
            public void SetProperty(Type t)
            {
                Property = t.GetProperty(PropertyName ?? ColumnName);
            }
        }

        private int ViewCount = 3;
        public List<int> Pages = new();
        public System.Collections.IEnumerable Bibos { get; set; }
        public List<SelectListItem> Sizes { get; set; }


        public List<Column> Columns { get; set; }
        [BindProperty(SupportsGet = true)]
        public int CurrentSise { get; set; }

        [BindProperty(SupportsGet = true)]
        public int PageNum { get; set; }

        public GridViewModel()
        {
            Columns = new List<Column>();
            Columns.Add(new Column { ColumnName = "ID", PropertyName = "Id" });
            Columns.Add(new Column { ColumnName = "Bibo Name", PropertyName = "Name" });
            Columns.Add(new Column { ColumnName = "VAL 1", PropertyName = "Val1" });
            Columns.Add(new Column { ColumnName = "VAL 2", PropertyName = "Val2" });
            Columns.Add(new Column { ColumnName = "VAL 3", PropertyName = "Val3" });
            Columns.Add(new Column { ColumnName = "VAL 4", PropertyName = "Val4" });
            Columns.Add(new Column { ColumnName = "VAL 5", PropertyName = "Val5" });
            Columns.Add(new Column { ColumnName = "VAL 6", PropertyName = "Val6" });


            Sizes = new();
            Sizes.Add(new SelectListItem("50", "50"));
            Sizes.Add(new SelectListItem("100", "100"));
            Sizes.Add(new SelectListItem("150", "150"));
            Sizes.Add(new SelectListItem("200", "200"));
            Sizes.Add(new SelectListItem("250", "250"));

            CurrentSise = 100;
            PageNum = 1;
        }

        public void OnGet()
        {
            int rowCount = Bibo.Bibos.Count;
            int pageCount = (int)Math.Floor((float)rowCount / CurrentSise);

            if (PageNum > pageCount) PageNum = 1;

            Bibos = Bibo.Bibos.Skip((PageNum - 1) * CurrentSise).Take(CurrentSise);

            foreach (var b in Bibos)
            {
                foreach (var c in Columns)
                    c.SetProperty(b.GetType());
                break;
            }            

            int splitters = 0;
            if (PageNum > ViewCount) splitters++;
            if (PageNum < pageCount - ViewCount) splitters++;
            if (splitters == 2) ViewCount /= 2;

            for (int i = 1; i <= pageCount; i++)
            {
                if (i <= ViewCount || i > pageCount - ViewCount || Math.Abs(i - PageNum) < 2)
                {
                    Pages.Add(i);
                    continue;
                }
                if (Pages[^1] < 0) continue;
                Pages.Add(-1);
            }
        }
    }
}
