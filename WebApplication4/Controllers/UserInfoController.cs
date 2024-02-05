using Microsoft.AspNetCore.Mvc;
using WebApplication4.Data;
using WebApplication4.Models;
using AutoMapper;
using WebApplication4.DTO;

namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfoController : ControllerBase
    {
        private readonly IUserInfoApiRepository _dataApiRepository;

        private readonly IMapper _mapper;


        public UserInfoController(IUserInfoApiRepository repository, IMapper mapper)
        {
            _dataApiRepository = repository;

            _mapper = mapper;
        }



        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var userInfoModel = await _dataApiRepository.GetAll();

            return Ok(_mapper.Map<IEnumerable<UserInfoReadDto>>(userInfoModel));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var userInfoModel = await _dataApiRepository.GetById(id);
            if (userInfoModel == null)
                return NotFound();

            return Ok(_mapper.Map<UserInfoReadDto>(userInfoModel));
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(UserInfoCreateDto dto)
        {
            var userInfo = _mapper.Map<UserInfo>(dto);

            await _dataApiRepository.CreateUser(userInfo);
            await _dataApiRepository.SaveChangesAsync();
            var userReadDto = _mapper.Map<UserInfoReadDto>(userInfo);

            return Created("", userInfo);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var getUser = await _dataApiRepository.GetById(id);

            if(getUser == null) return NotFound();

            _dataApiRepository.DeleteUser(getUser);

            await _dataApiRepository.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> EditUser(int id, UserInfoUpdateDto dto)
        {
            var editUser = await _dataApiRepository.GetById(id);

            if(editUser == null) return NotFound();

            _mapper.Map(dto, editUser);

            _dataApiRepository.EditUser(editUser);

            await _dataApiRepository.SaveChangesAsync();

            return NoContent();
        }

    }
}
