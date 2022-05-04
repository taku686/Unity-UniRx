using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class ErrorMessage : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        var subject = new Subject<string>();

        subject
            .Select(str => int.Parse(str))
            .Subscribe(
            x => Debug.Log(x),
            ex => Debug.LogError("例外が発生しました：" + ex.Message),
            () => Debug.Log("OnCompleted!!")
            );
        subject.OnNext("1");
        subject.OnNext("2");
        subject.OnNext("Three");
        subject.OnNext("4");

        subject.Subscribe(
            x => Debug.Log(x),
            () => Debug.Log("OnCompleted")
            );

        subject.OnNext("Hello");
        subject.OnCompleted();
        subject.Dispose();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
