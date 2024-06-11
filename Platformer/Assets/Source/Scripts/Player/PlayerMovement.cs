using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpSpeed;
    private KeyboardInput _keyboardInput;
    private Rigidbody2D _rigidbody;
    private GroundCheker _groundCheker;
    private bool _isGround;
    

    private void Awake()
    {
        _keyboardInput = GetComponent<KeyboardInput>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _groundCheker = GetComponentInChildren<GroundCheker>();
    }

    private void OnEnable()
    {
        _keyboardInput.OnJumpCliked += Jump;
        _keyboardInput.OnLeftCliked += LeftStep;
        _keyboardInput.OnRightCliked += RightStep;
        _groundCheker.OnEnter += SetGround;
        _groundCheker.OnExit += RemoveGround;
    }
    
    private void SetGround()
    {
        _isGround = true;
    }

    private void RemoveGround()
    {
        _isGround = false;
    }

    private void Jump()
    {
        if (!_isGround)
            return;
        
        _rigidbody.velocity = Vector2.up * _jumpSpeed; 
    }

    private void LeftStep()
    {
        _rigidbody.velocity = (Vector2.left + Vector2.down) * _speed; 
    }

    private void RightStep()
    {
        _rigidbody.velocity = (Vector2.right + Vector2.down) * _speed; 
    }
    
    private void OnDisable()
    {
        _keyboardInput.OnJumpCliked -= Jump;
        _keyboardInput.OnLeftCliked -= LeftStep;
        _keyboardInput.OnRightCliked -= RightStep;
        _groundCheker.OnEnter -= SetGround;
        _groundCheker.OnExit -= RemoveGround;
    }
}
