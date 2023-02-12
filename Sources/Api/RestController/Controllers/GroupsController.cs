using Microsoft.AspNetCore.Mvc;
using Model;
using Model.Players;
using RestController.DTOs;
using RestController.DTOs.Extensions;
using RestController.Filter;

namespace RestController.Controllers;

[ApiVersion("1.0")]
[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class GroupsController : ControllerBase
{
	private readonly Manager _manager;

	public GroupsController(Manager manager)
	{
		_manager = manager;
	}

	/// <summary>
	/// Get all groups
	/// </summary>
	/// <param name="paginationFilter">Page searched</param>
	/// <returns></returns>
	[HttpGet]
	public async Task<ActionResult> GetGroups([FromQuery] PaginationFilter paginationFilter)
	{
		var groups = await _manager.GetGroups(paginationFilter.Page, paginationFilter.Count);
		return Ok(groups.Select(x => x.ToGroupDTO()).ToList());
	}

	/// <summary>
	/// Get one group by the id
	/// </summary>
	/// <param name="id">Id of the group</param>
	/// <returns></returns>
	[HttpGet("{id}")]
    [ActionName(nameof(GetGroup))]
    public async Task<ActionResult> GetGroup(ulong id)
	{
		var group = await _manager.GetGroupById(id);
		if (group == null) return NotFound();
		return Ok(group.ToGroupDTO());
	}

	/// <summary>
	/// Get the users from the group
	/// </summary>
	/// <param name="id">Id of the group</param>
	/// <returns></returns>
	[Route("{id}/users")]
	[HttpGet]
	public async Task<ActionResult> GetPlayersByGroupId(ulong id)
	{
		var group  = await _manager.GetGroupById(id);
		if (group == null) return NotFound();
		var users = group.Players.Select(x => _manager.GetUserById(x.Id).Result).ToList();
		return Ok(users.Select(x => x?.UserToDTO()).ToList());
	}

	/// <summary>
	/// Get one user in the group wanted
	/// </summary>
	/// <param name="groupId">Id of the group</param>
	/// <param name="userId">Id of the user</param>
	/// <returns></returns>
	[Route("{groupId}/users/{userId}")]
	[HttpGet]
	public async Task<ActionResult> GetPlayerByGroupId(ulong groupId, ulong userId)
	{
        var group = await _manager.GetGroupById(groupId);
        if (group == null) return NotFound();
        if (!group.Players.Contains(_manager.GetPlayerById(userId).Result)) return NotFound();
        var user = await _manager.GetUserById(userId);
        if (user == null) return NotFound();
        var userDTO = user.UserToUserDetailDTO();
        userDTO.Games = (await _manager.GetGamesByPlayer(userId, 1, 10)).Select(x => x.Id).ToList();
        userDTO.Groups = (await _manager.GetGroupsByPlayer(userId, 1, 10)).Select(x => x.Id).ToList();
		return Ok(userDTO);
    }

	[HttpPost]
	public async Task<ActionResult> PostGroup(GroupDTOPostRequest request)
	{
		var users = new List<Player>();
		foreach (var userId in request.Users)
		{
			var user = await _manager.GetUserById(userId);
			if (user is null)
			{
				return BadRequest($"The user with id {userId} does not exist");
			}
			users.Add(user);
		}

		var group = (await _manager.InsertGroup(request.Name, users.ToArray()))!;

		return CreatedAtAction(
			nameof(GetGroup),
			new { id = group.Id },
			group.ToGroupDTO());

	}

	/// <summary>
	/// Update a group with a given id
	/// </summary>
	/// <param name="id">Id of the group</param>
	/// <param name="groupDTO">The new group</param>
	/// <returns>No content</returns>
	[HttpPut("{id}")]
	public async Task<IActionResult> PutGroup(ulong id, GroupDTO groupDTO)
	{
		if (id != groupDTO.Id) return BadRequest();
		
		var users = new List<Player>();
		foreach (var userId in groupDTO.Users)
		{
			var user = await _manager.GetUserById(userId);
			if (user is null)
			{
				return BadRequest($"The user with id {userId} does not exist");
			}
			users.Add(user);
		}
		
		var group = new Group(groupDTO.Id, groupDTO.Name, users.ToArray());
		var groupUpdated = await _manager.UpdateGroup(group);
		if (groupUpdated is null) return NotFound();
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
		if (group is null) return NotFound();
		//Internal Error
		if(!await _manager.DeleteGroup(group)) return StatusCode(500);

		return Ok(group.ToGroupDTO());
	}
}
