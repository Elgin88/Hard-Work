using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PlayerCurrentSpeedSetter))]
[RequireComponent(typeof(Player))]

public class PlayerController : MonoBehaviour
{
    private PlayerCurrentSpeedSetter _playerSetCurrentSpeed;
    private FixedJoystick _joystick;
    private FixedJoystick _currentJoystick;
    private Coroutine _moveWork = null;
    private Rigidbody _rigidbody;
    private float _currentHorizontal;
    private float _currentVertical;
    private bool _isJoystickTurn = false;

    public bool IsJoystickWork => _isJoystickTurn;
    public Rigidbody Rigidbody => _rigidbody;

    private void Start()
    {
        _playerSetCurrentSpeed = GetComponent<PlayerCurrentSpeedSetter>();
        _rigidbody = GetComponent<Rigidbody>();

        _joystick = FindObjectOfType<FixedJoystick>();

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

                _rigidbody.velocity = new Vector3(_joystick.Horizontal * _playerSetCurrentSpeed.CurrentSpeed * -1,
                    _rigidbody.velocity.y, _joystick.Vertical * _playerSetCurrentSpeed.CurrentSpeed * -1);

                _currentHorizontal = _joystick.Horizontal;
                _currentVertical = _joystick.Vertical;

                transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);
            }
                
            else
            {
                _isJoystickTurn = false;

                _rigidbody.velocity = new Vector3(_currentHorizontal * _playerSetCurrentSpeed.CurrentSpeed * -1,
                    _rigidbody.velocity.y, _currentVertical * _playerSetCurrentSpeed.CurrentSpeed * -1);
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
	