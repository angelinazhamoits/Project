using System;
using System.Collections;
using System.Collections.Generic;
using PlayerSpace;
using Unity.VisualScripting;
using UnityEngine;

public class Exit : MonoBehaviour
{
    private bool _exitOpen;
    
    private void Start()
    {
        GameController.Y.OnOpenExit += OpenExit;
    }

    private void OpenExit()
    {
        _exitOpen = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!_exitOpen)
        {
            return;
        }

        if (other.gameObject.tag == "Player")
        {
            Menu.Z.WonMenu(GameController.Y.Score,GameController.Y.Points);
        }
    }
}
