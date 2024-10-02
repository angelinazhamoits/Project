using System;
using System.Collections;
using System.Collections.Generic;
using PlayerSpace;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectPoolUser : MonoBehaviour
{
  public float SpawnInterval = 1.0f;
  private float _timer;


  private void Update()
  {
    _timer += Time.deltaTime;
    if (_timer>=SpawnInterval && Input.GetMouseButtonDown(0))
    {
      _timer = 0f;
      SpawnObject();
    }
  }

  private void SpawnObject()
  {
    Bullet bullet = Player.I.GetPooledObject();
    
    if (bullet != null)
    {
      bullet.Shot(Player.I.IsFlip,transform);
    }
  }
}