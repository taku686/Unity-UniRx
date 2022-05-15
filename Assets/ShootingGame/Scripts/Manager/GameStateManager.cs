using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UniRx;
using UniRx.Triggers;

public class GameStateManager : MonoBehaviour
{
    [SerializeField] private PlayerManager _playerManager;
    [SerializeField] private EnemyManager _enemyManager;
    [SerializeField] private ScoreManager _scoreManager;

    private readonly ReactiveProperty<GameState> _state = new ReactiveProperty<GameState>(GameState.Playing);
    public IReadOnlyReactiveProperty<GameState> State => _state;
     // Start is called before the first frame update
    void Start()
    {
        _state.AddTo(this);
        ResetGame();
        _playerManager
            .OnPlayerDeadAsObservable
            .Subscribe(_ => _state.Value = GameState.Result)
            .AddTo(this);

        this.UpdateAsObservable()
            .Where(_ => Input.GetKey(KeyCode.R))
            .ThrottleFirst(TimeSpan.FromSeconds(0.1f))
            .Subscribe(_ => ResetGame())
            .AddTo(this);

    }

    private void ResetGame()
    {
        _playerManager.RespawnPlayer();
        _enemyManager.ResetEnemies();
        _scoreManager.ResetScore();
        _state.Value = GameState.Playing;
    }
}
