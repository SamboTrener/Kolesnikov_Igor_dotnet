using System;
using System.Linq;
using System.Threading.Tasks;
using DB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DB.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MonstersController : ControllerBase
    {
        private ApplicationContext db;

        public MonstersController(ApplicationContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public async Task<Monster> GetRandomMonster()
        {
            var count = await db.Monsters.CountAsync();

            if (count == 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            var rndSkip = new Random().Next(0, count);
            return await db.Monsters.Skip(rndSkip).FirstAsync();
        }
    }
}