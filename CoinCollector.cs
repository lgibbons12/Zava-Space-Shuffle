using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CoinCollector : MonoBehaviour
{
    [SerializeField] private Text coinsText;
    public GameObject coinsFolder;
    public int coins = 0;

    void Start()
    {
        coins = PlayerPrefs.GetInt("coins");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            collision.gameObject.SetActive(false);
            coins++;
            PlayerPrefs.SetInt("coins", coins);
            coinsText.text = "Coins: " + PlayerPrefs.GetInt("coins");
            
        }
    }
    public void updateCoins()
    {
        coinsText.text = "Coins: " + coins;
    }
    
}

