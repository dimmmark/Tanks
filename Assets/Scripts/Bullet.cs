using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10;
    public int damage = 5;
    public float maxDistance = 10;

    private Vector2 startPosition;
    private float conquareDistance = 0;
    private Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d= GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        conquareDistance = Vector2.Distance(transform.position, startPosition);
        if(conquareDistance >= maxDistance)
        {
            DisableObject();
        }
    }

    private void DisableObject()
    {
        rb2d.velocity= Vector2.zero;
        gameObject.SetActive(false);
    }

    public void Initialize()
    {
        startPosition= transform.position;
        rb2d.velocity = transform.up * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collidered " + collision.name);

        var damagable = collision.GetComponent<Damagable>();
        if(damagable != null)
        {
            damagable.Hit(damage);
        }
        DisableObject();
    }
}
