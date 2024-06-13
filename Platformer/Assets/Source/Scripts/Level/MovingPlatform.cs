using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Vector2 _startPosition;
    [SerializeField] private Vector2 _endPosition;
    [SerializeField] private float _speed;
    private Rigidbody2D _rigidbody;
    private Vector2 targetPoint;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    
    private void Start()
    {
        transform.position = _startPosition;
        targetPoint = _endPosition;
    }

    private void Update()
    {
        Vector3 currentPosition = transform.position;
        Vector3 newPosition = Vector3.MoveTowards(currentPosition, targetPoint, _speed * Time.fixedDeltaTime);

        _rigidbody.MovePosition(newPosition);

        if (Vector3.Distance(currentPosition, targetPoint) < 0.1f)
        {
            targetPoint = targetPoint == _startPosition ? _endPosition : _startPosition;
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
