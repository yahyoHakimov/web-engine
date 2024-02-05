using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApplication4.Data;
using WebApplication4.DTO;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LogInfoController : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly ILogInfosApiRepository _repository;


        public LogInfoController(ILogInfosApiRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLogInfo()
        {
            var logInfoModel = await _repository.GetAll();

            return Ok(_mapper.Map<IEnumerable<LogInfotReadDto>>(logInfoModel));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLogInfo(int id)
        {
            var userModel = await _repository.GetById(id);
            if (userModel == null)
                return NotFound();

            return Ok(_mapper.Map<LogInfotReadDto>(userModel));
        }


        [HttpPost]
        public async Task<IActionResult> addLogInfo(LogInfoCreateDto dto)
        {
            var logInfo = _mapper.Map<LogInfo>(dto);
            await _repository.CreateLogInfo(logInfo);
            await _repository.SaveChangesAsync();

            var logInfoDto =  _mapper.Map<LogInfotReadDto>(logInfo);

            return Created("", logInfo);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLogInfo(int id)
        {
            var logInfo = await _repository.GetById(id);

            if (logInfo == null) return NotFound();

            _repository.DeleteLogInfo(logInfo);

            await _repository.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> EditLogInfo(int id, UserInfoUpdateDto dto)
        {
            var editLogInfo = await _repository.GetById(id);

            if(editLogInfo == null) return NotFound();

            _mapper.Map(dto, editLogInfo);

            _repository.EditLogInfo(editLogInfo);

            await _repository.SaveChangesAsync();

            return NoContent();
        }

    }
}
