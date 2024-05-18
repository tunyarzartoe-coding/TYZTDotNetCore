using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ZackDotNet.BurmeseRecipesApi.Features.BurmeseRecipes
{
    [Route("api/[controller]")]
    [ApiController]
    public class BurmeseRecipesController : ControllerBase
    {
        private async Task<List<Recipe>> GetDataAsync()
        {
            string jsonstr = await System.IO.File.ReadAllTextAsync("data.json");
            var model = JsonConvert.DeserializeObject<List<Recipe>>(jsonstr);
            return model!;

        }

        [HttpGet]
        public async Task<IActionResult> GetBurmeseRecipesAsync()
        {
            var model = await GetDataAsync();
            return Ok(model.ToList());

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetResultAsync(string id)
        {
            var model = await GetDataAsync();
            var detail = (model.ToList().FirstOrDefault(x=> x.Id == id));
            if (detail != null)
            {
                return Ok(detail);
            }
            else
            {
                return NotFound("No data Found!");
            }

        }


    }

      public class Recipe
    {
        [JsonProperty("Guid")]
        public string Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Ingredients")]
        public string Ingredients { get; set; }

        [JsonProperty("CookingInstructions")]
        public string CookingInstructions { get; set; }

        [JsonProperty("UserType")]
        public string UserType { get; set; }
    }

    public class RecipeDetail
    {
        [JsonProperty("Guid")]
        public string Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Ingredients")]
        public string Ingredients { get; set; }

        [JsonProperty("CookingInstructions")]
        public string CookingInstructions { get; set; }

        [JsonProperty("UserType")]
        public string UserType { get; set; }
    }


}
