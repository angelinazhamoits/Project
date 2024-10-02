using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace PlayerSpace
{
    public class GameController : MonoBehaviour
    {
        public event Action OnOpenExit; 
        public static GameController Y;
        [SerializeField] private MovingEnemy _enemy;
            
        [Header("Fruits")] private int _points;
        [SerializeField] private int _kiwiPrice;
        [SerializeField] private int _applePrice;
        [SerializeField] private TextMeshProUGUI _summ;
        [SerializeField] private int _numberOfFruits;

        [Header("Enemies")] public int _score;
        [SerializeField] private TextMeshProUGUI _scoreDisplay;
        [SerializeField] private int _numberOfEnemies;

        [Header("Health")] private int _health = 3;
        public Image[] hearts;
        public GameObject _heartsAnimationOne;
        public GameObject _heartsAnimationTwo;
        public GameObject _heartsAnimationThree;
        public Sprite fullHeart;
        public Sprite emptyHeart;

        public void Start()
        {
            _heartsAnimationOne.transform.DORotate(new Vector3(0, 180, 0),3f).SetLoops(-1, LoopType.Yoyo);
            _heartsAnimationTwo.transform.DORotate(new Vector3(0, 180, 0),3f).SetLoops(-1, LoopType.Yoyo);
            _heartsAnimationThree.transform.DORotate(new Vector3(0, 180, 0),3f).SetLoops(-1, LoopType.Yoyo);
        }

        public int Points
        {
            get { return _points; }
        }
        
        public int Score
        {
            get { return _score; }
        }

        private void Awake() => Y = this;

        public void Kill()
        {
            CountObject(ref _numberOfEnemies);

            _score++;
            _scoreDisplay.text = $"{_score}";
        }

        public void PointCounter(FruitType fruitType)
        {
            switch (fruitType)
            {
                case FruitType.Kiwi:
                    _points += _kiwiPrice;
                    break;
                case FruitType.Apple:
                    _points += _applePrice;
                    break;
            }
            CountObject(ref _numberOfFruits);
            Summ();
        }

        private void Summ()
        {
            
            _summ.text = $"{_points}";
        }

        internal void Health()
        {
            _health--;
            if (_health <= 0)
            {
                Menu.Z.GameOver(_score, _points);
            }

            for (int i = 0; i < hearts.Length; i++)
            {
                if (i < _health)
                {
                    hearts[i].sprite = fullHeart;
                }
                else
                {
                    hearts[i].sprite = emptyHeart;
                }
            }
        }

        private void CountObject(ref int value)
        {
            value--;
            if (value == 0)
            {
                CheckExit();
            }
        }

        private void CheckExit()
        {
            if (_numberOfFruits <= 0 && _numberOfEnemies <= 0)
            {
                OnOpenExit?.Invoke();
            }
        }
    }
}
