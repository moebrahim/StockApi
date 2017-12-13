using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Stock.Models;

namespace Stock.Controllers
{
    public class StockController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetStock(string id)
        {
            List<liveStock> stocks = new List<liveStock>();
            using (Entities contxt = new Entities())
            {
                var result = from a in contxt.liveStocks
                             where a.itemId == id
                             select a;
                foreach (var item in result)
                {
                    stocks.Add(new liveStock
                    {
                        qty = item.qty,
                        itemId = item.itemId

                    }
                        );

                }
            }
            return Ok(stocks);

        }
    }
}
