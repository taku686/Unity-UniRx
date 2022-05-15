using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System;

public class InputEventProviderImpl : MonoBehaviour,IInputEventProvider
{
    private static readonly float LongPressSeconds = 0.25f;
    public IReadOnlyReactiveProperty<Vector3> MoveDirection => _move;

    public IObservable<Unit> OnLightAttack => _lightAttackSubject;

    public IObservable<Unit> OnStrongAttack => _strongAttackSubject;

    private readonly Subject<Unit> _lightAttackSubject = new Subject<Unit>();
    private readonly Subject<Unit> _strongAttackSubject = new Subject<Unit>();
    private readonly ReactiveProperty<Vector3> _move = new ReactiveProperty<Vector3>();


    // Start is called before the first frame update
    void Start()
    {
        _lightAttackSubject.AddTo(this);
        _strongAttackSubject.AddTo(this);
        _move.AddTo(this);

        this.UpdateAsObservable()
            .Select(_ => Input.GetKey(KeyCode.S))
            .DistinctUntilChanged()
            .TimeInterval()
            .Skip(1)
            .Subscribe(t =>
            {
                if (t.Value) return;
                if(t.Interval.TotalSeconds >= LongPressSeconds)
                {
                    _strongAttackSubject.OnNext(Unit.Default);
                }
                else
                {
                    _lightAttackSubject.OnNext(Unit.Default);
                }
            }).AddTo(this);
    }

    // Update is called once per frame
    void Update()
    {
        _move.SetValueAndForceNotify(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));
    }
}
