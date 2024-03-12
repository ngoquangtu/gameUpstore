using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MousePlayer : Character
{
     GameObject mousePrefab;
    private bool isConstructed = false;
    private static MousePlayer instance;


    private string prefabPath = "Assets/Prefabs/MousePrefab.prefab";
    public MousePlayer(float speed) : base(speed) 
    {
        mousePrefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);
        // Nếu đã tồn tại một thể hiện khác, hủy nó đi trước khi khởi tạo mới

        Instantiate(mousePrefab);
        instance = this; // Lưu trữ thể hiện mới nhất

    }
    void Start()
    {
        base.Start();
        speed = 10f;
        if(isConstructed)
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
