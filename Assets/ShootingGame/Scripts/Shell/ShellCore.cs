using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class ShellCore : MonoBehaviour
{

    [SerializeField] private Collider _collider;
    private int _damageValue = 0;
    public ShellCore(int damagevalue)
    {
        _damageValue = damagevalue;
    }
    private void Start()
    {
        
    }

    private void SubscribeColliderEvent()
    {
        _collider.OnTriggerEnterAsObservable()
            .Subscribe(x =>
            {
                if (!x.TryGetComponent<IDamageApplicable>(out var d)) return;

                d.ApplyDamage(new Damage(_damageValue));
            }).AddTo(this);
    }
}
