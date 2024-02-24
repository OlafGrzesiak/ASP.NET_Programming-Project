using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorium3_App.Controllers
{
    [Route("api/organizations")]
    [ApiController]
    public class OrganizationsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrganizationsController(AppDbContext context)
        {
            _context = context;
        }

        [Route("filter")]
        public IActionResult GetFilteredOrganizations(string query)
        {
            var result = _context.Organizations
                .Where(o => o.Name.ToUpper().StartsWith(query.ToUpper()))
                .Select(o => new
                {
                    Id = o.Id,
                    Name = o.Name
                }).ToList();

            return Ok(result);
        }

        [Route("{id}")]
        public IActionResult GetOrganizationById(int id)
        {
            var entity = _context.Organizations
                .Find(id);
            if (entity == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(entity);
            }
        }
    }
}
