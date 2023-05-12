using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum ItemType
{
    COIN,
    POTION
}
public class ItemCollectableRandom : ItemCollectableBase
{
    [SerializeField] private ItemType itemType;

    public Collider2D collider;

    protected override void OnCollect()
    {
        base.OnCollect();
        if(itemType == ItemType.COIN)
        {
            ItemManager.Instance.AddCoin();
        } 
        else if(itemType == ItemType.POTION)
        {
            ItemManager.Instance.AddPotion();
        }

        collider.enabled = false;
    }

    
}
