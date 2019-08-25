using CarDealership.Data.Factory;
using CarDealership.Models.Queries;
using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarDealership.UI.Controllers
{
    public class VehicleAPIController : ApiController
    {
        [Route("api/vehicle/search")]
        [AcceptVerbs("GET")]
        public IHttpActionResult Search(decimal? minPrice, decimal? maxPrice, string minYear, string maxYear, string makeName, string modelName, string year)
        {
            var repo = VehicleRepositoryFactory.GetRepository();

            try
            {
                var parameters = new VehicleSearchParameters()
                {
                    MinPrice = minPrice,
                    MaxPrice = maxPrice,
                    MinYear = minYear,
                    MaxYear = maxYear,
                    MakeName = makeName,
                    ModelName = modelName,
                    Year = year
                };
                var result = repo.Search(parameters);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("api/vehicle/search")]
        [AcceptVerbs("GET")]
        public IHttpActionResult UsedSearch(decimal? usedMinPrice, decimal? usedMaxPrice, string usedMinYear, string usedMaxYear, string usedMakeName, string usedModelName, string usedYear)
        {
            var repo = VehicleRepositoryFactory.GetRepository();

            try
            {
                var parameters = new UsedVehicleSearchParameters()
                {
                    UsedMinPrice = usedMinPrice,
                    UsedMaxPrice = usedMaxPrice,
                    UsedMinYear = usedMinYear,
                    UsedMaxYear = usedMaxYear,
                    UsedMakeName = usedMakeName,
                    UsedModelName = usedModelName,
                    UsedYear = usedYear
                };
                var result = repo.UsedSearch(parameters);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("api/vehicle/search")]
        [AcceptVerbs("GET")]
        public IHttpActionResult SalesSearch(decimal? salesMinPrice, decimal? salesMaxPrice, string salesMinYear, string salesMaxYear, string salesMakeName, string salesModelName, string salesYear)
        {
            var repo = VehicleRepositoryFactory.GetRepository();

            try
            {
                var parameters = new SalesVehicleSearchParameters()
                {
                    SalesMinPrice = salesMinPrice,
                    SalesMaxPrice = salesMaxPrice,
                    SalesMinYear = salesMinYear,
                    SalesMaxYear = salesMaxYear,
                    SalesMakeName = salesMakeName,
                    SalesModelName = salesModelName,
                    SalesYear = salesYear
                };
                var result = repo.SalesSearch(parameters);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("api/vehicle/search")]
        [AcceptVerbs("GET")]
        public IHttpActionResult AdminSearch(decimal? adminMinPrice, decimal? adminMaxPrice, string adminMinYear, string adminMaxYear, string adminMakeName, string adminModelName, string adminYear)
        {
            var repo = VehicleRepositoryFactory.GetRepository();

            try
            {
                var parameters = new AdminVehicleSearchParameters()
                {
                    AdminMinPrice = adminMinPrice,
                    AdminMaxPrice = adminMaxPrice,
                    AdminMinYear = adminMinYear,
                    AdminMaxYear = adminMaxYear,
                    AdminMakeName = adminMakeName,
                    AdminModelName = adminModelName,
                    AdminYear = adminYear
                };
                var result = repo.AdminSearch(parameters);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
