using Skinet.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Skinet.Core.Specifications
{
    public class ProductWithFiltersForCountSpecifications : BaseSpecification<Product>
    {
        public ProductWithFiltersForCountSpecifications(ProductRequestParams request) 
            : base(x =>
                  (string.IsNullOrEmpty(request.Search) || x.Name.ToLower().Contains(request.Search)) &&
                  (!request.BrandId.HasValue || x.ProductBrandId == request.BrandId) &&
                  (!request.TypeId.HasValue || x.ProductTypeId == request.TypeId)
            )
        {
        }
    }
}
