using System;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    [SerializeField] private  int gold;
    [HideInInspector]
    public  int levelUnlocked;
    [HideInInspector]
    public string namePlayer;

    private void Start()
    {
        if (!PlayerPrefs.HasKey(PrefConst.COIN_KEY))
        {
            Pref.Coins = gold;
        }
        GUIManager.Instance.UpdateCoins();
    }
    public  void Awake()
    {
        if(instance==null)
        {
            instance = this;
  /*          DontDestroyOnLoad(this.gameObject);*/
        }
        else
        {
            Destroy(gameObject);
        }
    }


}
