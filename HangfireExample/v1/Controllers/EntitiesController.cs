using Hangfire;
using HangfireExample.enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace HangfireExample.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EntitiesController : ControllerBase
    {
        private readonly IBackgroundJobClient _backgroundJobs;
        private readonly IConfiguration _configuration;

        public EntitiesController(IBackgroundJobClient backgroundJobs, IConfiguration configuration)
        {
            _backgroundJobs = backgroundJobs;
            _configuration = configuration;
        }

        [HttpGet("{name}")]
        public IActionResult Get(string name)
        {
            _backgroundJobs.Enqueue(() => AddUser(name));
            return Ok("task enqueued");
        }

        [Queue(HangfireQueue.CRITICAL)]
        //[Queue(HangfireQueue.HIGH)]
        //[Queue(HangfireQueue.LOW)]
        public async Task AddUser(string name)
        {
            var connStr = _configuration.GetConnectionString("DatabaseTestConnection");
            using (var con = new SqlConnection(connStr))
            {
                con.Open();
                var sql = $@"INSERT INTO dbo.Users (name) VALUES ('{name}');";
                //var sql = $@"INSERT INTO dbo.Users (name) VALUES ('\'{name}');";
                using (var cmd = new SqlCommand(sql, con))
                {
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
