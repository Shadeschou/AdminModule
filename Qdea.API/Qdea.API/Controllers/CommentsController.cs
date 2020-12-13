using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Qdea.API.Data;
using System.Collections.Generic;
using DataLayer.Dtos;
using Qdea.API.Domain;

namespace Qdea.API.Controllers
{
    [Route("api/comments")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IComments _repository;
        private readonly IMapper _mapper;

        public CommentsController(IComments repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CommentReadDto>> GetAllComments()
        {
            var commentItems = _repository.GetAllComments();
            return Ok(_mapper.Map<IEnumerable<CommentReadDto>>(commentItems));
        }

        [HttpGet("{id}", Name = "GetCommentById")]
        public ActionResult<CommentReadDto> GetCommentById(int id)
        {
            var CommentItem = _repository.GetCommentById(id);
            if (CommentItem != null)
            {
                return Ok(_mapper.Map<CommentReadDto>(CommentItem));
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult<CommentReadDto> CreateComment(CommentCreateDto CommentCreateDto)
        {
            var CommentModel = _mapper.Map<Comment>(CommentCreateDto);
            _repository.CreateComment(CommentModel);
            _repository.SaveChanges();
            var outPut = _mapper.Map<CommentReadDto>(CommentModel);
            return CreatedAtRoute(nameof(GetCommentById), new { ID = outPut.CommentID }, outPut);
            //return Ok(_mapper.Map<CommentReadDto>(CommentModel));
        }

        [HttpPut("{id}")]
        public ActionResult UpdateComment(int id, CommentUpdateDto commentUpdateDto)
        {
            var commentModel = _repository.GetCommentById(id);
            if (commentModel == null) return NotFound();
            _mapper.Map(commentUpdateDto, commentModel);
            _repository.UpdateComment(commentModel);
            _repository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteComment(int id)
        {
            var CommentToDelete = _repository.GetCommentById(id);
            _repository.DeleteComment(CommentToDelete);
            _repository.SaveChanges();
            return NoContent();
        }
    }
}