using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopUI : MonoBehaviour
{
    public TextMeshProUGUI priceText;
    public Image hud;
    public Button btn;
    public void UpdateUI(ShopItem item,int shopItemID)
    {
        if (item == null) return;
        if(hud)
        {
            hud.sprite = item.hud;
            
        }
        bool isUnlocked = Pref.GetBool(PrefConst.Player_Index + shopItemID);
        if (isUnlocked)
        {
            if(shopItemID==Pref.CurPlayerId)
            {
                if(priceText)
                {
                    priceText.text = "Active";
                }
            }
            else
            {
                if(priceText)
                {
                    priceText.text = "Owned";
                }
            }
        }
        else
        {
            priceText.text = item.price.ToString();
        }
    }
}
