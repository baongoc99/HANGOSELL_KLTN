﻿using HANGOSELL_KLTN.Data;
using HANGOSELL_KLTN.Models.EF;

namespace HANGOSELL_KLTN.Service
{
    public class CategoryService
    {
        private readonly ApplicationDbContext _context;
        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<ProductCategory> GetAllCategory()
        {
            return _context.Categories.ToList();
        }
        public void AddCategory(ProductCategory Category)
        {
            _context.Categories.Add(Category);
            _context.SaveChanges();
        }
        public ProductCategory GetCategoryById(int id)
        {
            return _context.Categories.FirstOrDefault(p => p.Id == id);
        }

        public void UpdateCategory(ProductCategory Category)
        {
            var existingemployee = _context.Categories.SingleOrDefault(u => u.Id == Category.Id);
            if (existingemployee != null)
            {
                _context.Entry(existingemployee).CurrentValues.SetValues(Category);
            }
            else
            {
                _context.Categories.Update(Category);
            }
            _context.SaveChanges();
        }
        public void DeleteCategory(int id)
        {
            var Categorys = _context.Categories.Find(id);
            if (Categorys != null)
            {
                _context.Categories.Remove(Categorys);
                _context.SaveChanges();
            }

        }
    }
}
