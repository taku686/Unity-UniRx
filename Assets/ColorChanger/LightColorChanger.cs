using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class LightColorChanger : MonoBehaviour
{
    [SerializeField]
    CollisionNotify collisionNotify;

    [SerializeField]
    Light directionalLight;

    private void Start()
    {
        collisionNotify.colorObservable
            .Subscribe(collisionobjectColor =>
            {
                directionalLight.color = collisionobjectColor;
                Debug.Log("色が変わったよ！！");
            })
            .AddTo(this);
    }
}
