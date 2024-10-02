using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checker : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private int _layerIndexMask;
    public event Action OnCheck;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == _layerIndexMask)
        {
            OnCheck?.Invoke();
        }
    }
}
