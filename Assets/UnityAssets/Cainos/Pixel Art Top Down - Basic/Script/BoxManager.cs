
using UnityEngine;
using System;
public class BoxManager : MonoBehaviour
{
    public  int countmaxBox;
    [HideInInspector]
    public int countTrue=0;
    [HideInInspector]
    public int countFalse = 0;

    public static BoxManager Instance;

    public event Action AllBoxesUsed;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    /*    private void Update()
        {
            checkCountBox();
        }
        private void checkCountBox()
        {
            if(countTrue==countmaxBox)
            {
                Debug.Log("Tat ca cac thung da dung het");

            }
        }*/
    private void Start()
    {
        AllBoxesUsed += CheckCountBox;
    }

    private void OnDestroy()
    {
        // Đảm bảo rằng sự kiện được hủy bỏ khi đối tượng bị hủy
        AllBoxesUsed -= CheckCountBox;
    }

    // Hàm kiểm tra số lượng hộp và gọi sự kiện khi cần
    private void CheckCountBox()
    {
        if (countTrue == countmaxBox)
        {
            Debug.Log("Tất cả các thùng đã được sử dụng hết");
        }
    }

    public void BoxUsed(bool used)
    {
        if (used)
        {
            countTrue++;
        }
        else if (!used)
        {
            countFalse++;

        }
        if (countTrue == countmaxBox)
        {
            AllBoxesUsed?.Invoke();
        }
    }


}
