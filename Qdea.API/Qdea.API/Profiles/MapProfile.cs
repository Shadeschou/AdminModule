using AutoMapper;
using DataLayer.Dtos;
using Qdea.API.Domain;


namespace Qdea.Back.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Challenge, ChallengeReadDto>();
            CreateMap<ChallengeCreateDto, Challenge>();
            CreateMap<ChallengeUpdateDto, Challenge>();
            CreateMap<Comment, CommentReadDto>();
            CreateMap<CommentCreateDto, Comment>();
            CreateMap<CommentUpdateDto, Comment>();
            CreateMap<Company, CompanyReadDto>();
            CreateMap<CompanyCreateDto, Company>();
            CreateMap<CompanyUpdateDto, Company>();
            CreateMap<CostSaving, CostSavingReadDto>();
            CreateMap<CostSavingCreateDto, CostSaving> ();
            CreateMap<CostSavingUpdateDto, CostSaving>();
            CreateMap<Idea, IdeaReadDto>();
            CreateMap<IdeaCreateDto, Idea>();
            CreateMap<IdeaUpdateDto, Idea>();
            CreateMap<IdeaStatus, IdeaStatusReadDto>();
            CreateMap<IdeaStatusCreateDto, IdeaStatus>();
            CreateMap<IdeaStatusUpdateDto, IdeaStatus>();
            CreateMap<Priority, PriorityReadDto>();
            CreateMap<PriorityCreateDto, Priority>();
            CreateMap<PriorityUpdateDto, Priority>();
            CreateMap<Result, ResultReadDto>();
            CreateMap<ResultCreateDto, Result>();
            CreateMap<ResultUpdateDto, Result>();
            CreateMap<Tag, TagReadDto>();
            CreateMap<TagCreateDto, Tag>();
            CreateMap<TagUpdateDto, Tag>();
            CreateMap<TagIdea, TagIdeaReadDto>();
            CreateMap<TagIdeaCreateDto, TagIdea>();
            CreateMap<TagIdeaUpdateDto, TagIdea>();
            CreateMap<User, UserReadDto>();
            CreateMap<UserCreateDto, User>();
            CreateMap<UserUpdateDto, User>();
            CreateMap<UserIdea, UserIdeaReadDto>();
            CreateMap<UserIdeaCreateDto, UserIdea>();
            CreateMap<UserIdeaUpdateDto, UserIdea>();
            CreateMap<UserStatus, UserStatusReadDto>();
            CreateMap<UserStatusCreateDto, UserStatus>();
            CreateMap<UserStatusUpdateDto, UserStatus>();
        }
    }
}