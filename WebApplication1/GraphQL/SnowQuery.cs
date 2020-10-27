using GraphQL.Types;
using Snow.GraphQL.Types;
using Snow.Repositories;

namespace Snow.GraphQL
{
    public class SnowQuery : ObjectGraphType
    {

        public SnowQuery(ProductRepository productRepository, ProductReviewRepository reviewRepository)
        {
            Field<ListGraphType<ProductType>>(
                "products",
                resolve: context => productRepository.GetAll()
            );

            Field<ProductType>(
                "product",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return productRepository.GetOne(id);
                }
            );

            Field<ListGraphType<ProductReviewType>>(
                "reviews",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "productId" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("productId");
                    return reviewRepository.GetForProduct(id);
                });
        }
    }
}
