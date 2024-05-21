using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ZackDotNet.RestApiWithNLayer.Features.BaganMap
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaganMapController : ControllerBase
    {
        private async Task<BaganMapData> GetDataAsync()
        {
            string jsonstr = await System.IO.File.ReadAllTextAsync("mapData.json");
            var model = JsonConvert.DeserializeObject<BaganMapData>(jsonstr);
            return model!;

        }

        [HttpGet]
        public async Task<IActionResult> BaganMapInfoData()
        {
            var model = await GetDataAsync();
            return Ok(model.Tbl_BaganMapInfoData);

        }
        [HttpGet("route")]
        public async Task<IActionResult> TravelRouteListData()
        {
            var model = await GetDataAsync();
            return Ok(model.Tbl_TravelRouteListData);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> InfoDetailData(string id)
        {
            var model = await GetDataAsync();
            var detail = model.Tbl_BaganMapInfoDetailData.FirstOrDefault(x => x.Id == id);
            if (detail != null)
            {
                return Ok(detail);
            }
            else
            {
                return NotFound("No data Found!");
            }
        }

        [HttpGet("route/{id}")]
        public async Task<IActionResult> TravelRouteListDetail(string id)
        {
            var model = await GetDataAsync();
            var detail = model.Tbl_TravelRouteListData.FirstOrDefault(x => x.TravelRouteId == id);
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
    public class BaganMapData
    {
        public Tbl_Baganmapinfodata[] Tbl_BaganMapInfoData { get; set; }
        public Tbl_Baganmapinfodetaildata[] Tbl_BaganMapInfoDetailData { get; set; }
        public Tbl_Travelroutelistdata[] Tbl_TravelRouteListData { get; set; }
    }

    public class Tbl_Baganmapinfodata
    {
        public string Id { get; set; }
        public string PagodaMmName { get; set; }
        public string PagodaEngName { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
    }

    public class Tbl_Baganmapinfodetaildata
    {
        public string Id { get; set; }
        public string Description { get; set; }
    }

    public class Tbl_Travelroutelistdata
    {
        public string TravelRouteId { get; set; }
        public string TravelRouteName { get; set; }
        public string TravelRouteDescription { get; set; }
        public string[] PagodaList { get; set; }
    }

}
