using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class ScoreManager : MonoBehaviour
{
    private readonly ReactiveProperty<int> _score = new ReactiveProperty<int>(0);
    public IReadOnlyReactiveProperty<int> Score => _score;

    // Start is called before the first frame update
    void Start()
    {
        _score.AddTo(this);
    }

    public void AddScore(int score)
    {
        _score.Value += score;
    }

    public void ResetScore()
    {
        _score.Value = 0;
    }
}
