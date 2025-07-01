using AutoMapper;
using EmployeeProject.Data;
using EmployeeProject.DTO;
using EmployeeProject.Models;
using EmployeeProject.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeSkillController : ControllerBase
    {
        private readonly EmployeeDbContext dbContext;
        private readonly IEmployeeSkillRepository employeeRepository;
        private readonly IMapper mapper;

        public EmployeeSkillController(EmployeeDbContext dbContext, IEmployeeSkillRepository employeeRepository, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.employeeRepository = employeeRepository;
            this.mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddEmployeeRequestDto addemployeeRequestDto)
        {
            // Map or Convert DTO to Domain Model

            var employeeDomainModel = mapper.Map<EmployeeSkill>(addemployeeRequestDto);
            //var regionDomainModel = new Region
            //{
            //    Code = addRegionRequestDto.Code,
            //    Name = addRegionRequestDto.Name,
            //    RegionImageUrl = addRegionRequestDto.RegionImageUrl,
            //};

            //Use Domain Model to create Region

            // await dbContext.Regions.AddAsync(regionDomainModel);
            employeeDomainModel = await employeeRepository.CreateAsync(employeeDomainModel);

            //Map Domain model back to DTO
            var employeeDto = mapper.Map<EmployeeDto>(employeeDomainModel);
            //var regionDto = new RegionDto
            //{
            //    Id = regionDomainModel.Id,
            //    Code = regionDomainModel.Code,
            //    Name = regionDomainModel.Name,
            //    RegionImageUrl = regionDomainModel.RegionImageUrl,
            //};

            return CreatedAtAction(nameof(GetById), new { id = employeeDto.Id }, employeeDto);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {            //  var region = dbContext.Regions.Find(id);
            //Get Region Domain Model From Database
            // var regionDomain = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            //var regionDomain = await regionRepository.GetById(id);
            var employeeDomain = await employeeRepository.GetByIdAsync(id);


            if (employeeDomain == null)
            {
                return NotFound();
            }


            //Map/Convert Region Domain Model to Region DTO
            //var regionsDto = new RegionDto
            //{
            //    Id = regionDomain.Id,
            //    Code = regionDomain.Code,
            //    Name = regionDomain.Name,
            //    RegionImageUrl = regionDomain.RegionImageUrl,
            //};
            //Return DTO back to client
            return Ok(mapper.Map<EmployeeDto>(employeeDomain));
        }
    }
}
