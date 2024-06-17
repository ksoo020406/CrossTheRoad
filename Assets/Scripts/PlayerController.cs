using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    private Vector2 curMovementInput;

    private Rigidbody rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        // dir == 방향
        Vector3 dir = transform.forward * curMovementInput.y + transform.right * curMovementInput.x; // forward는 y값으로 앞뒤 구분, right는 x값으로 좌우 구분
        dir *= moveSpeed; // 방향에 힘 곱해주기
        dir.y = rigidbody.velocity.y; // 높이(y) 값 유지

        rigidbody.velocity = dir;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            curMovementInput = context.ReadValue<Vector2>();

            //rigidbody.AddForce(Vector2.up * 5, ForceMode.Impulse);
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            curMovementInput = Vector2.zero;
        }
    }

}
