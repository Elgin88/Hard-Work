using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PlayerSpeedSetter))]

public class PlayerMover : MonoBehaviour
{
    private PlayerSpeedSetter _playerSpeedSetter;
    private FloatingJoystick _joystick;
    private Quaternion _currentPlayerDirection;
    private Coroutine _moveWork = null;

    private bool _isJoystickTurn = false;

    public bool IsJoystickTurn => _isJoystickTurn;
    public Quaternion CurrentPlayerDirection => _currentPlayerDirection;

    private void Start()
    {
        _playerSpeedSetter = GetComponent<PlayerSpeedSetter>();
        _joystick = FindObjectOfType<FloatingJoystick>();

        StartCoroutineMove();
    }

    private IEnumerator Move()
    {
        while (true)
        {
            if ((_joystick.Horizontal != 0) || (_joystick.Horizontal != 0))
            {
                _isJoystickTurn = true;

                _currentPlayerDirection = Quaternion.LookRotation(new Vector3(_joystick.Horizontal, 0, _joystick.Vertical));
                transform.rotation = _currentPlayerDirection;

                transform.position = new Vector3(transform.position.x + _joystick.Horizontal * Time.deltaTime *  _playerSpeedSetter.CurrentSpeed, transform.position.y, transform.position.z + _joystick.Vertical * Time.deltaTime * _playerSpeedSetter.CurrentSpeed);
            }
            else
            {
                _isJoystickTurn = false;
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