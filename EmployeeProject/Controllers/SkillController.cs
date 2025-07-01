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
    public class SkillController : ControllerBase
    {
        private readonly EmployeeDbContext dbContext;
        private readonly ISkillRepository skillRepository;
        private readonly IMapper mapper;
        public SkillController(EmployeeDbContext dbContext, ISkillRepository skillRepository, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.skillRepository = skillRepository;
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
            var skillDomain = await skillRepository.GetAllAsync();

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
            return Ok(mapper.Map<List<SkillDto>>(skillDomain));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddSkillRequestDto addskillRequestDto)
        {
            // Map or Convert DTO to Domain Model

            var skillDomainModel = mapper.Map<Skill>(addskillRequestDto);
            //var regionDomainModel = new Region
            //{
            //    Code = addRegionRequestDto.Code,
            //    Name = addRegionRequestDto.Name,
            //    RegionImageUrl = addRegionRequestDto.RegionImageUrl,
            //};

            //Use Domain Model to create Region

            // await dbContext.Regions.AddAsync(regionDomainModel);
            skillDomainModel = await skillRepository.CreateAsync(skillDomainModel);

            //Map Domain model back to DTO
            var skillDto = mapper.Map<SkillDto>(skillDomainModel);
            //var regionDto = new RegionDto
            //{
            //    Id = regionDomainModel.Id,
            //    Code = regionDomainModel.Code,
            //    Name = regionDomainModel.Name,
            //    RegionImageUrl = regionDomainModel.RegionImageUrl,
            //};

            return CreatedAtAction(nameof(GetById), new { id = skillDto.SkillId }, skillDto);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            //  var region = dbContext.Regions.Find(id);
            //Get Region Domain Model From Database
            // var regionDomain = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            //var regionDomain = await regionRepository.GetById(id);
            var skillDomain = await skillRepository.GetByIdAsync(id);


            if (skillDomain == null)
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
            return Ok(mapper.Map<SkillDto>(skillDomain));
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateSkillRequestDto updateSkillRequestDto)
        {
            //Map DTO to Domain Model

            var skillDomainModel = mapper.Map<Skill>(updateSkillRequestDto);
            //var regionDomainModel = new Region
            //{
            //    Code = updateRegionRequestDto.Code,
            //    Name = updateRegionRequestDto.Name,
            //    RegionImageUrl = updateRegionRequestDto.RegionImageUrl
            //};

            // var regionDomainModel = await dbContext.Regions.FirstOrDefaultAsync(X => X.Id == id);

            // Check if region exists
            skillDomainModel = await skillRepository.UpdateAsync(id,skillDomainModel);
            if (skillDomainModel == null)
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

            return Ok(mapper.Map<SkillDto>(skillDomainModel));
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            //var regionDomainModel = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            var deleteSkillDomainModel = await skillRepository.DeleteAsync(id);

            if (deleteSkillDomainModel == null)
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

            return Ok(mapper.Map<SkillDto>(deleteSkillDomainModel));
        }
    }
}
