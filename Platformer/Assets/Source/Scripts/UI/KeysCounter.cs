using TMPro;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(TextMeshProUGUI))]
public class KeysCounter : MonoBehaviour
{
    private TextMeshProUGUI _counter;
    private Player _player;
    
    [Inject]
    public void Constructor(Player player)
    {
        _player = player;
    }

    private void Awake()
    {
        _counter = GetComponent<TextMeshProUGUI>();
        ChangeCounter();
    }

    private void OnEnable()
    {
        _player.OnChangeKeyCounter += ChangeCounter;
    }

    private void ChangeCounter()
    {
        _counter.text = $"Собрано ключей: {_player.GetKeysCount()}/{_player.MaxKeys}";
    }
    
    private void OnDisable()
    {
        _player.OnChangeKeyCounter -= ChangeCounter;
    }
}
