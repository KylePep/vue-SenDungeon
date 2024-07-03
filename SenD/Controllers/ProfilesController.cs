using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SenD.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProfilesController : ControllerBase
{
  private readonly AccountService _accountService;

  public ProfilesController(AccountService accountService)
  {
    _accountService = accountService;
  }

  [HttpGet("{profileId}")]
  public ActionResult<Profile> getAUsersProfile(string profileId)
  {
    try
    {
      Profile profile = _accountService.getAUsersProfile(profileId);
      return Ok(profile);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
}
