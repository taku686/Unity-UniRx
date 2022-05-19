using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class ShellCore : MonoBehaviour
{

    [SerializeField] private Collider _collider;
    private int _damageValue = 0;
    
    private void Start()
    {
        _collider.GetComponent<Collider>();
        SubscribeColliderEvent();
    }

    public void Initialize(int damageValue)
    {
        _damageValue = damageValue;
    }

    private void SubscribeColliderEvent()
    {
        _collider.OnTriggerEnterAsObservable()
            .Subscribe(x =>
            {
                if (!x.TryGetComponent<IDamageApplicable>(out var d)) return;

                d.ApplyDamage(new Damage(_damageValue));
                Destroy(this.gameObject);
            }).AddTo(this);
    }
}
