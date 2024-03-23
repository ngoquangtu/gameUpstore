using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float rayLength = 10f; // Độ dài của tia Raycast
    public Color rayColor = Color.red; // Màu sắc của tia Raycast
    public float lineWidth = 0.1f; // Độ rộng của đường vẽ
    public float lineWidthTarget = 0.5f; // Độ rộng mục tiêu của đường vẽ
    public float lerpSpeed = 1f; // Tốc độ chuyển đổi giữa độ rộng hiện tại và độ rộng mục tiêu

    private LineRenderer lineRenderer;
    private float currentLineWidth; // Độ rộng hiện tại của đường vẽ

    void Start()
    {
        // Lấy tham chiếu đến Line Renderer gắn trên GameObject này
        lineRenderer = GetComponent<LineRenderer>();
        // Đặt màu của đường vẽ
        lineRenderer.startColor = rayColor;
        lineRenderer.endColor = rayColor;
        // Đặt độ rộng của đường vẽ ban đầu
        SetLineWidth(lineWidth);
        // Khởi tạo độ rộng hiện tại
        currentLineWidth = lineWidth;
    }

    void Update()
    {
        // Tạo một Vector2 để lưu hướng của tia Raycast, trong trường hợp này là hướng lên trên
        Vector2 rayDirection = Vector2.up;

        // Thực hiện Raycast từ vị trí của đối tượng hiện tại (transform.position) theo hướng đã chọn
        RaycastHit2D hit = Physics2D.Raycast(transform.position, rayDirection, rayLength);

        // Nếu có va chạm, đặt điểm cuối của Line Renderer là điểm va chạm
        if (hit.collider != null)
        {
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, hit.point);
        }
        else
        {
            // Nếu không có va chạm, đặt điểm cuối của Line Renderer là điểm cuối của tia Raycast
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, transform.position + (Vector3)rayDirection * rayLength);
        }

        // Dùng hàm Lerp để chuyển độ rộng từ độ rộng hiện tại đến độ rộng mục tiêu
        currentLineWidth = Mathf.Lerp(currentLineWidth, lineWidthTarget, lerpSpeed * Time.deltaTime);
        // Cập nhật độ rộng của đường vẽ
        SetLineWidth(currentLineWidth);
    }

    // Phương thức để đặt độ rộng của đường vẽ
    private void SetLineWidth(float width)
    {
        lineRenderer.startWidth = width;
        lineRenderer.endWidth = width;
    }
}