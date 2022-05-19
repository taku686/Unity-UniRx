using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Random = UnityEngine.Random;

public class EnemyMove : MonoBehaviour
{
    private Rigidbody _rigid;
    [SerializeField] private float _moveSpeed;
   

    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _rigid.velocity = Vector3.back * _moveSpeed;
    }
}
