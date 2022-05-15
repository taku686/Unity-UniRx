using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UniRx;

public interface IInputEventProvider
{
    IReadOnlyReactiveProperty<Vector3> MoveDirection { get; }
    IObservable<Unit> OnLightAttack { get; }
    IObservable<Unit> OnStrongAttack { get; }
}
