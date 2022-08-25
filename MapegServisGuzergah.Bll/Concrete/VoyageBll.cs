using MapegServisGuzergah.Bll.Abstract;
using MapegServisGuzergah.Bll.Helper;
using MapegServisGuzergah.Dal.Abstract;
using MapegServisGuzergah.Entity.Entities;
using MapegServisGuzergah.Models.Data_Transfer_Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MapegServisGuzergah.Bll.Concrete
{
    public class VoyageBll : IVoyageBll
    {
        private readonly IUserDal _userDal;
        private readonly IVoyageDal _voyageDal;
        private readonly IVoyageStationDal _voyageStationDal;
        public VoyageBll(IUserDal userDal, IVoyageDal voyageDal, IVoyageStationDal voyageStationDal)
        {
            _userDal = userDal;
            _voyageDal = voyageDal;
            _voyageStationDal = voyageStationDal;
        }
        public User GetUser(int userId)
        {
            return _userDal.Get(x => x.UserId == userId);
        }

        public User SaveUserVoyage(User user)
        {
            var dbUser = _userDal.Get(x => x.UserId == user.UserId);
            // var voyageUser = _voyageDal.Get(x => x.VoyageId == user.VoyageId);

            if (dbUser == null)
            {
                user.CreatedDate = DateTime.Now;
                _userDal.Add(user);
            }
            else
            {
                user.ModifiedDate = DateTime.Now;
                _userDal.Update(user);
            }

            return user;
        }

        //List
        public List<Voyage> GetVoyageList(Expression<Func<Voyage, bool>> expression)
        {
            return _voyageDal.GetAll(expression).ToList();
        }

        //Save

        public VoyageDto SaveVoyage(VoyageDto voyageDto, long userId)
        {
            //Insert
            var voyage = new Voyage();

            if (voyageDto.VoyageId == 0)
            {
                CustomMapper.Map(voyageDto, voyage);
                voyage.UserCreatedId = userId;
                voyage.IsActive = true;
                _voyageDal.Add(voyage);
            }
            //Update
            else
            {
                voyage = _voyageDal.Get(x => x.VoyageId == voyageDto.VoyageId);
                CustomMapper.Map(voyageDto, voyage);
                voyage.ModifiedDate = DateTime.Now;
                voyage.UserModifiedId = userId;
                _voyageDal.Update(voyage);
            }

            voyageDto.VoyageId = voyage.VoyageId;
            return voyageDto;
        }

        //Get
        public Voyage GetVoyage(int voyageId)
        {
            return _voyageDal.Get(x => x.VoyageId == voyageId);
        }


        /*************VoyageStation************/


        public List<VoyageStations> GetVoyageStationByVoyageIdList(int VoyageId)
        {
            return _voyageStationDal.GetAll(x => x.VoyageId == VoyageId).ToList();
        }
        public List<VoyageStations> GetVoyageStationByStationIdList(int StationId)
        {
            return _voyageStationDal.GetAll(x => x.StationId == StationId).ToList();
        }

        //Save VoyageStation

        public VoyageStations SaveVoyageStations(VoyageStations voyageStations)
        {
            var voyageStationn = _voyageStationDal.Get(x => x.VoyageStationId == voyageStations.VoyageStationId);

            if (voyageStationn == null)
            {
                voyageStations.CreatedDate = DateTime.Now;
                _voyageStationDal.Add(voyageStations);
            }
            else
            {
                voyageStations.ModifiedDate = DateTime.Now;
                _voyageStationDal.Update(voyageStations);
            }

            return voyageStations;
        }

    }
}
