using AutoMapper;
using Birlik.Core.Interfaces;
using Birlik.Data.DTOs;
using Birlik.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace Birlik.Api.Controllers
{
    [ApiController]
    [Route("api/teachers")]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IFileRepository _fileRepository;
        private readonly IWebHostEnvironment _env;
        private readonly IMapper _mapper;

        public TeacherController(ITeacherRepository teacherRepository, IFileRepository fileRepository, IWebHostEnvironment env, IMapper mapper)
        {
            _teacherRepository = teacherRepository;
            _fileRepository = fileRepository;
            _env = env;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<TeacherDTO>> GetTeachersAsync()
        {
            return (await _teacherRepository.GetAllAsync()).Select(model=>{
                var dto = new TeacherDTO();
                return _mapper.Map<Teacher, TeacherDTO>(model, dto);
            });  
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<TeacherDTO>> GetTeacherAsync(int id)
        {
            var existingModel = await _teacherRepository.GetAsync(id);
            if(existingModel is null)
            {
                return NotFound();
            }
            var modelDTO = _mapper.Map<TeacherDTO>(existingModel);
            return Ok(modelDTO);
        }
        [HttpPost]
        public async Task<ActionResult<TeacherDTO>> CreateTeacherAsync([FromForm]CreateTeacherDTO createTeacherDTO)
        {   
            var existingModel = await _teacherRepository.GetAsync(createTeacherDTO.UIN);
            if(existingModel is not null)
            {
                return BadRequest();
            }
            int resumeId = await _fileRepository.CreateFileAsync(_env.ContentRootPath, "Resumes", createTeacherDTO.Resume);

            var entity = _mapper.Map<CreateTeacherDTO, Teacher>(createTeacherDTO, new Teacher());
            entity.ResumeId = resumeId;
            entity.Id = await _teacherRepository.CreateAsync(entity);
            // resumeFile.TeacherId = entity.Id;
            var dto = _mapper.Map<Teacher, TeacherDTO>(entity, new TeacherDTO());
            dto.Resume = createTeacherDTO.Resume.FileName;
            // dto.Pedemastership = Enum.GetName(typeof(Pedemastership), Convert.ToInt32(dto.Pedemastership));  
            return CreatedAtAction(nameof(GetTeacherAsync), new { id = entity.Id }, entity);
        }
    }
}