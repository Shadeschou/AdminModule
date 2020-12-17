using AutoMapper;
using DataLayer.Dtos;
using Qdea.API.Domain;

namespace Qdea.API.Profiles
{
    public class DtoMaps : Profile
    {
        public DtoMaps()
        {
            CreateMap<Idea, IdeaReadDto>();
            CreateMap<IdeaCreateDto, Idea>();
            CreateMap<IdeaUpdateDto, Idea>();
            CreateMap<IdeaStatus, IdeaStatusReadDto>();
            CreateMap<IdeaStatusCreateDto, IdeaStatus>();
            CreateMap<IdeaStatusUpdateDto, IdeaStatus>();
            CreateMap<Priority, PriorityReadDto>();
            CreateMap<PriorityCreateDto, Priority>();
            CreateMap<PriorityUpdateDto, Priority>();
            CreateMap<Tag, TagReadDto>();
            CreateMap<TagCreateDto, Tag>();
            CreateMap<TagUpdateDto, Tag>();
            CreateMap<TagIdea, TagIdeaReadDto>();
            CreateMap<TagIdeaCreateDto, TagIdea>();
            CreateMap<TagIdeaUpdateDto, TagIdea>();
            CreateMap<User, UserReadDto>();
            CreateMap<UserCreateDto, User>();
            CreateMap<UserUpdateDto, User>();
            CreateMap<UserStatus, UserStatusReadDto>();
            CreateMap<UserStatusCreateDto, UserStatus>();
            CreateMap<UserStatusUpdateDto, UserStatus>();
            CreateMap<IdeaInteraction, IdeaInteractionReadDto>();
            CreateMap<IdeaInteractionCreateDto, IdeaInteraction>();
            CreateMap<IdeaInteractionUpdateDto, IdeaInteraction>();
            CreateMap<IdeaInteractionType, IdeaInteractionTypeReadDto>();
            CreateMap<IdeaInteractionTypeCreateDto, IdeaInteractionType>();
            CreateMap<IdeaInteractionTypeUpdateDto, IdeaInteractionType>();
            CreateMap<Impact, ImpactReadDto>();
            CreateMap<ImpactCreateDto, Impact>();
            CreateMap<ImpactUpdateDto, Impact>();
            CreateMap<Effort, EffortReadDto>();
            CreateMap<EffortCreateDto, Effort>();
            CreateMap<EffortUpdateDto, Effort>();
            CreateMap<AddedUser, AddedUserReadDto>();
            CreateMap<AddedUserCreateDto, AddedUser>();
            CreateMap<AddedUserUpdateDto, AddedUser>();
        }
    }
}