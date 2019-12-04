using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using MedziaguMoksloFrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace MedziaguMoksloFrontEnd.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public List<MaterialForDropDownList> list = new List<MaterialForDropDownList>();
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public async Task<List<MaterialForDropDownList>> GetDropdownMaterialsAsync()
        {
            HttpClient client = new HttpClient();
            var responseString = await client.GetAsync("https://localhost:5001/api/material/dropdown");
            List<MaterialForDropDownList> res = (List<MaterialForDropDownList>)JsonConvert.DeserializeObject(
                await responseString.Content.ReadAsStringAsync(), typeof(List<MaterialForDropDownList>));
            return res;
        }
    }
}
