using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    int levelsUnlocked;
    [SerializeField] private Button[] buttons;
     void Start()
    {
        DataManager.instance.levelUnlocked = PlayerPrefs.GetInt(PrefConst.Level_Unlocked, 2);
        levelsUnlocked = DataManager.instance.levelUnlocked;
         
        for (int i=0;i<buttons.Length;i++)
        {
            buttons[i].interactable = false;
            buttons[i].transform.GetChild(0).gameObject.SetActive(true);
        }
        for(int i=0;i< levelsUnlocked; i++)
        {
            buttons[i].interactable=true;
            buttons[i].transform.GetChild(0).gameObject.SetActive(false);

        }
        

    }
    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }
    public void PassLevel()
    {
        int currentLevel=SceneManager.GetActiveScene().buildIndex;
        if(currentLevel >= PlayerPrefs.GetInt(PrefConst.Level_Unlocked))
        {
            PlayerPrefs.SetInt(PrefConst.Level_Unlocked, currentLevel + 1);
            DataManager.instance.levelUnlocked = PlayerPrefs.GetInt(PrefConst.Level_Unlocked);

           levelsUnlocked =DataManager.instance.levelUnlocked;
        }
        SceneManager.LoadScene(levelsUnlocked);
    }
}
