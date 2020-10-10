﻿using MediatR;
using MoviesApi.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace MoviesApi.Application.Commands
{
    public class AddLikeCommandHandler : IRequestHandler<AddLikeCommand, bool>
    {
        private readonly IMoviesRepository _repository;
        public AddLikeCommandHandler(IMoviesRepository repository)
            => _repository = repository;

        public Task<bool> Handle(AddLikeCommand request, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                var entity = _repository.GetById(request.Id);

                if (entity == null)
                    return false;

                entity.Likes++;
                _repository.Update(entity);
                return true;
            });
        }
    }
}