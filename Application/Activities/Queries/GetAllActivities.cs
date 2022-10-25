using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Activities.Queries
{
    public class GetAllActivities : IRequest<List<Activity>>
    {
        
    }

    public class GetAllActivitiesHandler : IRequestHandler<GetAllActivities, List<Activity>>
    {
        private readonly DataContext _dataContext;
        public GetAllActivitiesHandler(DataContext dataContext)
        {
            _dataContext = dataContext;

        }

        public async Task<List<Activity>> Handle(GetAllActivities request, CancellationToken cancellationToken)
        {
            return await _dataContext.Activities.ToListAsync();
        }
    }
}