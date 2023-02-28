using Website.Biz.Dto;
using Website.Entity.Model;
using Website.Entity.Entities;
using AutoMapper;
using Website.Shared.Extensions;

namespace Website.Biz.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserSignUpInputDto, UserSignUpInputModel>();
            CreateMap<UserSignUpInputModel, User>()
                .ForMember(d => d.PasswordHash, o => o.Ignore());
            CreateMap<UserSignInOutputModel, UserSignInOutputDto>();
            CreateMap<User, CurrentUserOutputModel>();
            CreateMap<CurrentUserOutputModel, CurrentUserOutputDto>();
            CreateMap<StaffRegisterInputDto, StaffRregisterInputModel>();
            CreateMap<StaffRregisterInputModel, User>()
                .ForMember(d => d.PasswordHash, o => o.Ignore());
            CreateMap<User, StaffOutputModel>();
            CreateMap<StaffOutputModel, StaffOutputDto>();

            //post
            CreateMap<PostInputModel, Post>()
                .ForMember(d => d.Thumbnail, o => o.Ignore());
                //.ForMember(d => d.CreateDate, o => o.Ignore())
                //.ForMember(d => d.CreateUser, o => o.Ignore())
                //.ForMember(d => d.ModifyDate, o => o.Ignore())
                //.ForMember(d => d.ModifyUser, o => o.Ignore());
            CreateMap<Post, PostOutputModel>()
                .ForMember(d => d.Thumbnail, opt => opt.MapFrom(src => src.Thumbnail.ConvertFromJson<FileModel>()));
            //end post

            CreateMap<ShopInputModel, Shop>()
                .ForMember(d => d.Thumbnail, o => o.Ignore())
                .ForMember(d => d.CreateDate, o => o.Ignore())
                .ForMember(d => d.CreateUser, o => o.Ignore())
                .ForMember(d => d.ModifyDate, o => o.Ignore())
                .ForMember(d => d.ModifyUser, o => o.Ignore());
            CreateMap<Shop, ShopOutputModel>()
                .ForMember(d => d.Thumbnail, opt => opt.MapFrom(src => src.Thumbnail.ConvertFromJson<FileModel>()));
        }
    }
}
