using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float upwardForce = 10;
    public float horizontalForce = 5;
    public float speed = 10;
    public float attackInterval = 3;
    public GameObject bullet;

    bool flyUp;
    bool attack;
    float joystickhorizontalAxis;
    float keyboardHorizontalAxis;
    float horizontalAxis;
    float attackTimer = 0;

    Rigidbody2D body;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        GetInput();

        if (attack && attackTimer < 0)
        {
            var b = Instantiate(bullet);
            b.transform.position = transform.position;

            attackTimer = attackInterval;
        }

        HorizontalMovement();

        VerticalMovement();

        attackTimer -= Time.deltaTime;
    }

    void HorizontalMovement()
    {
        if (Mathf.Abs(body.velocity.x) < speed)
        {
            body.AddForce(new Vector2(horizontalForce * horizontalAxis, 0));
        }
        else
        {
            body.AddForce(new Vector2(-body.velocity.x, 0));
        }
    }

    void VerticalMovement()
    {
        if (flyUp)
        {
            if (Mathf.Abs(body.velocity.y) < speed)
            {
                body.AddForce(new Vector2(0, upwardForce), ForceMode2D.Impulse);
            }
            else
            {
                body.velocity = new Vector2(body.velocity.x, speed);
            }
        }

        //if(Mathf.Abs(body.velocity.y) > speed)
        //{
        //    body.AddForce(new Vector2(0, -body.velocity.y));
        //}
    }

    void GetInput()
    {
        joystickhorizontalAxis = Input.GetAxis("Joystick Horizontal");
        keyboardHorizontalAxis = Input.GetAxis("Keyboard Horizontal");
        
        horizontalAxis = 0;

        if (keyboardHorizontalAxis > 0 || keyboardHorizontalAxis < 0)
            horizontalAxis = keyboardHorizontalAxis;

        if (joystickhorizontalAxis > 0 || joystickhorizontalAxis < 0)
            horizontalAxis = joystickhorizontalAxis;

        flyUp = Input.GetButton("Joystick Vertical") || Input.GetButton("Keyboard Vertical");
        attack = Input.GetButton("Joystick Attack");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.collider.tag)
        {
            case "Enemy":
                Destroy(this);
                break;
        }
    }
}