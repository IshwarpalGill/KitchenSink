using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KitchenSink.Models;

namespace KitchenSink.Controllers
{
    public class RecommendationsController : Controller
    {
        private readonly KitchenSinkDBContext _context;
        public Cuisine cuisine;
        public Drink drink;
        public Movie movie;

        public RecommendationsController(KitchenSinkDBContext context)
        {
            _context = context;
        }


        // TO DO 

        // call recommendation table w/ cuisine and drink, check for a match 
        // lookup cuisine table, get ID 
        // lookup drink table, get ID
        // using those two ids, search for a recommendation 
        // save results as a Recommendation object
        // using that recommendation ID, return Rec. to view 
        // grab genre ID
        // return Movie details from movie controller to recommendation view
        // Display minimum info for movie, recipe, drink (title, image, link to views) 


        //get Recommendation from DB (auto-generated from scaffolding) 
        public async Task<IActionResult> Index()
        {
            var kitchenSinkDBContext = _context.Recommendation.Include(r => r.Genre);

            return View(await kitchenSinkDBContext.ToListAsync());
        }
    }
}
