using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceManagement_WebApp.Repository
{
    public class CategoriesRepository
    {
        private readonly ConnectedOfficeContext _context = new ConnectedOfficeContext();



        // GET: Categories
        public List<Category> GetAll()
        {
            return _context.Category.ToList();
        }

        // GET: Categories by ID
        public async Task <Category> GetById(Guid? id)
        {

            var category = await _context.Category
                .FirstOrDefaultAsync(m => m.CategoryId == id);
          
                return (category);
          
        }

        // GET: Categories Create
        public Category Create()
        {
            return View();
        }

        public async Task<Category> Create([Bind("CategoryId,CategoryName,CategoryDescription,DateCreated")] Category category)
        {
            category.CategoryId = Guid.NewGuid();
            _context.Add(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private Category RedirectToAction(string v)
        {
            throw new NotImplementedException();
        }

        private Category View()
        {
            throw new NotImplementedException();
        }

        public async Task<Category> Edit(Guid? id)
        {

            var category = await _context.Category.FindAsync(id);
            
            return (category);
        }

        // GET: Categories/Delete/5
        public async Task <Category> Delete(Guid? id)
        {
            
            var category = await _context.Category
                .FirstOrDefaultAsync(m => m.CategoryId == id);
           

            return (category);
        }

    }
}
