using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Activities.Commands
{
    public class CreateActivity : IRequest
    {
        public Activity Activity { get; set; }
    }

    public class CreateActivityHandler : IRequestHandler<CreateActivity>
    {
        private readonly DataContext _dataContext;
        public CreateActivityHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Unit> Handle(CreateActivity request, CancellationToken cancellationToken)
        {
            _dataContext.Activities.Add(request.Activity);
            await _dataContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}