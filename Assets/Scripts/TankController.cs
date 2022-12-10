using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    public Rigidbody2D rb2d;
    private Vector2 movementVector;
    public float maxSpeeed = 10;
    public float rotationSpeed = 100;
    private void Awake()
    {
        rb2d= GetComponent<Rigidbody2D>();
    }

    public void HandleShoot()
    {
        Debug.Log("Shooting");
    }
    public void HandleMoveBody(Vector2 movementVector)
    {
        this.movementVector = movementVector;
    }
    public void HandleTurretMovement(Vector2 pointerPosition)
    {

    }
    private void FixedUpdate()
    {
        rb2d.velocity = (Vector2)transform.up * movementVector.y * 
            maxSpeeed * Time.fixedDeltaTime;
        rb2d.MoveRotation(transform.rotation *
            Quaternion.Euler(0,0,-movementVector.x * rotationSpeed * Time.fixedDeltaTime));
    }

}
