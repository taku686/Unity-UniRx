using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class UseOnCollisionEnterAsOnservable : MonoBehaviour
{
    [SerializeField]
    Light directionalLight;

    private void Start()
    {
        this.OnCollisionEnterAsObservable()
            .Subscribe(collisionObject =>
            {
                Debug.Log("色が変わったよ");
                ColorChange(collisionObject);
            })
            .AddTo(this);
    }

    void ColorChange(Collision collision)
    {
        directionalLight.color = collision.gameObject.GetComponent<MeshRenderer>().material.color;
    }
}
