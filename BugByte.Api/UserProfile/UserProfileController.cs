
using BugByte.Data.Database;
using BugByte.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BugByte_BE.userProfile;

[ApiController]
[Route("/api/UserProfiles")]
public class UserProfileController: ControllerBase
{
    private readonly ApplicationDbContext _dbContext;
    public UserProfileController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterUser(UserProfile newUser)
    {
        
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        newUser.Created = DateTime.UtcNow;
        newUser.Updated = DateTime.UtcNow;
        
        _dbContext.UserProfiles.Add(newUser);
        await _dbContext.SaveChangesAsync();
        
        return CreatedAtAction(nameof(RegisterUser), newUser);

    }
    [HttpGet("getAll")]
    public async Task<ActionResult<IEnumerable<UserProfile>>> GetAllUsers()
    {
        try
        {

            var users = await _dbContext.UserProfiles.ToListAsync();


            return Ok(users);
        }
        catch (Exception ex)
        {

            return StatusCode(500, "An error occurred while fetching user profiles.");
        }
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<UserProfile>> GetUserById(string id)
    {
        try
        {

            var user = await _dbContext.UserProfiles.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "An error occurred while fetching the user profile.");
        }
        
        
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUserById(string id)
    {
    var user = await _dbContext.UserProfiles.FindAsync(id);

        if (user == null)
    {
        return NotFound();
    }

    _dbContext.UserProfiles.Remove(user);
    await _dbContext.SaveChangesAsync();

        return NoContent();
}
    }



    
