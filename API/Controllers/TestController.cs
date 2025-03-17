using Microsoft.AspNetCore.Mvc;
using TaskManagement.Infrastructure.Persistence;

namespace TaskManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TestController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("test-database")]
        public IActionResult TestDatabase()
        {
            try
            {
                // Tenta conectar ao banco de dados
                _context.Database.CanConnect();

                return Ok("Conexão com o banco de dados funcionando corretamente!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao conectar ao banco de dados: {ex.Message}");
            }
        }
    }
}