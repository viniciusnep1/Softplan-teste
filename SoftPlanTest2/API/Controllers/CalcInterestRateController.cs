using API.Maps;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class CalcInterestRateController : ControllerBase
    {

        public CalcInterestRateController()
        {
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CalcInterestRateParam param)
        {
            try
            {

                var baseUrl = new Uri("http://localhost:5000/InterestRate");
                HttpClient cliente = new HttpClient();
                var json = await cliente.GetStringAsync(baseUrl);
                var interestRate = JsonConvert.DeserializeObject<InterestRateMap>(json);

                var result = (param.Value * 100) / interestRate.InterestRate;
                return await Task.FromResult(Ok(new { InterestRate = interestRate, Result = result }));
            }
            catch (Exception e)
            {
                return await Task.FromResult(Ok(e));

            }
        }


        [HttpGet("GetCalc")]
        public async Task<IActionResult> PostCalc()
        {
            try
            {
                using (WebClient wc = new WebClient())
                {
                    var baseUrl = new Uri("http://localhost:5000/InterestRate");
                    var json = wc.DownloadString(baseUrl);
                    var interestRate = JsonConvert.DeserializeObject<InterestRateMap>(json);
                    return await Task.FromResult(Ok(new { InterestRate = interestRate}));
                }
            }
            catch (Exception e)
            {
                return await Task.FromResult(Ok(e));

            }
        }

        [HttpPost("Calc")]
        public async Task<IActionResult> PostCalc([FromBody] CalcInterestRateParam param)
        {
            try
            {

                using (WebClient wc = new WebClient())
                {
                    var baseUrl = new Uri("http://localhost:5000/InterestRate");

                    var json = wc.DownloadString(baseUrl);
                    var interestRate = JsonConvert.DeserializeObject<InterestRateMap>(json);
                    var result = (param.Value * 100) / interestRate.InterestRate;
                    return await Task.FromResult(Ok(new { InterestRate = interestRate, Result = result }));
                }
            }
            catch (Exception e)
            {
                return await Task.FromResult(Ok(e));

            }
        }
    }
}
