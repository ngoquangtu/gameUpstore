using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShopManager : MonoBehaviour { 
    public ShopItem[] items;
    public static ShopManager Instance;
    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {

        if (items == null || items.Length <= 0) return;
        for(int i = 0; i < items.Length; i++)
        {
            var item = items[i];
            if(item != null)
            {
                if(i==0)
                {
                    Pref.SetBool(PrefConst.Player_Index + i, true);
                }
                else
                {
                    if(!PlayerPrefs.HasKey(PrefConst.Player_Index + i))
                    {
                        Pref.SetBool(PrefConst.Player_Index+i, false);
                    }
                }
            }
        }
    }
}

[System.Serializable]
public class ShopItem
{
    public int price;
    public Sprite hud;
    public Character characterPfab;
}
