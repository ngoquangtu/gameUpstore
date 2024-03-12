using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SquarePlayer : Character
{
    GameObject squarePrefab;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed = 20.0f;
   


    private string prefabPath = "Assets/Prefabs/SquarePrefab.prefab";
    public SquarePlayer(float speed) : base(speed)
    {
        squarePrefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);
        Instantiate(squarePrefab);
    }
    void Start()
    {
        base.Start();
        speed = 15f;
        bulletSpeed = 20.0f;
    }

    private void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public override void bulletClick()
    {
        GameObject bullet = ObjectPooling.Instance.GetPooledObject();
        if (bullet != null )
        {
            bullet.transform.position = transform.position;
            bullet.SetActive(true);
        }
    }
}
