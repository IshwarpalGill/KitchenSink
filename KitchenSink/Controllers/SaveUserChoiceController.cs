using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using KitchenSink.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KitchenSink.Controllers
{
    public class SaveUserChoiceController : Controller
    {
        KitchenSinkDBContext db = new KitchenSinkDBContext();
        UserPreferences preferences = new UserPreferences();
        Recipes recipes = new Recipes();

        // SAVE RECIPES
        [Authorize]
        public IActionResult SaveRecipeResults(int intId)
        {
            db.UserPreferences.Add(new UserPreferences()
            {
                SavedRecipe = intId.ToString()
            }); ;
            db.SaveChanges();

            return View("Views/Drink/Drink.cshtml");
        }
        // EXCLUDE RECIPES
        [Authorize]
        public IActionResult ExcludeRecipeResult()
        {
            db.UserPreferences.Add(new UserPreferences()
            {
                ExcludedCuisine = preferences.ExcludedCuisine
            });
            db.SaveChanges();

            return View();
        }
        //// SAVE DRINK
        [Authorize]
        public IActionResult SaveDrinkResults(int intId)
        {
            db.Add(new UserPreferences()
            {
                SavedDrink = intId.ToString()
            });
            db.SaveChanges();

            return RedirectToAction("GetRandomMovie", "Movie");
        }

        // EXCLUDE DRINK
        [Authorize]
        public IActionResult ExcludeDrinkResults()
        {
            db.Add(new UserPreferences()
            {
                ExcludedDrink = preferences.ExcludedDrink
            });
            db.SaveChanges();

            return View();
        }

        // SAVE MOVIES
        [Authorize]
        public IActionResult SaveMovieResults()
        {
            db.UserPreferences.Add(new UserPreferences()
            {
                SavedMovie = preferences.SavedMovie
            });
            db.SaveChanges();

            return View();
        }

        // EXLUDE MOVIES
        [Authorize]
        public IActionResult ExcludeMovieResults()
        {
            db.UserPreferences.Add(new UserPreferences()
            {
                ExcludedGenre = preferences.ExcludedGenre
            });
            db.SaveChanges();

            return View();
        }
    }
}