using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBtn : MonoBehaviour
{
    public void Fire()
    {
        Character.Instance.bulletClick();
    }
}
