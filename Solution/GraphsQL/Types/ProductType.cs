using Domain.Entities;
using GraphQL.Types;

namespace GraphQL.Types
{
    public class ProductType : ObjectGraphType<Product>
    {
        public ProductType()
        {
            Field(h => h.id).Description("The id of the product.");
            Field(h => h.Code).Description("The code of the product.");
            Field(h => h.Name, nullable: true).Description("The name of the product.");
            Field(h => h.Description, nullable: true).Description("The description of the product.");
        }
    }
}
