using CodeAssignment72Media.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeAssignment72Media.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ValidateInput(Numbers model)
        {
            if (ModelState.IsValid)
            {
                IDictionary<string, int> dict = new Dictionary<string, int>();
                string[] array = model.Input.Split(',');
                string message = "[]";

                //Counts the number of times an int repeats itself
                foreach (var item in array)
                {
                    if (dict.ContainsKey(item))
                        dict[item] += 1;
                    else
                        dict.Add(item, 1);

                }

                //Get the integers that repeats at least 3 times
                var filteredResult = dict.Where(p => p.Value > 2).OrderByDescending(p => p.Key);

                //Builds the message for the user
                if (filteredResult.Any())
                {
                    message = string.Empty;
                    foreach (var item in filteredResult)
                    {
                        message += string.Format("{0},", item.Key);
                    }
                }

                model.Message = message.TrimEnd(',');
            }

            return View("Index", model);
        }
    }
}