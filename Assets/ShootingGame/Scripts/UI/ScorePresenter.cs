using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UniRx;

public class ScorePresenter : MonoBehaviour
{
    [SerializeField] private ScoreManager _scoreManager;
    [SerializeField] private TMP_Text _text;

    private void Start()
    {
        _scoreManager
            .Score
            .Subscribe(x => _text.text = $"Score: {x}")
            .AddTo(this);
    }
}
