using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PlayerSpeedSetter))]
[RequireComponent(typeof(Player))]

public class PlayerMover : MonoBehaviour
{
    private PlayerSpeedSetter _playerSpeedSetter;
    private VariableJoystick _joystick;
    private Rigidbody _rigidbody;
    private Coroutine _moveWork = null;
    private Vector3 _currentDirectionOfVelocity;

    private float _currentJoystickValueHorizontal;
    private float _currentJoystickValueVertical;

    private bool _isJoystickTurn = false;

    public bool IsJoystickTurn => _isJoystickTurn;
    public Vector3 CurrentDirection =>_currentDirectionOfVelocity;

    private void Start()
    {
        _playerSpeedSetter = GetComponent<PlayerSpeedSetter>();
        _rigidbody = GetComponent<Rigidbody>();

        _joystick = FindObjectOfType<VariableJoystick>();

        _currentJoystickValueHorizontal = _joystick.Horizontal;
        _currentJoystickValueVertical = _joystick.Vertical;

        _currentDirectionOfVelocity = Vector3.right;

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


                _currentJoystickValueHorizontal = _joystick.Horizontal;
                _currentJoystickValueVertical = _joystick.Vertical;

                if (_rigidbody.velocity != Vector3.zero)
                {
                    _currentDirectionOfVelocity = _rigidbody.velocity;
                }

                transform.rotation = Quaternion.LookRotation(_currentDirectionOfVelocity);
            }

            else
            {
                _isJoystickTurn = false;

                _rigidbody.velocity = new Vector3(_currentJoystickValueHorizontal * _playerSpeedSetter.CurrentSpeed, 0, _currentJoystickValueVertical * _playerSpeedSetter.CurrentSpeed);
                
                if (_rigidbody.velocity != Vector3.zero)
                {
                    _currentDirectionOfVelocity = _rigidbody.velocity;  
                }

                transform.rotation = Quaternion.LookRotation(_currentDirectionOfVelocity);
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