using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;
namespace practice3
{
    public class MessageSample : MonoBehaviour
    {
        [SerializeField]
        private float _countTimeSeconds = 30f;

        private readonly AsyncSubject<Unit> _onTimeUpAsyncSubject = new AsyncSubject<Unit>();

        public IObservable<Unit> OnTimeUpAsyncSubject => _onTimeUpAsyncSubject;

        private IDisposable _disposable;

        // Start is called before the first frame update
        void Start()
        {
            _disposable = Observable
                .Timer(TimeSpan.FromSeconds(_countTimeSeconds))
                .Subscribe(_ =>
                {
                    _onTimeUpAsyncSubject.OnNext(Unit.Default);
                    _onTimeUpAsyncSubject.OnCompleted();
                });
        }

        private void OnDestroy()
        {
            _disposable?.Dispose();
            _onTimeUpAsyncSubject.Dispose();
        }
    }
}