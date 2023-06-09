using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float moveSpeed = 3;
    private Vector2 rawInput;

    private Vector2 minBounds, maxBounds;

    [SerializeField] private float paddingLeft, paddingRight, paddingTop, paddingBottom;

    [SerializeField] private Shooter shooter1;
    [SerializeField] private Shooter shooter2;
    [SerializeField] private Shooter shooter3;


    private void Start()
    {
        InitBounds();
    }

    void Update()
    {
        Move();
    }

    void InitBounds()
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0,0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }

    void Move()
    {
        Vector2 deltaPosition = rawInput * (moveSpeed * Time.deltaTime);
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x + deltaPosition.x, minBounds.x + paddingLeft, maxBounds.x - paddingRight);
        newPos.y = Mathf.Clamp(transform.position.y + deltaPosition.y, minBounds.y + paddingBottom, maxBounds.y - paddingTop);
        transform.position = newPos;
    }
    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
//        Debug.Log(rawInput);
    }

    void OnFire(InputValue value)
    {
        if (shooter1 != null)
        {
            shooter1.isFiring = value.isPressed;
        }
        if (shooter2 != null)
        {
            shooter2.isFiring = value.isPressed;
        }
        if (shooter3 != null)
        {
            shooter3.isFiring = value.isPressed;
        }
    }
}
