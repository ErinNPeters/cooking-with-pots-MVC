using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using cookingWithPots.Models.Data;
using cookingWithPots.Models.Repositories;
using cookingWithPots.Models.Dto;

namespace cookingWithPots.Controllers
{
    public class RecipesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IRecipeRepository _recipeRepository;

        public RecipesController(ApplicationDbContext context, IRecipeRepository recipeRepository)
        {
            _context = context;
            _recipeRepository = recipeRepository;
        }

        [HttpGet("/Recipe/RecipeOfTheDay")]
        public async Task<IActionResult> RecipeOfTheDay()
        {
            var recipe = await _context.Recipes
                .FirstOrDefaultAsync(m => m.RecipeId == 1);
            if (recipe == null)
            {
                return NotFound();
            }

            return PartialView("DetailsPartial", recipe);
        }

        public async Task<IActionResult> Index(RecipeListAndSearchCriteriaDto? dto = null)
        {
            var recipes = new List<Recipe>();
            if(dto.searchCriteriaDto == null && dto.Recipes.Count == 0)
            {
                recipes = await _context.Recipes.ToListAsync();
            }
            else
            {
                recipes = await _recipeRepository.GetRecipeAllSearch(dto.searchCriteriaDto);
            }
            dto = new RecipeListAndSearchCriteriaDto(recipes);
            return View(dto);
        }

        // GET: Recipes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Recipes == null)
            {
                return NotFound();
            }

            var recipe = await _recipeRepository.GetRecipeWithLists(id.Value);
            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }

        // GET: Recipes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return View(new RecipeDto { RecipeId = 0 });
            }

            if (id == null || _context.Recipes == null)
            {
                return NotFound();
            }

            var recipe = await _recipeRepository.GetRecipeWithLists(id.Value);
            if (recipe == null)
            {
                return NotFound();
            }
            return View(new RecipeDto(recipe));
        }
        // POST: Recipes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("RecipeId,Title,Description,SlowCooker,IngredientsNotParsed,InstructionsNotParsed,ImageFile,DeleteImage")] RecipeDto recipeDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if(recipeDto.RecipeId == 0)
                    {
                        _context.Add(recipeDto.GetRecipeWithLists());
                    }
                    else
                    {
                        _recipeRepository.SaveRecipeAll(recipeDto.GetRecipeWithLists());
                    }
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecipeExists(recipeDto.RecipeId))
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
            return View(recipeDto);
        }

        // GET: Recipes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Recipes == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipes
                .FirstOrDefaultAsync(m => m.RecipeId == id);
            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }

        // POST: Recipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Recipes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Recipes'  is null.");
            }
            var recipe = await _context.Recipes.FindAsync(id);
            if (recipe != null)
            {
                _context.Recipes.Remove(recipe);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecipeExists(int id)
        {
          return (_context.Recipes?.Any(e => e.RecipeId == id)).GetValueOrDefault();
        }
    }
}
