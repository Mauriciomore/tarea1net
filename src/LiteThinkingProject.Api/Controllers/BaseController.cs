using AutoMapper;
using LiteThinkingProject.Application.UseCase.Commons.Results;
using LiteThinkingProject.Shared.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LiteThinkingProject.Api.Controllers
{
    public class BaseController : Controller
    {
        private IMediator? _mediator;

        protected IMediator Mediator => this._mediator ??= EngineContext.Current.Resolve<IMediator>();

        protected IMapper Mapper => EngineContext.Current.Resolve<IMapper>();

        protected ActionResult FromResult<T>(Result<T> result) => result.ResultType switch
        {
            ResultType.Ok => this.Ok(result),
            ResultType.NotFound => this.NotFound(result),
            ResultType.Created => this.Created(string.Empty, result),
            _ => throw new Exception("Unhandled result"),
        };
    }
}
