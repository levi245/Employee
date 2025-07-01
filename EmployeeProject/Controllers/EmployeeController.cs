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
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeDbContext dbContext;
        private readonly IEmployeeRepository employeeRepository;
        private readonly IMapper mapper;
        public EmployeeController(EmployeeDbContext dbContext, IEmployeeRepository employeeRepository, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.employeeRepository = employeeRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //hard code approach
            //var regions = new List<Region>
            //{
            //    new Region
            //    {
            //        Id = Guid.NewGuid(),
            //        Name = "Auckland Region",
            //        Code = "AKL",
            //        RegionImageUrl = "https://www.pexels.com/photo/wooden-house-under-white-clouds-3750270/"
            //    },


            //     new Region
            //    {
            //        Id = Guid.NewGuid(),
            //        Name = "Wellington Region",
            //        Code = "WLG",
            //        RegionImageUrl = "https://www.pexels.com/photo/city-skyline-under-white-clouds-3709415/"
            //    }
            // };



            //var regionsDomain = await dbContext.Regions.ToListAsync();

            //Get Data From Database- Domain Model
            var employeeDomain = await employeeRepository.GetAllAsync();

            //Map Domain Models to DTOs
            //var regionsDto = new List<RegionDto>();
            //foreach (var regionDomain in regionsDomain)
            //{
            //    regionsDto.Add(new RegionDto()
            //    {
            //        Id = regionDomain.Id,
            //        Code = regionDomain.Code,
            //        Name = regionDomain.Name,
            //        RegionImageUrl = regionDomain.RegionImageUrl,
            //    });
            //}

            // Map Domain Models to DTOs
            // var regionsDto = mapper.Map<List<RegionDto>>(regionsDomain);
            // Return DTOs
            return Ok(mapper.Map<List<EmployeeDto>>(employeeDomain));
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            //  var region = dbContext.Regions.Find(id);
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

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddEmployeeRequestDto addemployeeRequestDto)
        {
            // Map or Convert DTO to Domain Model

            var employeeDomainModel = mapper.Map<Employee>(addemployeeRequestDto);
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

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateEmployeeRequestDto updateEmployeeRequestDto)
        {
            //Map DTO to Domain Model

            var employeeDomainModel = mapper.Map<Employee>(updateEmployeeRequestDto);
            //var regionDomainModel = new Region
            //{
            //    Code = updateRegionRequestDto.Code,
            //    Name = updateRegionRequestDto.Name,
            //    RegionImageUrl = updateRegionRequestDto.RegionImageUrl
            //};

            // var regionDomainModel = await dbContext.Regions.FirstOrDefaultAsync(X => X.Id == id);

            // Check if region exists
            employeeDomainModel = await employeeRepository.UpdateAsync(id,employeeDomainModel);
            if (employeeDomainModel == null)
            {
                return NotFound();
            }

            // Map DTO to Domain Model
            //regionDomainModel.Code = updateRegionRequestDto.Code;
            //regionDomainModel.Name = updateRegionRequestDto.Name;
            //regionDomainModel.RegionImageUrl = updateRegionRequestDto.RegionImageUrl;

            //await dbContext.SaveChangesAsync();

            //Convert Domain Model to DTO
            //var regionDto =mapper.Map<RegionDto>(regionDomainModel);
            //var regionDto = new RegionDto
            //{
            //    Id = regionDomainModel.Id,
            //    Code = regionDomainModel.Code,
            //    Name = regionDomainModel.Name,
            //    RegionImageUrl = regionDomainModel.RegionImageUrl
            //};

            return Ok(mapper.Map<EmployeeDto>(employeeDomainModel));
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] int id)
        {
            //var regionDomainModel = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            var employeeDomainModel = await employeeRepository.DeleteAsync(id);

            if (employeeDomainModel == null)
            {
                return NotFound();
            }

            //Delete region
            //dbContext.Regions.Remove(regionDomainModel);
            //await dbContext.SaveChangesAsync();

            //return deleted Region back
            //map Domain Model to DTO

            //var regionDto = new RegionDto
            //{
            //    Id = regionDomainModel.Id,
            //    Code = regionDomainModel.Code,
            //    Name = regionDomainModel.Name,
            //    RegionImageUrl = regionDomainModel.RegionImageUrl
            //};

            return Ok(mapper.Map<EmployeeDto>(employeeDomainModel));
        }

    }
}
