using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class CollisionNotify : MonoBehaviour
{
    public IObservable<Color> colorObservable => colorSubject;


    readonly Subject<Color> colorSubject = new Subject<Color>();

    private void OnCollisionEnter(Collision collision)
    {
        Color otherObjColor = collision.gameObject.GetComponent<MeshRenderer>().material.color;
        colorSubject.OnNext(otherObjColor);
    }
}
