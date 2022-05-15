using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 3;
    private Rigidbody _rigidbody;
    private IInputEventProvider _inputEventProvider;
    private PlayerCore _playerCore;
    private bool _isMoveBlock;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _playerCore = GetComponent<PlayerCore>();
        _inputEventProvider = GetComponent<IInputEventProvider>();
    }

    private void FixedUpdate()
    {
        var vel = Vector3.zero;

        if (!_playerCore.IsDead.Value)
        {
            var moveVector = GetMoveVector();

            if(moveVector != Vector3.zero && !_isMoveBlock)
            {
                vel = moveVector * _moveSpeed;
            }
        }

        _rigidbody.velocity = vel;
    }

    private Vector3 GetMoveVector()
    {
        var x = _inputEventProvider.MoveDirection.Value.x;
        var z = _inputEventProvider.MoveDirection.Value.z;
        return new Vector3(x, 0, z);
    }

    public void BlockMove(bool isBlock)
    {
        _isMoveBlock = isBlock;
    }
}
