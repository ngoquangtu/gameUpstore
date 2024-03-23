using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 24.0f;
    private Rigidbody2D rb;
    Quaternion rotatedDirection;
    private float bulletAngle;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Vector3 velocity = Quaternion.Euler(0, 0, bulletAngle) * Vector3.right;
        rb.velocity = velocity * bulletSpeed;

    }
    private void OnEnable()
    {

        float angle = Character.Instance.transform.eulerAngles.z +90.0f;
        bulletAngle = angle;

        // Gán góc quay mới cho viên đạn
        transform.rotation = Quaternion.Euler(0, 0, angle+90);


    }
    private void OnDisable()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Wall"))
        {
            gameObject.SetActive(false);
        }
    }
}
