using GraphQL.Types;

namespace Snow.GraphQL.Types
{
    public class ProductReviewInputType : InputObjectGraphType
    {
        public ProductReviewInputType()
        {
            Name = "reviewInput";
            Field<IdGraphType>("id");
            Field<NonNullGraphType<StringGraphType>>("title");
            Field<StringGraphType>("review");
            Field<IntGraphType>("productId");
        }
    }
}
