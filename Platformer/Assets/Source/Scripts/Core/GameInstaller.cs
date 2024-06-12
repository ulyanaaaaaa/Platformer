using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private Player _player;
    [SerializeField] private FadePanel _fadePanel;
    [SerializeField] private SceneService _sceneService;

    public override void InstallBindings()
    {
        Container.Bind<Player>()
            .FromInstance(_player)
            .AsSingle();
        
        Container.Bind<PlayerHealth>()
            .FromInstance(_player.GetComponent<PlayerHealth>())
            .AsSingle();
        
        Container.Bind<FadePanel>()
            .FromInstance(_fadePanel)
            .AsSingle();
        
        Container.Bind<SceneService>()
            .FromInstance(_sceneService)
            .AsSingle();
    }
}
