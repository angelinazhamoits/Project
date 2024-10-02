using System;
using System.Collections;
using System.Collections.Generic;
using PlayerSpace;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StaticEnemy : MonoBehaviour
{
   
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent <Player> ()!= null)
        {
            Menu.Z.GameOver(GameController.Y.Score,GameController.Y.Points);
        }
    }
}
