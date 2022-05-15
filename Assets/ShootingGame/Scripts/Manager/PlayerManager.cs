using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UniRx;


public class PlayerManager : MonoBehaviour
{
    [SerializeField] private PlayerCore _playerPrefab;
    [SerializeField] private Transform _spawnPoint;
    private PlayerCore _currentPlayer;

    private readonly Subject<Unit> _onPlayerDeadSubject = new Subject<Unit>();
    public IObservable<Unit> OnPlayerDeadAsObservable => _onPlayerDeadSubject;

    // Start is called before the first frame update
    void Start()
    {
        _onPlayerDeadSubject.AddTo(this);
    }

    public void RespawnPlayer()
    {
        if (_currentPlayer != null) Destroy(_currentPlayer.gameObject);
        _currentPlayer = Instantiate(_playerPrefab, _spawnPoint.position, _spawnPoint.rotation);

        _currentPlayer
            .IsDead
            .Where(x => x)
            .Take(1)
            .Subscribe(_ => { _onPlayerDeadSubject.OnNext(Unit.Default); })
            .AddTo(this);
    }
}
