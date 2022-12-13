using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Grakiffi.Domain.Model
{
    public class Category
    {
        private List<SubCategory> _subCategories = new();

        public string Name { get; set; } = string.Empty;
        public IReadOnlyList<SubCategory> SubCategories => _subCategories;
    }
}
