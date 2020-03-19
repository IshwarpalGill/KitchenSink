using System;
using System.Collections.Generic;
using System.Linq;
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

        // SAVE RECIPES
        [Authorize]
        public IActionResult SaveRecipeResults()
        {
            db.UserPreferences.Add(new UserPreferences()
            {
                SavedRecipe = preferences.SavedRecipe
            });
            db.SaveChanges();

            return View();
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
        public IActionResult SaveDrinkResults()
        {
            db.Add(new UserPreferences()
            {
                SavedDrink = preferences.SavedDrink
            });
            db.SaveChanges();

            return View();
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