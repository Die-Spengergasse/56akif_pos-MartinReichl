using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Grakiffi.Domain.Model
{
    public class Category
    {
        public string Name { get; set; } = string.Empty;

        public List<SubCategory> SubCategories { get; set; } = new();
    }
}
