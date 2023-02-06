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
    
    public async Task BattleMove(BattleResponceDto battleResponceDto, string battleId)
    {
        await Clients.All.SendAsync("UpdateBattle", battleResponceDto);
    }
}