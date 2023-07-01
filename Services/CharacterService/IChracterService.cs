using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_rpn.Dtos.Character;

namespace dotnet_rpn.Services.CharacterService
{
    public interface IChracterService
    {
        Task<ServiceResponse<List<GetCharaterDto>>> GetAllCharater();
        Task<ServiceResponse<GetCharaterDto>> GetCharacterById(int id);
        Task<ServiceResponse<List<GetCharaterDto>>> AddCharacter(AddCharacterDto newCharactor);
        Task<ServiceResponse<List<GetCharaterDto>>> UpdateCharacter(UpdateCharaterDto updateCharaterDto);

    }
}