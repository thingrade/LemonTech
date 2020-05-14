using Lemontech.DataLayer.Entities;
using Lemontech.DataLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using LemonTech.Repository.Product.Interface;

namespace LemonTech.Repository.Product
{
    public class ProductService : IProductService
    {
        private readonly DBContext _context;
        public ProductService(DBContext context)
        {
            _context = context;
        }

        public async Task<List<ProductResult>> GetProductList()
        {
            var result = from p in _context.Product
                         join c in _context.Category on p.CategoryId equals c.Id
                         select new ProductResult
                         {
                             Id = p.Id,
                             CategoryId = p.CategoryId,
                             CategoryName = c.Name,
                             Name = p.Name,
                             Description = p.Description,
                             Image = p.Image
                         };

            return result.ToList();
        }

        public async Task<ProductResult> GetProductById(int productId)
        {
            var result = from p in _context.Product
                         join c in _context.Category on p.CategoryId equals c.Id
                         where p.Id == productId
                         select new ProductResult
                         {
                             Id = p.Id,
                             CategoryId = p.CategoryId,
                             CategoryName = c.Name,
                             Name = p.Name,
                             Description = p.Description,
                             Image = p.Image
                         };

            return result.FirstOrDefault();
        }

        public async Task<ResponseModel> CreateProduct(Lemontech.DataLayer.Models.Product model)
        {
            try
            {
                _context.Product.Add(model);

                await _context.SaveChangesAsync();

                return new ResponseModel
                {
                    Message = "Create Product Successful",
                    Status = "Success"
                };
            }
            catch (Exception)
            {
                return new ResponseModel
                {
                    Code = 400,
                    Message = "Create Product Failed",
                    Status = "Failed"
                };
            }

        }

        public async Task<ResponseModel> UpdateProduct(int id, Lemontech.DataLayer.Models.Product model)
        {
            try
            {
                _context.Entry(model).State = EntityState.Modified;

                await _context.SaveChangesAsync();

                return new ResponseModel
                {
                    Message = "Update Product Successful",
                    Status = "Success"
                };
            }
            catch (Exception)
            {
                return new ResponseModel
                {
                    Code = 400,
                    Message = "Update Product Failed",
                    Status = "Failed"
                };
            }
        }

        public async Task<ResponseModel> DeleteProduct(int id)
        {
            try
            {
                var product = await _context.Product.FindAsync(id);

                if (product == null)
                {
                    return null;
                }

                _context.Product.Remove(product);
                await _context.SaveChangesAsync();

                return new ResponseModel
                {
                    Message = "Delete Product Successful",
                    Status = "Success"
                };
            }
            catch (Exception)
            {
                return new ResponseModel
                {
                    Code = 400,
                    Message = "Delete Product Failed",
                    Status = "Failed"
                };
            }

        }
    }
}
