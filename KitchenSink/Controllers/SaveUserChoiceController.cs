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
        UserItems newItems = new UserItems();
        Cuisine newCuisine = new Cuisine();

        [Authorize]
        public IActionResult ToSaveRecipe(int recipeId, string[] cuisine)
        {
            string recipeCuisine = string.Empty;
            AspNetUsers user;
            if (User.Identity.Name != null)
            {
                KitchenSinkDBContext db = new KitchenSinkDBContext();
                user = db.AspNetUsers.Where(user => user.Email == User.Identity.Name.ToString()).FirstOrDefault();
            }
            //ViewBag.recipeId = recipeId;
            //ViewBag.recipeName = recipeName;
            //ViewBag.drinkid = drinkId;
            //ViewBag.drinkName = drinkName;
            
            newItems.RecipeId = recipeId.ToString();
            recipeCuisine = SetRecipeData(cuisine);
            newCuisine.Cuisine1 = recipeCuisine;
            //db.UserItems.Add(new UserItems
            //{
            //    DrinkId = drinkId,
            //    RecipeId = recipeId.ToString()
            //});
            //    db.SaveChanges();
                return RedirectToAction("Drink", "Drink", newItems);
        }

        public string SetRecipeData(string[] recipeCuisine)
        {
            Random random = new Random();
            Recipes userRecipe = new Recipes();
            //userRecipe.Id = recipeIntId;
            List<string> cuisineList = new List<string>();
            string chosenCuisine = string.Empty;
            
            foreach (var x in recipeCuisine)
            {
                cuisineList.Add(x);
            }
            if (cuisineList.Count > 0)
            {
                chosenCuisine = cuisineList[random.Next(cuisineList.Count)];
            }
            else
            {
                chosenCuisine = "american";
            }
            return (chosenCuisine);
        }

        public IActionResult ToSaveDrink(UserItems Items, string dCategory)
        {
            string recipeCuisine = string.Empty;
            newItems.DrinkId = Items.DrinkId;
            string drinkCategory = dCategory;
            recipeCuisine = newCuisine.Cuisine1;
            return RedirectToAction("GetRec", "Recommendations", drinkCategory, recipeCuisine);
        }

        // SAVE RECIPES
        //[Authorize]
        //public IActionResult SaveRecipeResults(int intId)
        //{
        //    if (users.Email == User.Identity.Name)
        //    {
        //        db.UserPreferences.Add(new UserPreferences()
        //        {
        //            SavedRecipe = intId.ToString(),
        //            CustomerId = users.Id
        //        });

        //        db.SaveChanges();
        //    }
        //    return View("Views/Drink/Drink.cshtml");

        //}
        //// EXCLUDE RECIPES
        //[Authorize]
        //public IActionResult ExcludeRecipeResult()
        //{
        //    db.UserPreferences.Add(new UserPreferences()
        //    {
        //        ExcludedCuisine = preferences.ExcludedCuisine
        //    });
        //    db.SaveChanges();

        //    return View();
        //}
        ////// SAVE DRINK
        //[Authorize]
        //public IActionResult SaveDrinkResults(int intId)
        //{

        //    db.Add(new UserPreferences()
        //    {
        //        SavedDrink = intId.ToString(),
        //        CustomerId = User.Identity.GetHashCode().ToString()
        //    });
        //    db.SaveChanges();

        //    return RedirectToAction("GetRandomMovie", "Movie");
        //}

        //// EXCLUDE DRINK
        //[Authorize]
        //public IActionResult ExcludeDrinkResults()
        //{
        //    db.Add(new UserPreferences()
        //    {
        //        ExcludedDrink = preferences.ExcludedDrink
        //    });
        //    db.SaveChanges();

        //    return View();
        //}

        //// SAVE MOVIES
        //[Authorize]
        //public IActionResult SaveMovieResults()
        //{
        //    db.UserPreferences.Add(new UserPreferences()
        //    {
        //        SavedMovie = preferences.SavedMovie
        //    });
        //    db.SaveChanges();

        //    return View();
        //}

        //// EXLUDE MOVIES
        //[Authorize]
        //public IActionResult ExcludeMovieResults()
        //{
        //    db.UserPreferences.Add(new UserPreferences()
        //    {
        //        ExcludedGenre = preferences.ExcludedGenre
        //    });
        //    db.SaveChanges();

        //    return View();
        //}
        //[Authorize]
        //public IActionResult SaveResults(Drink drink, Recipes recipe, Movie movie)
        //{

        //}
    }
}