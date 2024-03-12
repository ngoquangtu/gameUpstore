using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TrianglePlayer : Character
{
    GameObject trianglePrefab;
    private bool isConstructed = false;
    private static MousePlayer instance;


    private string prefabPath = "Assets/Prefabs/TrianglePrefab.prefab";
    public TrianglePlayer(float speed) : base(speed)
    {
        trianglePrefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);
        Instantiate(trianglePrefab);

    }
    void Start()
    {
        base.Start();
        speed = 12f;
        if (isConstructed)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public override void bulletClick()
    {
        GameObject bullet = ObjectPooling.Instance.GetPooledObject();
        if (bullet != null)
        {
            bullet.transform.position = transform.position;
            bullet.SetActive(true);
        }
    }
}
