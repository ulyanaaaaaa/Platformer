using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _time;
    private bool _isRightDirection;
    private Rigidbody2D _rigidbody;
    private Coroutine _directionTick;

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
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            transform.parent = player.transform;
        }
    }
    
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            transform.parent = null;
        }
    }
}
