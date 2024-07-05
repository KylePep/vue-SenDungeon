namespace SendD.Controllers;

[ApiController]
[Route("api/[controller]")]

public class MonstersController : ControllerBase
{
  private readonly MonstersService _monstersService;
  private readonly Auth0Provider _auth;

  public MonstersController(MonstersService monstersService, Auth0Provider auth)
  {
    _monstersService = monstersService;
    _auth = auth;
  }

  [HttpPost]
  [Authorize]
  public async Task<ActionResult<Monster>> createMonster([FromBody] Monster monsterData)
  {
    try
    {
      Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
      monsterData.CreatorId = userInfo.Id;
      Monster monster = _monstersService.createMonster(monsterData);
      return Ok(monster);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet]
  public ActionResult<List<Monster>> getMonsters()
  {
    try
    {
      List<Monster> monsters = _monstersService.getMonsters();
      return Ok(monsters);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

}