using System;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private FrogEatingFruit _frog;

    public int Score { get; private set; }

    public event Action<int> Changed;

    private void Awake()
    {
        Score = 0;
    }

    private void OnEnable()
    {
        _frog.OnIncreaseScore += IncreaseScore;
    }

    private void OnDisable()
    {
        _frog.OnIncreaseScore -= IncreaseScore;
    }

    private void IncreaseScore()
    {
        Changed?.Invoke(++Score);
    }
}
