using System.Collections.Generic;
using MessagePipe;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GameLifetimeScope : LifetimeScope
{
    [SerializeField] private List<Player.Player> _players;
    [SerializeField] private GameObject _cardTable;
    [SerializeField] private Grid _grid;
    [SerializeField] private TurnManager _turnManager;
    
    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterInstance(_players).AsSelf().AsImplementedInterfaces();
        builder.RegisterInstance(_cardTable);
        builder.RegisterInstance(_grid);
        builder.RegisterInstance(_turnManager).AsSelf().AsImplementedInterfaces();
        
        RegisterMessagePipe(builder);
    }

    private void RegisterMessagePipe(IContainerBuilder builder)
    {
        var options = builder.RegisterMessagePipe();
        builder.RegisterBuildCallback(c => GlobalMessagePipe.SetProvider(c.AsServiceProvider()));
    }
}