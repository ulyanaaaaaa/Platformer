using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(Image))]
public class HealthBar : MonoBehaviour
{
    private PlayerHealth _playerHealth;
    private Image _image;
    
    [Inject]
    public void Constructor(PlayerHealth playerHealth)
    {
        _playerHealth = playerHealth;
    }

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    private void OnEnable()
    {
        _playerHealth.ChangeHealthBar += ChangeBar;
    }

    private void ChangeBar()
    {
        _image.fillAmount = (float)_playerHealth.Health / _playerHealth.MaxHealth;
    }
    
    private void OnDisable()
    {
        _playerHealth.ChangeHealthBar -= ChangeBar;
    }
}
