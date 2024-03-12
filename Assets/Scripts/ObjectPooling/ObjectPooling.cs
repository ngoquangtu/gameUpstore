using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public static ObjectPooling Instance;
    private List<GameObject> pooledObjects = new List<GameObject>();
    [SerializeField] private int amountPool = 20;
    [SerializeField] private GameObject bulletPrefab;

    private void Awake()
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
    private void Start()
    {
        for(int i=0;i<amountPool; i++)
        {
            GameObject objs = Instantiate(bulletPrefab);
            objs.SetActive(false);
            pooledObjects.Add(objs);
        }
    }
    public GameObject GetPooledObject()
    {
        for(int i=0;i<pooledObjects.Count;i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }
}
