using System;
using UnityEngine;

public class FrogEatingFruit : MonoBehaviour
{
    public event Action OnIncreaseScore;
    //public event Action<Fruit> EatedFruit;

    private void EatFruit() =>
        OnIncreaseScore?.Invoke();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Fruit fruit))
        {
            EatFruit();
            Destroy(fruit.gameObject);
        }
    }
}
