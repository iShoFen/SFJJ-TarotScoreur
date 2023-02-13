using Microsoft.AspNetCore.Mvc;
using Model;
using Model.Players;
using RestController.DTOs;
using RestController.DTOs.Extensions;
using RestController.Filter;

namespace RestController.Controllers;

/// <summary>
/// The groups controller for REST API
/// </summary>
[ApiVersion("1.0")]
[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class GroupsController : ControllerBase
{
    /// <summary>
    /// The manager for the service
    /// </summary>
	private readonly Manager _manager;
    
    /// <summary>
    /// The logger for the service
    /// </summary>
    private readonly ILogger<GroupsController> _logger;

    /// <summary>
    /// The constructor for the service
    /// </summary>
    /// <param name="manager">The manager for the service</param>
    /// <param name="logger">The logger for the service</param>
	public GroupsController(Manager manager, ILogger<GroupsController> logger)
	{
		_manager = manager;
        _logger = logger;
        
        _logger.LogInformation("GroupsController created");
	}

	/// <summary>
	/// Get all groups
	/// </summary>
	/// <param name="paginationFilter">Page searched</param>
	/// <returns>The list of groups</returns>
	[HttpGet]
	public async Task<ActionResult> GetGroups([FromQuery] PaginationFilter paginationFilter)
	{
		var groups = (await _manager.GetGroups(paginationFilter.Page, paginationFilter.Count)).ToList();
        _logger.LogInformation("{GroupsCount} groups from {Page} page with {PageSize} size retrieved", 
            groups.Count,
            paginationFilter.Page,
            paginationFilter.Count
        );

        return Ok(groups.Select(x => x.ToGroupDTO()).ToList());
	}

	/// <summary>
	/// Get one group by the id
	/// </summary>
	/// <param name="id">Id of the group</param>
	/// <returns>The group</returns>
	[HttpGet("{id}")]
    [ActionName(nameof(GetGroup))]
    public async Task<ActionResult> GetGroup(ulong id)
	{
		var group = await _manager.GetGroupById(id);
        if (group == null)
        {
            _logger.LogWarning("Group with id {GroupId} not found", id);
            return NotFound();
        }
        _logger.LogInformation("Group with id {GroupId} retrieved", id);

        return Ok(group.ToGroupDTO());
	}

	/// <summary>
	/// Get the users from the group
	/// </summary>
	/// <param name="id">Id of the group</param>
	/// <returns>The list of users from the group</returns>
	[Route("{id}/users")]
	[HttpGet]
	public async Task<ActionResult> GetPlayersByGroupId(ulong id)
	{
		var group  = await _manager.GetGroupById(id);
        if (group == null)
        {
            _logger.LogWarning("Group with id {GroupId} not found", id);
            return NotFound();
        }
		var users = group.Players.Select(x => _manager.GetUserById(x.Id).Result).ToList();
        _logger.LogInformation("{UsersCount} users from group with id {GroupId} retrieved", users.Count, id);
        
		return Ok(users.Select(x => x?.UserToDTO()).ToList());
	}

	/// <summary>
	/// Get one user in the group wanted
	/// </summary>
	/// <param name="groupId">Id of the group</param>
	/// <param name="userId">Id of the user</param>
	/// <returns>The user</returns>
	[Route("{groupId}/users/{userId}")]
	[HttpGet]
	public async Task<ActionResult> GetPlayerByGroupId(ulong groupId, ulong userId)
	{
        var group = await _manager.GetGroupById(groupId);
        if (group == null)
        {
            _logger.LogWarning("Group with id {GroupId} not found", groupId);
            return NotFound();
        }

        var  user = await _manager.GetUserById(userId);
        if (user == null)
        {
            _logger.LogWarning("User with id {UserId} not found", userId);
            return NotFound();
        }

        if (!group.Players.Contains(user))
        {
            _logger.LogWarning("User with id {UserId} not found in group with id {GroupId}", userId, groupId);
            return NotFound();
        }
        
        var userDTO = user.UserToUserDetailDTO();
        userDTO.Games = (await _manager.GetGamesByPlayer(userId, 1, 10)).Select(x => x.Id).ToList();
        userDTO.Groups = (await _manager.GetGroupsByPlayer(userId, 1, 10)).Select(x => x.Id).ToList();
        _logger.LogInformation("User with id {UserId} from group with id {GroupId} retrieved", userId, groupId);
        
		return Ok(userDTO);
    }

    /// <summary>
    /// Create a group
    /// </summary>
    /// <param name="request">The group to insert</param>
    /// <returns>The group inserted</returns>
	[HttpPost]
	public async Task<ActionResult> PostGroup(GroupDTOPostRequest request)
	{
		var users = new List<Player>();
		foreach (var userId in request.Users)
		{
			var user = await _manager.GetUserById(userId);
			if (user is null)
			{
                _logger.LogWarning("User with id {UserId} not found", userId);
				return BadRequest($"The user with id {userId} does not exist");
			}
			users.Add(user);
		}

		var group = (await _manager.InsertGroup(request.Name, users.ToArray()))!;
        _logger.LogInformation("Group with id {GroupId} created", group.Id);
        
        return CreatedAtAction(
			nameof(GetGroup),
			new { id = group.Id },
			group.ToGroupDTO());

	}

	/// <summary>
	/// Update a group with a given id
	/// </summary>
	/// <param name="id">Id of the group</param>
	/// <param name="groupDTO">The group to update</param>
	/// <returns>The group updated</returns>
	[HttpPut("{id}")]
	public async Task<IActionResult> PutGroup(ulong id, GroupDTO groupDTO)
	{
        if (id != groupDTO.Id)
        {
            _logger.LogWarning("The url id {UrlId} does not correspond to the body id {BodyId}", id, groupDTO.Id);
            return BadRequest();
        }
		
		var users = new List<Player>();
		foreach (var userId in groupDTO.Users)
		{
			var user = await _manager.GetUserById(userId);
			if (user is null)
			{
                _logger.LogWarning("User with id {UserId} not found", userId);
				return BadRequest($"The user with id {userId} does not exist");
			}
			users.Add(user);
		}
		
		var group = new Group(groupDTO.Id, groupDTO.Name, users.ToArray());
		var groupUpdated = await _manager.UpdateGroup(group);
        if (groupUpdated is null)
        {
            _logger.LogWarning("Group with id {GroupId} not found", id);
            return NotFound();
        }
        _logger.LogInformation("Group with id {GroupId} updated", id);
        
		return Ok(groupUpdated.ToGroupDTO());
	}

	/// <summary>
	/// Delete a group with the id
	/// </summary>
	/// <param name="id">Id of the group</param>
	/// <returns>No content</returns>
	[HttpDelete("{id}")]
	public async Task<IActionResult> DeleteGroup(ulong id)
	{
		var group = await _manager.GetGroupById(id);
        if (group is null)
        {
            _logger.LogWarning("Group with id {GroupId} not found", id);
            return NotFound();
        }
		var result = await _manager.DeleteGroup(group);
        _logger.LogInformation("Group with id {GroupId} deleted", id);

        return Ok(result);
    }
}
