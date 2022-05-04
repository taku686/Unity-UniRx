using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;
namespace practice1
{
    public class CountDownEventProvider : MonoBehaviour
    {
        [SerializeField]
        private int _countSeconds = 10;

        private Subject<int> _subjects;

        public IObservable<int> CountDownObservable => _subjects;

        private void Awake()
        {
            _subjects = new Subject<int>();
            StartCoroutine(CountCorutine());
           
        }

        IEnumerator CountCorutine()
        {
            var current = _countSeconds;

            while (current > 0)
            {
                _subjects.OnNext(current);
                current--;
                yield return new WaitForSeconds(1.0f);
            }

            _subjects.OnNext(0);
            _subjects.OnCompleted();
        }

        private void OnDestroy()
        {
            _subjects.Dispose();
        }
    }
}