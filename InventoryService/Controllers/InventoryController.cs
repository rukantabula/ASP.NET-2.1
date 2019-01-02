using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using InventoryService.Services;

namespace InventoryService.Controllers
{
    [Route("v1/")]
    [ApiController]
    public class InventoryController : ControllerBase
    {

        private readonly IInventoryServices _services;
        
        public InventoryController(IInventoryServices services)
        {
            _services = services;
        }

        [HttpPost]
        [Route("AddInventoryItems")]
        public ActionResult<InventoryItems> AddInventoryItems(InventoryItems items) // parse a type of our chossing in ActionResult method signature
        {
            var intentoryItems = _services.AddInventoryItems(items);

            if (intentoryItems == null)
            {
                return NotFound();
            }
            return Ok(intentoryItems);
        }

        [HttpGet]
        [Route("GetInventoryItems")]
        public ActionResult<Dictionary<String, InventoryItems>> GetInventoryItems()
        {
            var inventoryItems = _services.GetInventoryItems();

            if (inventoryItems.Count == 0)
            {
                return NotFound();
            }

            return inventoryItems;
        }
    }
}