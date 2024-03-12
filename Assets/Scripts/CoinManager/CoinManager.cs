using System;
using UnityEngine;
using UnityEngine.Events;

public class CoinManager : MonoBehaviour
{
    public UnityEvent onCoinEaten;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Pref.Coins += 1;
            Destroy(gameObject);
            onCoinEaten.Invoke();
        }

    }
    public void HandleCoinEaten()
    {
        Debug.Log("Coin eaten!");
        
    }

    private void Start()
    {
        // Gắn hàm HandleCoinEaten vào sự kiện onCoinEaten
        onCoinEaten.AddListener(HandleCoinEaten);
    }

    private void OnDestroy()
    {
        // Loại bỏ hàm HandleCoinEaten khỏi sự kiện onCoinEaten trước khi đối tượng bị hủy
        onCoinEaten.RemoveListener(HandleCoinEaten);
    }
}
