using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bayshore.Service;
using Microsoft.AspNetCore.Mvc;

namespace Bayshore.Controllers
{
    public class ConverterController : Controller
    {
        IConverterService _converterService;

        public ConverterController(IConverterService converterService)
        {
            _converterService = converterService;
        }

        public IActionResult Index(decimal someNumber)
        {
            ViewData["someNumber"] = someNumber;

            var wordedResponse = string.Empty;

            if (someNumber != 0)
                wordedResponse = _converterService.ConvertIntoWords(someNumber);
            else
                wordedResponse = "Zero";

            ViewData["ConvertedWords"] = wordedResponse;

            return View();
        }
    }
}