using AutoMapper;
using System.Linq.Expressions;

namespace MapegServisGuzergah.Bll.Helper
{
    public static class CustomMapper
    {
        public static TDto Map<TEntity, TDto>(TEntity entity)
        {
            //Create a map
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TEntity, TDto>();
            });

            IMapper mapper = config.CreateMapper();

            //Use the created map
            var dest = mapper.Map<TEntity, TDto>(entity);
            return dest;
        }

        public static TDto Map<TEntity, TDto>(TEntity entity, TDto destination)
        {
            //Create a map
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TEntity, TDto>();
            });

            IMapper mapper = config.CreateMapper();

            //Use the created map
            var dest = mapper.Map<TEntity, TDto>(entity, destination);
            return dest;
        }

        public static List<TDto> MapList<TEntity, TDto>(List<TEntity> entity, List<TDto> destination)
        {
            foreach (var item in entity)
            {
                destination.Add(Map<TEntity, TDto>(item));
            }
            //Create a map
            return destination;
        }

        public static IMappingExpression<TSource, TDestination> Ignore<TSource, TDestination>(
            this IMappingExpression<TSource, TDestination> map,
                Expression<Func<TDestination, object>> selector)
        {
            map.ForMember(selector, config => config.Ignore());
            return map;
        }
    }
}
