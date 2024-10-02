using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripFire : StaticEnemy
{
    private Animator _animator;
    private bool _isWorking;
    [SerializeField] private float _coolDown;
    private float _coolDownTimer;
    private BoxCollider2D _col;
    void Start()
    {
        _col = GetComponent<BoxCollider2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _coolDownTimer -= Time.deltaTime;
        if (_coolDownTimer < 0)
        {
            _isWorking = !_isWorking;
            _coolDownTimer = _coolDown;
        }

        _col.enabled = _isWorking;
        _animator.SetBool("isWorking", _isWorking);
    }

    protected void OnTriggerExit2D(Collider2D collision)
    {
        if (_isWorking)
        {
            base.OnTriggerEnter2D(collision);
        }
    }
}
