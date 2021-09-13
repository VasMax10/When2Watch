using AutoMapper;
using When2Watch.BLL.DTO;
using When2Watch.DAL.Database.Entities;

namespace When2Watch.BLL.Mappers
{
    public class CommentMappingProfile : Profile
    {
        public CommentMappingProfile()
        {
            CreateMap<CommentEntity, CommentDTO>();
            CreateMap<CommentDTO, CommentEntity>();
        }
    }
}
