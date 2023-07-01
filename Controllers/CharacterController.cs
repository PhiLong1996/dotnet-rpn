using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dotnet_rpn.Services.CharacterService;
using dotnet_rpn.Dtos.Character;

namespace dotnet_rpn.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController: ControllerBase
    {
        private readonly IChracterService CharacterService;
        public CharacterController(IChracterService characterService)
        {
            this.CharacterService = characterService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetCharaterDto>>>> Get()
        {
            return Ok(await CharacterService.GetAllCharater());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCharaterDto>>> GetSingleCharacter(int id)
        {
            return Ok(await CharacterService.GetCharacterById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetCharaterDto>>>> AddCharacter(AddCharacterDto character)
        {
            return Ok(await CharacterService.AddCharacter(character));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<GetCharaterDto>>>> AddCharacter(UpdateCharaterDto character)
        {
            return Ok(await CharacterService.UpdateCharacter(character));
        }

    }
}