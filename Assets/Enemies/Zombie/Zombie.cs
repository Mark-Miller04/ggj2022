using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NoSleep.IOC;

public class Zombie : MonoBehaviour
{
    [Dock] GameManager gameManager;
    [Dock] Player player;

    [Header("Behaviour Variables")]

    [Tooltip("Scales the force applied each frame, which affects how quickly object is able to change direction.")]
    public float thrust;
    [Tooltip("Maximum allowable velocity of the skull in any direction.")]
    public float maxVelocity;

    // Internal References
    Rigidbody2D rb;
    Animator anim;
    [SerializeField] Vector2 target;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        target = transform.position;
    }

    void Update()
    {
        SetTarget();
        Move();
        ClampVelocity();
    }

    private void SetTarget()
    {
        if (player != null) {
            target = player.body.transform.position;
        }
        else {
            __TestDirection();
        }
    }

    private void Move()
    {
        Vector2 currentPos = new Vector2(transform.position.x, transform.position.y);
        Vector2 direction = (target - currentPos).normalized;
        direction.y = 0.0f;

        rb.AddForce(direction * thrust);
        anim.SetFloat("xVel", rb.velocity.x);
    }

    private void ClampVelocity()
    {
        if (rb.velocity.x >= maxVelocity) {
            rb.velocity = new Vector2(maxVelocity, rb.velocity.y);
        }
        else if (rb.velocity.x <= -maxVelocity) {
            rb.velocity = new Vector2(-maxVelocity, rb.velocity.y);
        }

        if (rb.velocity.y >= maxVelocity) {
            rb.velocity = new Vector2(rb.velocity.x, maxVelocity);
        }
        else if (rb.velocity.y <= -maxVelocity) {
            rb.velocity = new Vector2(rb.velocity.x, -maxVelocity);
        }
    }

    private void __TestDirection()
    {
        if (Vector3.Distance(target, transform.position) <= .25f)
        {
            float xPos = Random.Range(-2.5f, 2.5f);
            float yPos = transform.position.y;
            target = new Vector2(xPos, yPos);
        }
    }
}
