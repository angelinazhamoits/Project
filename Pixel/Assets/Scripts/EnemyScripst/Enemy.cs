
using PlayerSpace;
using Unity.VisualScripting;
using UnityEngine;


public class MovingEnemy : MonoBehaviour
{
    
    [SerializeField] private Vector2 _groundCheckSize;
    [SerializeField] private Checker _checker;
    public float _speed = 2f;
    public Transform _groundCheck;
    public Rigidbody2D _rb;
    public LayerMask _groundLayers;
    private bool _isFacingLeft;
    private bool _groundChecker;

    private void Start()
    {
        _checker.OnCheck += IsDead;
    }

    private void Update()
    {
        _groundChecker = Physics2D.OverlapBox(_groundCheck.position, _groundCheckSize, _groundLayers);

        if (!_groundChecker)
        {
            Flip();
        }
        MovementChecker();
    }

    private void IsDead()
    {
        _checker.OnCheck -= IsDead;
        Destroy(gameObject);
        GameController.Y.Kill();
    }

    private void Flip()
    {
        if (_isFacingLeft || !_isFacingLeft)
        {
            _isFacingLeft = !_isFacingLeft;
            transform.Rotate(0, 180, 0);
        }
    }

    private void MovementChecker()
    {
        if (_isFacingLeft)
        {
            _rb.velocity = new Vector2(-_speed, _rb.velocity.y);
        }
        else
        {
            _rb.velocity = new Vector2(_speed, _rb.velocity.y);
        }
    }
}

