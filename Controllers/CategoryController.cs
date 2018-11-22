using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using assignment3_db.Models;
using assignment3_db.db;
using assignment3_db.ViewModels;

namespace assignment3_db.Controllers
{
    public class CategoryController : Controller
    {
        private readonly EmbeddedStockContext _context;

        public CategoryController(EmbeddedStockContext context)
        {
            _context = context;
        }

        // GET: Category
        public async Task<IActionResult> Index()
        {
            return View(await _context.Category.ToListAsync());
        }

        // GET: Category/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Category
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }

            CategoryViewModel vm = new CategoryViewModel 
            {
                Name = category.Name,
                CategoryId = category.CategoryId.ToString(),
                DisplayComponentTypes = category.ComponentTypeCategories.Select(ctc => ctc.ComponentType).ToList(),
            };

            return View(vm);
        }

        // GET: Category/Create
        public async Task<IActionResult> Create()
        {
            CategoryViewModel vm = new CategoryViewModel();

            List<SelectListItem> componentTypesAsSelectList = await _context.ComponentType.Select(ct =>
                new SelectListItem() {
                    Value = ct.ComponentTypeId.ToString(),
                    Text = ct.ComponentName
                }
            ).ToListAsync();

            vm.ComponentTypes = new MultiSelectList(componentTypesAsSelectList.OrderBy(ct => ct.Text), "Value", "Text");

            return View(vm);
        }

        // POST: Category/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name, SelectedComponentTypes")] CategoryViewModel categoryVM)
        {
            if (ModelState.IsValid)
            {
                Category tempCategory = new Category() {
                    Name = categoryVM.Name,
                };

                Category category = _context.Add(tempCategory).Entity;

                foreach (var id in categoryVM.SelectedComponentTypes)
                {
                    ComponentType componentType = _context.ComponentType.Find(long.Parse(id));
                    
                    ComponentTypeCategory tempCtc = new ComponentTypeCategory 
                    {
                        CategoryId = category.CategoryId,
                        ComponentTypeId = componentType.ComponentTypeId,
                        Category = category,
                        ComponentType = componentType
                    };
                    ComponentTypeCategory ctc = _context.Add(tempCtc).Entity;

                    category.ComponentTypeCategories.Add(ctc);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoryVM);
        }

        // GET: Category/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Category.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Category/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("CategoryId,Name")] Category category)
        {
            if (id != category.CategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(category);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.CategoryId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Category/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Category
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var category = await _context.Category.FindAsync(id);
            _context.Category.Remove(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(long id)
        {
            return _context.Category.Any(e => e.CategoryId == id);
        }
    }
}
