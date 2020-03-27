using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using KitchenSink.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;


namespace KitchenSink.Controllers
{
    public class SaveUserChoiceController : Controller
    {
        KitchenSinkDBContext db = new KitchenSinkDBContext();
        UserPreferences preferences = new UserPreferences();
        AspNetUsers users = new AspNetUsers();
        int recipeIntId = 0;
        int intId = 0;
        string chosenCusine = string.Empty;
        Random random = new Random();


        // SAVE RECIPES
        [Authorize]

        //public string SetRecipeData(int recipeIntId, string[] recipeCusine)
        //{
        //    Recipes userRecipe = new Recipes();
        //    userRecipe.Id = recipeIntId;
        //    List<string> cusineList = new List<string>();

        //    foreach (var x in recipeCusine)
        //    {
        //        cusineList.Add(x);
        //    }
        //    if (cusineList.Count > 0)
        //    {
        //        chosenCusine = cusineList[random.Next(cusineList.Count)];
        //    }
        //    else
        //    {
        //        chosenCusine = "american";
        //    }

        //    return (chosenCusine);
        //}

        public IActionResult SaveRecipeResults(int recipeIntId)
        {
            Recipes recipes = new Recipes();
            recipes.Id = recipeIntId;

            users = db.AspNetUsers.Where(user => user.Email == User.Identity.Name.ToString()).FirstOrDefault();

            db.UserPreferences.Add(new UserPreferences()
            {
                SavedRecipe = recipeIntId.ToString(),
                //CustomerId = users.Id
            });

            //db.SaveChanges();

            return View("Views/Drink/Drink.cshtml", recipeIntId);

        }
        // EXCLUDE RECIPES
        [Authorize]
        public IActionResult ExcludeRecipeResult()
        {
            users = db.AspNetUsers.Where(user => user.Email == User.Identity.Name.ToString()).FirstOrDefault();

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
            users = db.AspNetUsers.Where(user => user.Email == User.Identity.Name.ToString()).FirstOrDefault();

            db.Add(new UserPreferences()
            {
                SavedDrink = intId.ToString(),
                CustomerId = users.Id
            });
            db.SaveChanges();

            Compiler();

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

        public IActionResult Compiler()
        {
            Recipes recipes = new Recipes();
            recipes.Id = recipeIntId;

            users = db.AspNetUsers.Where(user => user.Email == User.Identity.Name.ToString()).FirstOrDefault();

            db.UserPreferences.Add(new UserPreferences()
            {
                SavedRecipe = recipeIntId.ToString(),
                SavedDrink = intId.ToString(),
                CustomerId = users.Id
            });

            db.SaveChanges();

            return View();
        }
    }
}