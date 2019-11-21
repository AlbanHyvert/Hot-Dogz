using Prof.Tools;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private int _score = 0;
    [SerializeField] GameObject _pauseMenu = null;
    private bool _isPaused = false;

    #region Events
    private event Action<int> _scoreChange = null;
    public event Action<int> ScoreChange
    {
        add
        {
            _scoreChange -= value;
            _scoreChange += value;
        }
        remove
        {
            _scoreChange -= value;
        }
    }

    public event Action<float> _heatChange = null;
    public event Action<float> HeatChange
    {
        add
        {
            _heatChange -= value;
            _heatChange += value;
        }
        remove
        {
            _heatChange -= value;
        }
    }
    #endregion Events

    #region Properties
    public int Score
    {
        get
        {
            return _score;
        }
        set
        {
            _score = value;
            if(_scoreChange != null)
                _scoreChange(_score);
        }
    }
    public bool IsPaused { get { return _isPaused; } set { _isPaused = value; } }

    #endregion Properties

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
            _isPaused = !_isPaused;

            if(_pauseMenu != null && _isPaused == true)
            {
                _pauseMenu.SetActive(true);
            }
        }

        if(_isPaused == false)
        {
            _pauseMenu.SetActive(false);
        }
    }
}
