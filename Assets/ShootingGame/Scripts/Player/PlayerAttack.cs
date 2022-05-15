using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;


public class PlayerAttack : MonoBehaviour
{
    [SerializeField] ShellCore _shellPrefab;
    [SerializeField] Transform _shotPos;
    private int _attackPower = 1;
    private IInputEventProvider _inputEventProvider;
    private PlayerMove _playerMove;
    [SerializeField] Vector3 _shotForce = new Vector3(0, 0, 5f);
    private readonly ReactiveProperty<bool> _isInAttack = new ReactiveProperty<bool>(false);

    // Start is called before the first frame update
    void Start()
    {
        _isInAttack.AddTo(this);
        _inputEventProvider = GetComponent<IInputEventProvider>();
        _playerMove = GetComponent<PlayerMove>();

        _inputEventProvider.OnLightAttack
            .Subscribe(_ => Shot()).AddTo(this);
    }

    private void Shot()
    {
        GameObject shell = Instantiate(_shellPrefab.gameObject);
        ShellCore shellCore = new ShellCore(_attackPower);
        shell.transform.position = _shotPos.position;
        shell.GetComponent<Rigidbody>().AddForce(_shotForce, ForceMode.Impulse);

    }
}
