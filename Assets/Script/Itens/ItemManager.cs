using UnityEngine;
using Ebac.Core.singleton;
using TMPro;

public class ItemManager : Singleton<ItemManager>
{   

    public SOInt coins;
    public TextMeshProUGUI uiTextCoins;


    private void Start()
    {
        Reset();
        UpdateUI();
    }

    private void Reset()
    {
        coins.value = 0;
    }

    public void AddCoins(int amount = 1)
    {
        coins.value += amount;
    }

    private void UpdateUI()
    {
        //uiTextCoins.text = coins.ToString();
        //UIInGameManager.UpdateTextCoins(coins.value.ToString());
    }
}
