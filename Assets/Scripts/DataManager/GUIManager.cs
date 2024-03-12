using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour
{
    public TextMeshProUGUI coincountingText;
    public static GUIManager Instance;
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
    public void UpdateCoins()
    {
        if(coincountingText)
        {
            coincountingText.text = Pref.Coins.ToString();
        }
    }


}
