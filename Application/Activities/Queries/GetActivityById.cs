using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Activities.Queries
{
    public class GetActivityById : IRequest<Activity>
    {
        public Guid Id { get; set; }
    }

    public class GetActivityByIdHandler : IRequestHandler<GetActivityById, Activity>
    {
        private readonly DataContext _dataContext;
        public GetActivityByIdHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Activity> Handle(GetActivityById request, CancellationToken cancellationToken)
        {
            return await _dataContext.Activities.FindAsync(request.Id);
        }
    }
}