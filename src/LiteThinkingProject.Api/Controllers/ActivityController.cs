using LiteThinkingProject.Application.UseCase.Activity.Commands.ActivityCreateCommand;
using LiteThinkingProject.Application.UseCase.Activity.Commands.ActivityDeleteCommand;
using LiteThinkingProject.Application.UseCase.Activity.Commands.ActivityUpdateCommand;
using LiteThinkingProject.Application.UseCase.Activity.Queries.ActivityGetAllQuery;
using LiteThinkingProject.Application.UseCase.Activity.Queries.ActivityGetByIdQuery;
using Microsoft.AspNetCore.Mvc;

namespace LiteThinkingProject.Api.Controllers
{
    //Prefijo de api
    [Route("api/[controller]")]
    public class ActivityController : BaseController
    {   
        
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var query = new ActivityGetAllQuery();
            var result = await this.Mediator.Send(query);
            return this.FromResult(result);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(ActivityGetByIdQueryModel model)
        {
            var query = this.Mapper.Map<ActivityGetByIdQuery>(model);
            var result = await this.Mediator.Send(query);
            return this.FromResult(result);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(ActivityCreateCommandModel model)
        {
            var command = this.Mapper.Map<ActivityCreateCommand>(model);
            var result = await this.Mediator.Send(command);
            return this.FromResult(result);
        }

        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> Update(ActivityUpdateCommandModel model)
        {
            var command = this.Mapper.Map<ActivityUpdateCommand>(model);
            var result = await this.Mediator.Send(command);
            return this.FromResult(result);
        }

        [HttpPost]
        [Route("Delete")]
        public async Task<IActionResult> Delete(ActivityDeleteCommandModel model)
        {
            var query = this.Mapper.Map<ActivityDeleteCommand>(model);
            var result = await this.Mediator.Send(query);
            return this.FromResult(result);
        }



    }
}
