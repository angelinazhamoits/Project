using System;
using System.Collections;
using System.Collections.Generic;
using PlayerSpace;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    private bool _isRight;
    public bool isMove;
    private GameController _gameController;

    public void Config()
    {
        gameObject.SetActive(false);
    }

    public void Shot(bool isRight, Transform trans)
    {
        _isRight = isRight;
        isMove = true;
        transform.position = trans.position;
        gameObject.SetActive(true);
    }

    public void Reset()
    {
        gameObject.SetActive(false);
        isMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMove)
        {
            return;
        }
        if (!_isRight)
        {
            Debug.Log($"isRight");
            transform.Translate(Vector2.left *_speed*Time.deltaTime);
        }
        else
        {
            Debug.Log($"isLeft");
            transform.Translate(Vector2.right *_speed*Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
            Reset();
            GameController.Y.Kill();
        }
        
        if (other.gameObject.tag == "Level")
        {
            Reset();
        }
    }
   
}
