using AutoMapper;
using MovieStoreApi.Domain;
using MovieStoreApi.Service.Models;

namespace MovieStoreApi.Service.MappingProfile.v1
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<MovieModel, Movie>();

            //Map JSON Object to Domain Entity
            CreateMap<MovieTransformModel, Movie>()
                .ForMember(c => c.TmdbId, options => options.MapFrom(m => m.TmdbId))
                .ForMember(c => c.OverView, options => options.MapFrom(m => m.OverView))
                .ForMember(c => c.Title, options => options.MapFrom(m => m.Title))
                .ForMember(c => c.Video, options => options.MapFrom(m => m.Video))
                .ForMember(c => c.VoteAverage, options => options.MapFrom(m => m.VoteAverage))
                .ForMember(c => c.Adult, options => options.MapFrom(m => m.Adult))
                .ForMember(c => c.ReleaseDate, options => options.MapFrom(m => m.RelaseDate))
                .ForMember(c => c.Critics, options => options.Ignore());

            CreateMap<Movie, MovieModel>()
              .ForMember(c => c.UserRating, options => options.MapFrom(m => m.Critics[0].Rating))
              .ForMember(c => c.UserComment, options => options.MapFrom(m => m.Critics[0].Comment));
        }
    }
}
