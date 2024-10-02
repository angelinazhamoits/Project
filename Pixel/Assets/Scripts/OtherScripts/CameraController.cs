using System;
using System.Collections;
using System.Collections.Generic;
using PlayerSpace;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _player;
    private float _speed = 3f;
    private float _offset = 1f;

    private void Start()
    {
        transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y + _offset,
            transform.position.z);
    }
    
    void Update()
    {
        Vector3 position = _player.position;
        position.z = transform.position.z;
        position.y += _offset;
        transform.position = Vector3.Lerp(transform.position, position, _speed * Time.deltaTime);
    }
}
