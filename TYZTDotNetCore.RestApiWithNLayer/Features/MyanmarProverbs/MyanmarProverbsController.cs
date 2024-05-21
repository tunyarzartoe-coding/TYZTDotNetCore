using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ZackDotNet.RestApiWithNLayer.Features.MyanmarProverbs
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyanmarProverbsController : ControllerBase
    {
        private async Task<MyanmarProverbs> GetDataAsync()
        {
            string jsonstr = await System.IO.File.ReadAllTextAsync("myanmarProverbs.json");
            var model = JsonConvert.DeserializeObject<MyanmarProverbs>(jsonstr);
            return model!;

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var model = await GetDataAsync();
            return Ok(model.Tbl_MMProverbsTitle);
        }

        [HttpGet("{titleName}")]
        public async Task<IActionResult> Get(string titleName)
        {
            var model = await GetDataAsync();
            var item = model.Tbl_MMProverbsTitle.FirstOrDefault(x => x.TitleName == titleName);
            if (item is null)
            {
                return NotFound();
            }
            var titleId = item.TitleId;
            var result = model.Tbl_MMProverbs.Where(x => x.TitleId == titleId);
            List<Tbl_MmproverbsHead> lst = result.Select(x => new Tbl_MmproverbsHead
            {
                ProverbId = x.ProverbId,
                ProverbName = x.ProverbName,
                TitleId = x.TitleId
            }).ToList();
            return Ok(lst);
        }

        [HttpGet("{titleId}/{proverbId}")]
        public async Task<IActionResult> Get(int titleId, int proverbId)
        {
            var model = await GetDataAsync();
            var item = model.Tbl_MMProverbs.FirstOrDefault(x => x.TitleId == titleId && x.ProverbId == proverbId);
            return Ok(item);
        }

    }

    public class MyanmarProverbs
    {
        public Tbl_Mmproverbstitle[] Tbl_MMProverbsTitle { get; set; }
        public Tbl_Mmproverbs[] Tbl_MMProverbs { get; set; }
    }

    public class Tbl_Mmproverbstitle
    {
        public int TitleId { get; set; }
        public string TitleName { get; set; }
    }

    public class Tbl_Mmproverbs
    {
        public int TitleId { get; set; }
        public int ProverbId { get; set; }
        public string ProverbName { get; set; }
        public string ProverbDesp { get; set; }
    }
    public class Tbl_MmproverbsDetail
    {
        public int TitleId { get; set; }
        public int ProverbId { get; set; }
        public string ProverbName { get; set; }
        public string ProverbDesp { get; set; }
    }

    public class Tbl_MmproverbsHead
    {
        public int TitleId { get; set; }
        public int ProverbId { get; set; }
        public string ProverbName { get; set; }
    }

}
