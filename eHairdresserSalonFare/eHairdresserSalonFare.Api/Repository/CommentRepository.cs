using AutoMapper;
using eHairdresserSalonFare.Model.Requests.Comment;
using eHairdresserSalonFareBugojno.Database;
using eHairdresserSalonFareBugojno.DBContext;

namespace eHairdresserSalonFare.Api.Repository
{
    public class CommentRepository : BaseCRUDRepository<Model.Comment, object, Comment, CommentInsertRequest, CommentInsertRequest>
    {
        public CommentRepository(AppDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
