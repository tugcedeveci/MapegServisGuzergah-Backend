using LinqKit;
using MapegServisGuzergah.Bll.Abstract;
using MapegServisGuzergah.Entity.Entities;
using MapegServisGuzergah.Models.View_Models;
using MapegServisGuzergah.Models;
using Microsoft.AspNetCore.Mvc;
using MapegServisGuzergah.Bll.Concrete;
using MapegServisGuzergah.Dal.Concrete.EntityFramework.Dal;
using MapegServisGuzergah.Models.Data_Transfer_Object;
using MapegServisGuzergah.Bll.Helper;

namespace MapegServisGuzergah.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServiceController : BaseController
    {
        private readonly ILogger<ServiceController> _logger;

        private readonly IVoyageBll _voyageBll;

        private readonly IVehicleBll _vehicleBll;

        private readonly IStationBll _stationBll;

        private readonly IRouteBll _routeBll;

        public ServiceController(IHttpContextAccessor _httpContextAccessor, ILogger<ServiceController> logger, IVoyageBll voyageBll, IVehicleBll vehicleBll, IStationBll stationBll, IRouteBll routeBll) : base(_httpContextAccessor)
        {
            _logger = logger;
            _voyageBll = voyageBll;
            _vehicleBll = vehicleBll;
            _stationBll = stationBll;
            _routeBll = routeBll;
        }

        [HttpGet]
        [Route("GetUser")]
        public User GetUser(int userId)
        {
            return _voyageBll.GetUser(userId);
        }

        [HttpPost]
        [Route("SaveUser")]
        public User SaveUser(User user)
        {
            return _voyageBll.SaveUserVoyage(user);
        }

        /*******************Voyage Controller**********************/

        //Save
        [HttpPost]
        [Route("SaveVoyage")]
        public Response<VoyageDto> SaveVoyage(VoyageDto voyage)
        {
            var retunObject = new Response<VoyageDto>();

            var voyageObject = _voyageBll.SaveVoyage(voyage, _userId);

            retunObject.Model = voyageObject;

            return retunObject;
        }

        //Get

        [HttpGet]
        [Route("GetVoyage")]
        public Response<VoyageDto> GetVoyage(int voyageId)
        {
            var returnObject=new Response<VoyageDto>();

            var voyageDto=new VoyageDto();

            var voyage = _voyageBll.GetVoyage(voyageId);

            CustomMapper.Map(voyage, voyageDto);    

            returnObject.Model = voyageDto;

            return returnObject;

        }
        //GetList

        [HttpPost]
        [Route("GetVoyageList")]
        public IActionResult GetVoyageList(VoyageFilter model)
        {
            try
            {
                var response = new Response<DTGenericResult<VmVoyageList>>();
                var predicate = PredicateBuilder.New<Voyage>(x => true);
                if (model.VoyageId != null && model.VoyageId != 0)
                {
                    predicate = predicate.And(x => x.VoyageId == model.VoyageId);
                }

                if (!string.IsNullOrEmpty(model.VoyageName))
                {
                    predicate = predicate.And(x => x.VoyageName.ToUpper().Contains(model.VoyageName.ToUpper()));
                }


                var VoyageDtoList = new List<VmVoyageList>();

                var voyageList = new List<Voyage>();
                voyageList = _voyageBll.GetVoyageList(predicate)
                    .Skip(model.Start).Take(model.Length).ToList();

                var genericResult = new DTGenericResult<VmVoyageList>();
                var resultCount = _voyageBll.GetVoyageList(predicate).Count;
                genericResult.recordsTotal = resultCount;
                genericResult.data = VoyageDtoList;
                genericResult.draw = model.Draw;
                genericResult.recordsFiltered = resultCount;

                response.Model = genericResult;
                response.IsSuccess = true;
                response.MessageTitle = "Başarı";
                response.MessageCode = 200;

                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(new Response<VehicleDto>
                {
                    IsSuccess = false,
                    MessageTitle = "Hata.",
                    MessageDetail = ex.ToString(),
                    MessageCode = 404
                });
            }
        }

        /*************VoyageStatiton***********/

        //Save
        [HttpPost]
        [Route("SaveVoyageStation")]
        public VoyageStations SaveVoyageStation(VoyageStations voyageStation)
        {

            return _voyageBll.SaveVoyageStations(voyageStation);
        }

        //Get

        /* [HttpGet]
         public VoyageStation GetVoyageStation(int voyageStationId)
         {
             return _voyageBll.GetVoyageStation(voyageStationId);
         } */

        /*************Vehicle Controller*************/

        //Save
        [HttpPost]
        [Route("SaveVehicle")]
        public Response<VehicleDto> SaveVehicle(VehicleDto vehicle)
        {
            var retunObject = new Response<VehicleDto>();

            var vehicleObject = _vehicleBll.SaveVehicle(vehicle, _userId);

            retunObject.Model = vehicleObject;

            return retunObject;
        }


        //Get
        [HttpGet]
        [Route("GetVehicle")]
        public Response<VehicleDto> GetVehicle(int vehicleId)
        {
            var returnObject = new Response<VehicleDto>();

            var vehicleDto = new VehicleDto();

            var vehicle = _vehicleBll.GetVehicle(vehicleId);

            CustomMapper.Map(vehicle, vehicleDto);

            returnObject.Model = vehicleDto;

            return returnObject;

        }

        //GetList

        [HttpPost]
        [Route("GetVehicleList")]
        public IActionResult GetVehicleList(VehicleFilter model)
        {
            try
            {
                var response = new Response<DTGenericResult<VmVehicleList>>();
                var predicate = PredicateBuilder.New<Vehicle>(x => true);
                if (model.VehicleId != null && model.VehicleId != 0)
                {
                    predicate = predicate.And(x => x.VehicleId == model.VehicleId);
                }

                if (!string.IsNullOrEmpty(model.Plate))
                {
                    predicate = predicate.And(x => x.Plate.ToUpper().Contains(model.Plate.ToUpper()));
                }

                var VehicleDtoList = new List<VmVehicleList>();

                var vehicleList = new List<Vehicle>();
                vehicleList = _vehicleBll.GetVehicleList(predicate)
                   .Skip(model.Start).Take(model.Length).ToList();


                var genericResult = new DTGenericResult<VmVehicleList>();
                var resultCount = _vehicleBll.GetVehicleList(predicate).Count;
                genericResult.recordsTotal = resultCount;
                genericResult.data = VehicleDtoList;
                genericResult.draw = model.Draw;
                genericResult.recordsFiltered = resultCount;

                response.Model = genericResult;
                response.IsSuccess = true;
                response.MessageTitle = "Başarı";
                response.MessageCode = 200;

                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(new Response<VehicleDto>
                {
                    IsSuccess = false,
                    MessageTitle = "Hata.",
                    MessageDetail = ex.ToString(),
                    MessageCode = 404
                });
            }
        }

        /************Station Controller***********/

        [HttpGet]
        [Route("GetStation")]
        public Response<StationDto> GetStation(int stationId)
        {
            var returnObject = new Response<StationDto>();

            var stationDto = new StationDto();

            var station = _stationBll.GetStation(stationId);

            CustomMapper.Map(station, stationDto);

            returnObject.Model = stationDto;

            return returnObject;

        }

        [HttpPost]
        [Route("SaveStation")]
        public Response<StationDto> SaveStation(StationDto station)
        {
            var retunObject = new Response<StationDto>();

            var stationObject = _stationBll.SaveStation(station, _userId);

            retunObject.Model = stationObject;

            return retunObject;
        }


        [HttpPost]
        [Route("GetStationList")]
        public IActionResult GetStaionList(StationFilter model)
        {
            try
            {
                var response = new Response<DTGenericResult<VmStationList>>();
                var predicate = PredicateBuilder.New<Station>(x => true);
                if (model.StationId != null && model.StationId != 0)
                {
                    predicate = predicate.And(x => x.StationId == model.StationId);
                }

                if (!string.IsNullOrEmpty(model.Name))
                {
                    predicate = predicate.And(x => x.StationName.ToUpper().Contains(model.Name.ToUpper()));
                }

                var StationDtoList = new List<VmStationList>();

                var stationList = new List<Station>();
                stationList = _stationBll.GetStations(predicate)
                    .Skip(model.Start).Take(model.Length).ToList();

                var genericResult = new DTGenericResult<VmStationList>();
                var resultCount = _stationBll.GetStations(predicate).Count;
                genericResult.recordsTotal = resultCount;
                genericResult.data = StationDtoList;
                genericResult.draw = model.Draw;
                genericResult.recordsFiltered = resultCount;

                response.Model = genericResult;
                response.IsSuccess = true;
                response.MessageTitle = "Başarı";
                response.MessageCode = 200;

                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(new Response<StationDto>
                {
                    IsSuccess = false,
                    MessageTitle = "Hata.",
                    MessageDetail = ex.ToString(),
                    MessageCode = 404
                });
            }
        }

        /*****************Route Controller****************/

        [HttpGet]
        [Route("GetRoute")]
        public Response<RouteDto> GetRoute(int routeId)
        {
            var returnObject = new Response<RouteDto>();

            var routeDto = new RouteDto();
            var route = _routeBll.GetRoute(routeId);
            CustomMapper.Map(route, routeDto);

            returnObject.Model = routeDto;

            return returnObject;
        }

        [HttpPost]
        [Route("SaveRoute")]
        public Response<RouteDto> SaveRoute(RouteDto route)
        {
            var returnObject = new Response<RouteDto>();

            var routeObject = _routeBll.SaveRoute(route, _userId);

            returnObject.Model = routeObject;

            return returnObject;
        }

        [HttpPost]
        [Route("GetRouteList")]
        public IActionResult GetRouteList(RouteFilter model)
        {
            try
            {
                var response = new Response<DTGenericResult<VmRouteList>>();
                //var predicate = PredicateBuilder.New<Route>(x => true);
                //if (model.RouteId != null && model.RouteId != 0)
                //{
                //    predicate = predicate.And(x => x.RouteId == model.RouteId);
                //}

                //if (!string.IsNullOrEmpty(model.Name))
                //{
                //    predicate = predicate.And(x => x.RouteName.ToUpper().Contains(model.Name.ToUpper()));
                //}

                //var RouteDtoList = new List<VmRouteList>();

                //var routeList = new List<Route>();
                //routeList = _routeBll.GetRoutes(predicate)
                //    .Skip(model.Start).Take(model.Length).ToList();

                //var genericResult = new DTGenericResult<VmRouteList>();
                //var resultCount = _routeBll.GetRoutes(predicate).Count;
                //genericResult.recordsTotal = resultCount;
                //genericResult.data = RouteDtoList;
                //genericResult.draw = model.Draw;
                //genericResult.recordsFiltered = resultCount;

                //response.Model = genericResult;
                //response.IsSuccess = true;
                //response.MessageTitle = "Başarı";
                //response.MessageCode = 200;

                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(new Response<RouteDto>
                {
                    IsSuccess = false,
                    MessageTitle = "Hata.",
                    MessageDetail = ex.ToString(),
                    MessageCode = 404
                });
            }
        }
    }
}
