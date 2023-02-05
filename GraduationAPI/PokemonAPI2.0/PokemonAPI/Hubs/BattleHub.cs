using System.Security.Claims;
using Microsoft.AspNetCore.SignalR;
using PokemonAPI.Dto;
using PokemonAPI.Models;
using PokemonWEB.Interfaces;

namespace PokemonAPI.Hubs;

public class BattleHub : Hub
{
    private readonly IBattleRepository _battleRepository;

    public BattleHub(IBattleRepository battleRepository)
    {
        _battleRepository = battleRepository;
    }
    
    public async Task ConnectPlayers(string userName, string groupName)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, groupName);

        await Clients.Group(groupName).SendAsync("PlayerConnected", userName);
    }

    public async Task BattleMove(Guid battleId, int abilityId)
    {
        var responceDto = await _battleRepository.MovePokemon
        (
            new BattleMoveDto()
            {
                BattleId = battleId, 
                AbilityId = abilityId
            }
        );
        await Clients.Group(battleId.ToString()).SendAsync("UpdateBattle", responceDto);
    }
}