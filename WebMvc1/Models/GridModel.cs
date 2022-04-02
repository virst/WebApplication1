using Microsoft.AspNetCore.Mvc.Rendering;
using WebMvc1.Utils;

namespace WebMvc1.Models
{
    public class GridModel
    {
        public List<int> Pages = new();
        public System.Collections.IEnumerable Bibos { get; set; }
        public List<SelectListItem> Sizes { get; set; }


        public List<Column> Columns { get; set; }

        public int CurrentSise { get; set; }

        public int PageNum { get; set; }

        public GridModel()
        {
            Sizes = new();
            Sizes.Add(new SelectListItem("50", "50"));
            Sizes.Add(new SelectListItem("100", "100"));
            Sizes.Add(new SelectListItem("150", "150"));
            Sizes.Add(new SelectListItem("200", "200"));
            Sizes.Add(new SelectListItem("250", "250"));

            CurrentSise = 100;
            PageNum = 1;
        }


    }
}
