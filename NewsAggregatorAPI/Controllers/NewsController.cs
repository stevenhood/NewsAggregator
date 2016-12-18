using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Xml;

namespace NewsAggregatorAPI.Controllers
{
    /// <summary>
    /// The controller for retrieving news.
    /// </summary>
    public class NewsController : ApiController
    {
        /// <summary>
        /// Get news feed by provider name.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("news/{providerName}")]
        public async Task<IHttpActionResult> GetFeedByName(string providerName)
        {
            using (var client = new HttpClient())
            {
                var responseXml = await client.GetStringAsync(@"http://feeds.bbci.co.uk/news/rss.xml");

                var doc = new XmlDocument();
                doc.LoadXml(responseXml);
                var jsonText = JsonConvert.SerializeXmlNode(doc);

                return Ok(jsonText);
            }
        }
    }
}
