using MessagePipe;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GameLifetimeScope : LifetimeScope
{
    
    protected override void Configure(IContainerBuilder builder)
    {
        
        
        RegisterMessagePipe(builder);
    }

    private void RegisterMessagePipe(IContainerBuilder builder)
    {
        var options = builder.RegisterMessagePipe();
        builder.RegisterBuildCallback(c => GlobalMessagePipe.SetProvider(c.AsServiceProvider()));
    }
}