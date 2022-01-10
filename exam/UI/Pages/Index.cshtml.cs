using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;
using System.Threading.Tasks;
using DB.Models;
using UI.Models;

namespace UI.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty] public CharacterModel CharacterModel { get; set; }
        [BindProperty] public Game Game { get; set; }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
                return Page();
            var httpClient = new HttpClient();
            var monster =
                await httpClient.GetFromJsonAsync<Monster>("https://localhost:5011/Monsters/GetRandomMonster");
            var monsterAndCharacter = new MonsterAndCharacter()
            {
                Monster = monster,
                Character = CharacterModel
            };
            Game = await (await httpClient.PostAsync("https://localhost:5021/Fight/StartFight",
                    JsonContent.Create(monsterAndCharacter))).Content
                .ReadFromJsonAsync<Game>();
            if (Game != null) CharacterModel = Game.Character;
            if (CharacterModel.HitPoints < 0) CharacterModel.HitPoints = 0;
            return Page();
        }
    }
}