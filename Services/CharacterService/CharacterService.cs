using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dotnet_rpn.Data;
using dotnet_rpn.Dtos.Character;
using dotnet_rpn.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_rpn.Services.CharacterService
{
    public class CharacterService : IChracterService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public CharacterService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<ServiceResponse<List<GetCharaterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            
            Character character = _mapper.Map<Character>(newCharacter);
            _context.Characters.Add(character);
            await _context.SaveChangesAsync();
            List<GetCharaterDto> GetCharaterDtoList = await _context.Characters
                                                    .Select(x => _mapper.Map<GetCharaterDto>(x))
                                                    .ToListAsync();
            var serviceResponse = new ServiceResponse<List<GetCharaterDto>>();
            serviceResponse.Data = GetCharaterDtoList;
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharaterDto>>> DeleteCharacter(int id)
        {
            ServiceResponse<List<GetCharaterDto>> serviceResponse = new ServiceResponse<List<GetCharaterDto>>();
            try
            {
                var character = await _context.Characters.FirstAsync(c => c.Id == id);
                _context.Characters.Remove(character);

                await _context.SaveChangesAsync();
            
                serviceResponse.Data = await _context.Characters.Select(c => _mapper.Map<GetCharaterDto>(c)).ToListAsync();
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
            var dbCharacters = await _context.Characters.ToListAsync();
            serviceResponse.Data = dbCharacters.Select(c => _mapper.Map<GetCharaterDto>(c)).ToList();
            return serviceResponse;
        }   

        public async Task<ServiceResponse<GetCharaterDto>> GetCharacterById(int id)
        {
            Character dbCharacter = await _context.Characters.Where(c => c.Id == id).FirstOrDefaultAsync();
            var serviceResponse = new ServiceResponse<GetCharaterDto>();
            serviceResponse.Data = _mapper.Map<GetCharaterDto>(dbCharacter);
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharaterDto>>> UpdateCharacter(UpdateCharaterDto updateCharaterDto)
        {
            ServiceResponse<List<GetCharaterDto>> serviceResponse = new ServiceResponse<List<GetCharaterDto>>();
            try
            {
                var character = await _context.Characters.Where(c => c.Id == updateCharaterDto.Id).FirstOrDefaultAsync();
                _mapper.Map(updateCharaterDto, character);

                await _context.SaveChangesAsync();
                serviceResponse.Data = await _context.Characters.Select(c => _mapper.Map<GetCharaterDto>(c)).ToListAsync();
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