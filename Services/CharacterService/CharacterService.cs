using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dotnet_rpn.Dtos.Character;
using dotnet_rpn.Models;

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

        public async Task<ServiceResponse<List<GetCharaterDto>>> DeleteCharacter(int id)
        {
            ServiceResponse<List<GetCharaterDto>> serviceResponse = new ServiceResponse<List<GetCharaterDto>>();
            try
            {
                Character character = characters.First(c => c.Id == id);
                characters.Remove(character);
            
                serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharaterDto>(c)).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
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

        public async Task<ServiceResponse<List<GetCharaterDto>>> UpdateCharacter(UpdateCharaterDto updateCharaterDto)
        {
            ServiceResponse<List<GetCharaterDto>> serviceResponse = new ServiceResponse<List<GetCharaterDto>>();
            try
            {
                Character character = characters.Where(c => c.Id == updateCharaterDto.Id).FirstOrDefault();
                _mapper.Map(updateCharaterDto, character);
            
                serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharaterDto>(c)).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }
    }
}