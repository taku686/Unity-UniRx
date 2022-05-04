using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace practice1
{
    public class PrintLogObserver<T> : IObserver<T>
    {
        public void OnCompleted()
        {
            Debug.Log("OnCompleted!!");
        }

        public void OnError(Exception error)
        {
            Debug.Log("error");
        }

        public void OnNext(T value)
        {
            Debug.Log(value);
        }
    }
}