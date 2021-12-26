using Alligator.BusinessLayer.Configuration;
using Alligator.BusinessLayer.Models;
using Alligator.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alligator.BusinessLayer.Services
{
    public class CommentService
    {
        private readonly CommentRepository _commentRepository;
        public CommentService()
        {
            _commentRepository = new CommentRepository();
        }
        public List<CommentModel> GetAllComments()
        {
            var comments = _commentRepository.GetAllComments();
            return CustomMapper.GetInstance().Map<List<CommentModel>>(comments);
        }
    }
}
