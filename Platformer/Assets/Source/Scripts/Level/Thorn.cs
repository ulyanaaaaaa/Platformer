using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Thorn : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;
    [SerializeField] private float _time;
    private Rigidbody2D _rigidbody;
    private Coroutine _directionTick;
    private bool _isRightDirection;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _directionTick = StartCoroutine(DirectionTick());
    }

    private void Update()
    {
        if (_isRightDirection)
            _rigidbody.velocity = Vector2.right * _speed;
        
        else
            _rigidbody.velocity = Vector2.left * _speed;
    }

    private IEnumerator DirectionTick()
    {
        while (true)
        {
            _isRightDirection = false;
            yield return new WaitForSeconds(_time);
            _isRightDirection = true;
            yield return new WaitForSeconds(_time);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent(out PlayerHealth playerHealth))
        {
            playerHealth.TakeDamage(_damage);
        }
    }
}
