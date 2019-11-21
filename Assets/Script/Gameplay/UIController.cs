using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    #region Fields
    [SerializeField] static private TextMeshProUGUI _scoreText = null;
    [SerializeField] static private TextMeshProUGUI _heatText = null;
    #endregion

    private void Start()
    {
        if (_scoreText != null && _heatText != null)
        {
            GameManager.Instance.ScoreChange += OnScoreChange;
            GameManager.Instance.HeatChange += OnHeatChange;
        }
    }

    public static void OnScoreChange(int score)
    {
        _scoreText.text = "Score : " + score.ToString();
    }

    public static void OnHeatChange(float heat)
    {
        _heatText.text = "Heat : " + heat.ToString();
    }
}
