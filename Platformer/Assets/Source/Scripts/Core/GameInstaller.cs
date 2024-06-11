using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private Player _player;

    public override void InstallBindings()
    {
        Container.Bind<Player>()
            .FromInstance(_player)
            .AsSingle();
        
        Container.Bind<PlayerHealth>()
            .FromInstance(_player.GetComponent<PlayerHealth>())
            .AsSingle();
    }
}
