using UnityEngine;
using Zenject;

public class Door : MonoBehaviour
{
    private Player _player;
    private SceneService _sceneService;
    
    [Inject]
    public void Constructor(Player player, SceneService sceneService)
    {
        _player = player;
        _sceneService = sceneService;
    }
    
    public void RestertLevel()
    {
        if (_player.MaxKeys == _player.GetKeysCount())
        {
            _sceneService.Restart();
        }
    }
}
