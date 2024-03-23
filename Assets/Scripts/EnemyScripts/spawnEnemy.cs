using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemy : MonoBehaviour
{
    private float widthDevice;
    private float heightDevice;

    private void Start()
    {
        widthDevice = Screen.width;
        heightDevice = Screen.height;
        Debug.Log(widthDevice + " " + heightDevice);
    }
}
