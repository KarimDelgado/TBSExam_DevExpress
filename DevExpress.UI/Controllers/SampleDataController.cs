using DevExpress_UI.Models;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace DevExpress_UI.Controllers
{

    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {

        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(SampleData.Orders, loadOptions);
        }

    }
}