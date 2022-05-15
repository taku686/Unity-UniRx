using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UniRx;

public class ResultPresenter : MonoBehaviour
{
    [SerializeField] private Canvas _scoreCanvas;
    [SerializeField] private Canvas _resultCanvas;
    [SerializeField] private TMP_Text _text;

    [SerializeField] private GameStateManager _gameStateManager;
    [SerializeField] private ScoreManager _scoreManager;

    private void Start()
    {
        _gameStateManager
            .State
            .Subscribe(x =>
            {
                switch (x)
                {
                    case GameState.Playing:
                        Hide();
                        break;
                    case GameState.Result:
                        Show(_scoreManager.Score.Value);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(x), x, null);

                }
            }).AddTo(this);
    }

    private void Hide()
    {
        _scoreManager.enabled = true;
        _resultCanvas.enabled = false;
    }

    private void Show(int score)
    {
        _scoreManager.enabled = false;
        _resultCanvas.enabled = true;
        _text.text = $"Your score is {score}";
    }
}
