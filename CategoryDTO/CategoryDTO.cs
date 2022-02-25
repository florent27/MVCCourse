using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BulkyDonetCore30.CategoryDTO
{
    public class CategoryDTO
    {
        public string Name { get; set; }
        public int DisplayOrder { get; set; }

        public CategoryDTO(string AName, int ADisplayOrder)
        {
            Name = AName;
            DisplayOrder = ADisplayOrder;
        }
    }
}