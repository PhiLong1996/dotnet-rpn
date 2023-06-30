using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dotnet_rpn.Dtos.Character;

namespace dotnet_rpn.Services.CharacterService
{
    public class CharacterService : IChracterService
    {
        private static List<Character> characters = new List<Character>()
        {
            new Character(),
            new Character()
            {
                Name = "Same",
                Id = 1
            }
                
        };

        private readonly IMapper _mapper;
        public CharacterService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<GetCharaterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            
            Character character = _mapper.Map<Character>(newCharacter);
            character.Id = characters.Max(c => c.Id) + 1;
            characters.Add(character);
            List<GetCharaterDto> GetCharaterDtoList = characters.Select(x => _mapper.Map<GetCharaterDto>(x)).ToList();
            var serviceResponse = new ServiceResponse<List<GetCharaterDto>>();
            serviceResponse.Data = GetCharaterDtoList;
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharaterDto>>> GetAllCharater()
        {
            var serviceResponse = new ServiceResponse<List<GetCharaterDto>>();
            serviceResponse.Data = characters.Select(x => _mapper.Map<GetCharaterDto>(x)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharaterDto>> GetCharacterById(int id)
        {
            Character character = characters.Where(c => c.Id == id).FirstOrDefault();
            var serviceResponse = new ServiceResponse<GetCharaterDto>();
            serviceResponse.Data = _mapper.Map<GetCharaterDto>(character);
            return serviceResponse;
        }
    }
}