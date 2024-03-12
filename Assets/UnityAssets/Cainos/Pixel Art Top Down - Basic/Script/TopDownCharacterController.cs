using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cainos.PixelArtTopDown_Basic
{
    public class TopDownCharacterController : MonoBehaviour
    {
        public float speed;
        private VariableJoystick joystick;
        private Animator animator;

        private void Start()
        {
            animator = GetComponent<Animator>();
            joystick = FindObjectOfType<VariableJoystick>();
            if (joystick == null)
            {
                Debug.LogError("No VariableJoystick found in the scene!");
            }
        }


        private void Update()
        {
            Movement();
        }
        private void Movement()
        {
            if (joystick == null)
                return;
            Vector2 dir = new Vector2(joystick.Horizontal ,joystick.Vertical);

            // Kiểm tra hướng di chuyển
            if (dir != Vector2.zero)
            {
                // Xác định hướng di chuyển
                if (Mathf.Abs(dir.x) > Mathf.Abs(dir.y))
                {
                    // Xác định hướng ngang
                    if (dir.x > 0)
                        animator.SetInteger("Direction", 2); // Phải
                    else
                        animator.SetInteger("Direction", 3); // Trái
                }
                else
                {
                    // Xác định hướng dọc
                    if (dir.y > 0)
                        animator.SetInteger("Direction", 1); // Lên
                    else
                        animator.SetInteger("Direction", 0); // Xuống
                }
            }

            animator.SetBool("IsMoving", dir.magnitude > 0);

            GetComponent<Rigidbody2D>().velocity = speed * dir;
        }
    }
}
