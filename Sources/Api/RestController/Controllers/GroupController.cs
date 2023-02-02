using System;
using Microsoft.AspNetCore.Mvc;
using Model;
using Model.Players;
using RestController.DTOs;
using RestController.DTOs.Extensions;
using RestController.Filter;

namespace RestController.Controllers;

[Route("group/")]
[ApiController]
public class GroupController : ControllerBase
{
	private readonly Manager _manager;

	public GroupController(Manager manager)
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
	[Route("/group/{id}/user/")]
	[HttpGet]
	public async Task<ActionResult> GetPlayersByGroupId(ulong id)
	{
		var group  = await _manager.GetGroupById(id);
		if (group == null) return NotFound();
		var users = group.Players;
		return Ok(users.Select(x => x.PlayerToDTO()));
	}

	/// <summary>
	/// Get one user in the group wanted
	/// </summary>
	/// <param name="groupId">Id of the group</param>
	/// <param name="userId">Id of the user</param>
	/// <returns></returns>
	[Route("/group/{groupId}/user/{userId}")]
	[HttpGet]
	public async Task<ActionResult> GetPlayerByGroupId(ulong groupId, ulong userId)
	{
        var group = await _manager.GetGroupById(groupId);
        if (group == null) return NotFound();
		var user = group.Players.SingleOrDefault(x => x.Id == userId);
		if (user == null) return NotFound();
		return Ok(user.PlayerToDTO());
    }

	[HttpPost]
	public async Task<ActionResult> PostGroup(GroupDTO groupDTO)
	{
		var users = groupDTO.Users ;
		if (users.Count == 0) return BadRequest();

		var group = await _manager.InsertGroup(groupDTO.Name, (Player) users);

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
		var group = await _manager.UpdateGroup(groupDTO.ToGroup());
		if (group == null) return NotFound();
		return NoContent();
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
		await _manager.DeleteGroup(group);

		return NoContent();
	}
}
