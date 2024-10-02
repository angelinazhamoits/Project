using System;
using System.Collections.Generic;
using UnityEngine;
using AnimationControl;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace PlayerSpace
{
    public class Player : MonoBehaviour
    {
        public static Player I;
        
        [Header("Movement")] [SerializeField] private float _speed = 1f;
        [SerializeField] private float _jumpForce = 10f;
        private bool _isMoving;
        private bool _isFlip = true; 
        private Rigidbody2D _rb;
        private MovementController _movementController;
        private Animator _animator; 
        
        [Header("CollisionInfo")] 
        [SerializeField] private Transform _checkTransform;
        [SerializeField] private float _groundCheckRadius;
        [SerializeField] private LayerMask _groundLayerMask; 
        internal bool _isGrounded;
        internal bool _isDoubleGround;
        
        [Header("Gun")] 
        private bool _isHaveGun;
        [SerializeField] private GameObject _objectToPool;
        [SerializeField] private int _initialPoolSize = 15;
        [SerializeField] private List<Bullet> _poolObject;
        [SerializeField] private GameObject _gun;
        
        private void Awake() => I = this;
        
        public bool IsFlip
        {
            get { return _isFlip; }
        }

        void Start()
        {
            _movementController = GetComponent<MovementController>();
            _rb = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            _poolObject = new List<Bullet>();
        }

        public void OnCollisionEnter2D(Collision2D enemy)
        {
            if (enemy.gameObject.tag == "Enemy")
            {
                GameController.Y.Health();
            }
        }
        
        public Bullet GetPooledObject()
        {
            if (!_isHaveGun)
            {
                return null;
            }
            
            foreach (var obj in _poolObject)
            {
                if (!obj.isMove)
                {
                    return obj;
                }
            }

            var bullet = CreateBullet();
            _poolObject.Add(bullet);
            return bullet;
        }

        private Bullet CreateBullet()
        {
            GameObject obj = Instantiate(_objectToPool);
            Bullet bullet = obj.GetComponent<Bullet>();
            bullet.Config();
            return bullet;
        }
        
        void Update()
        {
            _isMoving = _rb.velocity.x != 0;
            _animator.SetBool("isMove", _isMoving);
            _animator.SetBool("isGrounded", _isGrounded);
            _animator.SetFloat("velocityY", _rb.velocity.y);
            CollisionCheck();
            Flip();
        }
        
        private void FixedUpdate()
        {
            _rb.velocity = new Vector2(_movementController._moveInput * _speed, _rb.velocity.y);
        }
        
        private void CollisionCheck()
        {
            _isGrounded = Physics2D.OverlapCircle(_checkTransform.position, _groundCheckRadius, _groundLayerMask);
            if (_isGrounded)
            {
                _isDoubleGround = true;
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(_checkTransform.position, _groundCheckRadius);
        }

        internal void Jump()
        {
            if (_isGrounded)
            {
                _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
            }
            else
            {
                if (_isDoubleGround)
                {
                    _isDoubleGround = false;
                    _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "GunBox")
            {
                Destroy(collision.gameObject);
                _isHaveGun = true;
                _gun.SetActive(_isHaveGun);
            }
        }

        private void Flip()
        {
            if ((_movementController._moveInput > 0 && !_isFlip) || (_movementController._moveInput < 0 && _isFlip))
            {
                _isFlip = !_isFlip;
                transform.Rotate(0, 180, 0);
            }
        }
        
    }
}