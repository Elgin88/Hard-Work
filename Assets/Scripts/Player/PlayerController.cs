using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PlayerSpeedSetter))]
[RequireComponent(typeof(Player))]

public class PlayerController : MonoBehaviour
{
    private PlayerSpeedSetter _playerSpeedSetter;
    private VariableJoystick _joystick;
    private Coroutine _moveWork = null;
    private Rigidbody _rigidbody;
    private Player _player;

    private float _currentHorizontal;
    private float _currentVertical;

    private bool _isJoystickTurn = false;

    public bool IsJoystickWork => _isJoystickTurn;

    private void Start()
    {
        _playerSpeedSetter = GetComponent<PlayerSpeedSetter>();
        _rigidbody = GetComponent<Rigidbody>();
        _player = GetComponent<Player>();

        _joystick = FindObjectOfType<VariableJoystick>();

        _currentHorizontal = _joystick.Horizontal;
        _currentVertical = _joystick.Vertical;

        StartCoroutineMove();
    }

    private IEnumerator Move()
    {
        while (true)
        {
            if (_joystick.Horizontal != 0 || _joystick.Horizontal != 0)
            {
                _isJoystickTurn = true;

                _rigidbody.velocity = new Vector3(_joystick.Horizontal * _playerSpeedSetter.CurrentSpeed, 0, _joystick.Vertical * _playerSpeedSetter.CurrentSpeed);

                _currentHorizontal = _joystick.Horizontal;
                _currentVertical = _joystick.Vertical;

                transform.rotation = Quaternion.LookRotation(_player.CurrentDuraction);
            }
                
            else
            {
                _isJoystickTurn = false;

                _rigidbody.velocity = new Vector3(_currentHorizontal * _playerSpeedSetter.CurrentSpeed, _rigidbody.velocity.y, _currentVertical * _playerSpeedSetter.CurrentSpeed);

                transform.rotation = Quaternion.LookRotation(_player.CurrentDuraction);
            }

            yield return null;
        }
    }

    public void StartCoroutineMove()
    {
        if (_moveWork == null)
        {
            _moveWork = StartCoroutine(Move());
        }
    }

    public void StopCoroutineMove()
    {
        if (_moveWork != null)
        {
            StopCoroutine(_moveWork);
            _moveWork = null;
        }
    }
}
	