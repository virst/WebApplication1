using Microsoft.AspNetCore.Mvc;
using WebMvc1.Models;
using WebMvc1.Utils;

namespace WebMvc1.Controllers
{
    public class GridController : Controller
    {
        private int ViewCount = 3;

        public IActionResult List(int? CurrentSise, int? PageNum)
        {
            GridModel model = new();
            if(CurrentSise != null) model.CurrentSise = CurrentSise.Value;
            if(PageNum != null) model.PageNum = PageNum.Value;

            model.Columns = new List<Column>();
            model.Columns.Add(new Column { ColumnName = "ID", PropertyName = "Id" });
            model.Columns.Add(new Column { ColumnName = "Bibo Name", PropertyName = "Name" });
            model.Columns.Add(new Column { ColumnName = "VAL 1", PropertyName = "Val1" });
            model.Columns.Add(new Column { ColumnName = "VAL 2", PropertyName = "Val2" });
            model.Columns.Add(new Column { ColumnName = "VAL 3", PropertyName = "Val3" });
            model.Columns.Add(new Column { ColumnName = "VAL 4", PropertyName = "Val4" });
            model.Columns.Add(new Column { ColumnName = "VAL 5", PropertyName = "Val5" });
            model.Columns.Add(new Column { ColumnName = "VAL 6", PropertyName = "Val6" });

            int rowCount = ClassLibrary1.Models.Bibo.Bibos.Count;
            int pageCount = (int)Math.Floor((float)rowCount / model.CurrentSise);

            if (PageNum > pageCount) PageNum = 1;

            model.Bibos = ClassLibrary1.Models.Bibo.Bibos.Skip((model.PageNum - 1) * model.CurrentSise).Take(model.CurrentSise);

            foreach (var b in model.Bibos)
            {
                foreach (var c in model.Columns)
                    c.SetProperty(b.GetType());
                break;
            }

            int splitters = 0;
            if (PageNum > ViewCount) splitters++;
            if (PageNum < pageCount - ViewCount) splitters++;
            if (splitters == 2) ViewCount /= 2;

            for (int i = 1; i <= pageCount; i++)
            {
                if (i <= ViewCount || i > pageCount - ViewCount || Math.Abs(i - model.PageNum) < 2)
                {
                    model.Pages.Add(i);
                    continue;
                }
                if (model.Pages[^1] < 0) continue;
                model.Pages.Add(-1);
            }

            return View(model);
        }
    }
}
