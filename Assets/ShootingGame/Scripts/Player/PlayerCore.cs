using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;


public class PlayerCore : MonoBehaviour
{
    public IReadOnlyReactiveProperty<bool> IsDead => _isDead;
    private readonly ReactiveProperty<bool> _isDead = new ReactiveProperty<bool>();

    private bool _isInvincible;

    // Start is called before the first frame update
    void Start()
    {
        _isDead.AddTo(this);

        this.OnCollisionEnterAsObservable()
            .Where(_ => !_isInvincible)
            .Where(x => x.gameObject.TryGetComponent<EnemyCore>(out _))
            .Subscribe(onNext: _ => _isDead.Value = true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
