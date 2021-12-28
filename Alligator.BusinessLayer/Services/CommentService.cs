using Alligator.BusinessLayer.Configuration;
using Alligator.BusinessLayer.Models;
using Alligator.DataLayer.Entities;
using Alligator.DataLayer.Repositories;
using AutoMapper;
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
        public List<CommentModel> GetAllComments(int id)
        {
            var comments = _commentRepository.GetAllCommentsByCLientId(id);
            return CustomMapper.GetInstance().Map<List<CommentModel>>(comments);
        }
        public void InsertComment(CommentModel comment)
        {
            Mapper mapper = CustomMapper.GetInstance();
            var comm = mapper.Map<Comment>(comment);
            _commentRepository.InsertCommentById(comm.Client.Id, comm.Text);
        }
        public void DeleteCommentsByClientId(int clientId)
        {
            _commentRepository.DeleteCommentById(clientId);
        }
    }
}
