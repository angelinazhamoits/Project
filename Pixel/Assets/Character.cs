using System;
using System.Collections;
using UnityEngine;


public class Character : MonoBehaviour
{
    public GameObject welcomeText;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "GuideCharacter") 
        {
            welcomeText.SetActive(true);
            StartCoroutine(Timer());
        }
        else
        {
            welcomeText.SetActive(false);
        }

        IEnumerator Timer()
        {
            yield return new WaitForSeconds(10);
            welcomeText.SetActive(false);
        }
    }
}

