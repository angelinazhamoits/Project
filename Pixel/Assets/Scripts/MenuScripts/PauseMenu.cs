using System;
using System.Collections;
using System.Collections.Generic;
using PlayerSpace;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Button = UnityEngine.UIElements.Button;
using DG.Tweening;

public class Menu : MonoBehaviour
{ 
    [Header("Menu")]
    public static Menu Z;
  [SerializeField]  private GameObject _pauseGameMenu;
  [SerializeField] private GameObject _gameOverMenu;
  [SerializeField] private GameObject _woneMenu;
  [SerializeField] private GameObject _game;

  [Header("Results")]
  [SerializeField] private TextMeshProUGUI _wonEnemies;
  [SerializeField] private TextMeshProUGUI _wonFruits;
  [SerializeField] private TextMeshProUGUI _gameOverEnemies;
  [SerializeField] private TextMeshProUGUI _gameOverFruits;

  private void Awake() => Z = this;
  
  void Update()

    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_pauseGameMenu.activeSelf)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        } 
    }

    public void Resume()
    {
        _pauseGameMenu.SetActive(false);
        Time.timeScale = 1f;
        _game.SetActive(false);
    }

    public void Pause()
    {
        _pauseGameMenu.SetActive(true);
        Time.timeScale = 0f;
        _game.SetActive(false);
    }
    public void Retry ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void ToMenu()
    {
     Time.timeScale = 1f;
     SceneManager.LoadScene(0);
    }

    internal void GameOver(int numberDeadEnemy, int fruitNumber)
    {
        _gameOverMenu.SetActive(true);
        Time.timeScale = 0f;
        _gameOverEnemies.text = numberDeadEnemy.ToString();
        _gameOverFruits.text = fruitNumber.ToString();
        _game.SetActive(false);
    }

    internal void WonMenu(int numberDeadEnemy, int fruitNumber)
    {
        
        _woneMenu.SetActive(true);
        Time.timeScale = 0f;
        _wonEnemies.text = numberDeadEnemy.ToString();
        _wonFruits.text = fruitNumber.ToString();
        _game.SetActive(false);
    }
} 
