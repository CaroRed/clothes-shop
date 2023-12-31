using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinsManager : MonoBehaviour
{
    public static CoinsManager _Instance;
    [SerializeField] TextMeshProUGUI coinsTxt;
    [SerializeField] GameObject alertPanel;

    [SerializeField] int startCoins = 50;
    int coins = 0;

    private void Awake() 
    { 
        if(_Instance == null)
        {
            _Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        //AddCoins(startCoins);
        LoadCoins();
    }

    void LoadCoins()
    {
        coins = PlayerPrefs.GetInt("playerCoins", startCoins);
        UpdateCoinsUI();
    }

    public void AddCoins(int value)
    {
        coins+= value;
        PlayerPrefs.SetInt("playerCoins", coins);
        PlayerPrefs.Save();
        UpdateCoinsUI();
    }

    public void RemoveCoins(int value)
    {
        coins-= value;
        PlayerPrefs.SetInt("playerCoins", coins);
        PlayerPrefs.Save();
        UpdateCoinsUI();
    }

    public int GetBallance()
    {
        return coins;
    }

    public void UpdateCoinsUI()
    {
        coinsTxt.text = coins.ToString();
    }

    public void DisplayAlertPanel()
    {
        alertPanel.SetActive(true);
    }
}
