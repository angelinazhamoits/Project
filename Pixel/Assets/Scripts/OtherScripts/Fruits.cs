using System.Collections;
using System.Collections.Generic;
using PlayerSpace;
using UnityEngine;

public class Fruits : MonoBehaviour
{

    [SerializeField] private FruitType _fruitType;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent <Player> ()!= null)
        {
            GameController.Y.PointCounter(_fruitType);
           Destroy(gameObject);
        }
    }
}

public enum FruitType
{
    Apple,
    Kiwi
}