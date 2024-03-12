using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SettingManager : MonoBehaviour
{
    [SerializeField] private GameObject shopPanel;
    [SerializeField] private GameObject exitPanel;

    public void OpenShopPanel()
    {
        shopPanel.SetActive(true);
    }
    public void CloseShopPanel()
    {
        shopPanel.SetActive(false);
    }
    public void ExitGame()
    {
        exitPanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void YesBtn()
    {
        Application.Quit();
    }
    public void NoBtn()
    {
        exitPanel.SetActive(false);
        Time.timeScale = 1;
    }
    
}
