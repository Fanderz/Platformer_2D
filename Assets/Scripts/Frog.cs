using UnityEngine;
using System;

public class Frog : MonoBehaviour
{
    private GroundDetector _groundDetector;
    private InputReader _inputReader;

    public event Action<bool, float> OnAnimatorParameterChange;
    public event Action<float> OnFrogMove;
    public event Action OnFrogJump;

    private void Awake()
    {
        _groundDetector = GetComponent<GroundDetector>();
        _inputReader = GetComponent<InputReader>();
    }

    private void FixedUpdate()
    {
        if (_inputReader.Direction != 0)
            OnFrogMove?.Invoke(_inputReader.Direction);

        if (_inputReader.GetIsJump() && _groundDetector.IsGround)
            OnFrogJump?.Invoke();
    }

    private void Update()
    {
        OnAnimatorParameterChange?.Invoke(!_groundDetector.IsGround, Mathf.Abs(_inputReader.Direction));
    }
}
