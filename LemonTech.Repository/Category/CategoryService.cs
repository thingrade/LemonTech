using Lemontech.DataLayer.Entities;
using Lemontech.DataLayer.Models;
using LemonTech.Repository.Category.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LemonTech.Repository.Category
{
    public class CategoryService : ICategoryService
    {
        private readonly DBContext _context;
        public CategoryService(DBContext context)
        {
            _context = context;
        }

        public async Task<List<Lemontech.DataLayer.Models.Category>> GetCategoryList()
        {
            return await _context.Category.ToListAsync();
        }

        public async Task<Lemontech.DataLayer.Models.Category> GetCategoryById(int id)
        {
            return await _context.Category.FindAsync(id);
        }

        public async Task<ResponseModel> CreateCategory(Lemontech.DataLayer.Models.Category model)
        {
            try
            {
                _context.Category.Add(model);

                await _context.SaveChangesAsync();

                return new ResponseModel
                {
                    Message = "Create Category Successful",
                    Status = "Success"
                };
            }
            catch (Exception)
            {
                return new ResponseModel
                {
                    Code = 400,
                    Message = "Create Category Failed",
                    Status = "Failed"
                };
            }

        }
        public async Task<ResponseModel> UpdateCategory(int id, Lemontech.DataLayer.Models.Category model)
        {
            try
            {
                _context.Entry(model).State = EntityState.Modified;

                await _context.SaveChangesAsync();

                return new ResponseModel
                {
                    Message = "Update Category Successful",
                    Status = "Success"
                };
            }
            catch (Exception)
            {
                return new ResponseModel
                {
                    Code = 400,
                    Message = "Update Category Failed",
                    Status = "Failed"
                };
            }

        }
        public async Task<ResponseModel> DeleteCategory(int id)
        {
            try
            {
                var category = await _context.Category.FindAsync(id);

                if (category == null)
                {
                    return null;
                }

                _context.Category.Remove(category);
                await _context.SaveChangesAsync();

                return new ResponseModel
                {
                    Message = "Delete Category Successful",
                    Status = "Success"
                };
            }
            catch (Exception)
            {
                return new ResponseModel
                {
                    Code = 400,
                    Message = "Delete Category Failed",
                    Status = "Failed"
                };
            }
        }
    }
}
