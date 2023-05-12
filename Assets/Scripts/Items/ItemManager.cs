using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Singleton;
using TMPro;

public class ItemManager : Singleton<ItemManager>
{
    public SOInt coin;
    public SOInt potion;

    public TextMeshProUGUI uiTextCoin;
    

    void Start()
    {
        Reset();
    }

    private void Reset()
    {
        potion.value = 0;
        coin.value = 0;
    }

    public void AddCoin(int amount = 1)
    {    
        coin.value += amount;
    }

    public void AddPotion(int amount = 1)
    {
        potion.value += amount;
    }
}
