﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Data.Entities;

namespace Snow.Repositories
{
    public class ProductReviewRepository
    {

        private readonly SnowDbContext _dbContext;

        public ProductReviewRepository(SnowDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ProductReview>> GetForProduct(int productId)
        {
            return await _dbContext.ProductReviews.Where(pr => pr.ProductId == productId).ToListAsync();
        }

        public async Task<ILookup<int, ProductReview>> GetForProducts(IEnumerable<int> productIds)
        {
            var reviews = await _dbContext.ProductReviews.Where(pr => productIds.Contains(pr.ProductId)).ToListAsync();
            return reviews.ToLookup(r => r.ProductId);
        }

        public async Task<ProductReview> AddReview(ProductReview review)
        {
            _dbContext.ProductReviews.Add(review);
            await _dbContext.SaveChangesAsync();
            return review;
        }
    }
}