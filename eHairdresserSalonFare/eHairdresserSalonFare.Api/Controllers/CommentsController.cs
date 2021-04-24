using eHairdresserSalonFare.Api.IRepository;
using eHairdresserSalonFare.Model.Requests.Comment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eHairdresserSalonFare.Api.Controllers
{
    [Route("api/comments")]
    [ApiController]
    [Authorize]
    public class CommentsController : BaseCRUDController<Model.Comment, object, CommentInsertRequest, CommentInsertRequest>
    {
        public CommentsController(IBaseCRUDRepository<Model.Comment, object, CommentInsertRequest, CommentInsertRequest> repository) : base(repository)
        {
        }
    }
}