using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CirclePlayer : Character
{
    GameObject circlePrefab;


    private string prefabPath = "Assets/Prefabs/CirclePrefab.prefab";
    public CirclePlayer(float speed) : base(speed)
    {
        circlePrefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);
        Instantiate(circlePrefab);
    }
    void Start()
    {
        base.Start();
        speed = 12f;
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
