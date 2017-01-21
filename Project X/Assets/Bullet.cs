using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10;
    public bool isRight = true;

    Rigidbody2D body;
	
	void Start ()
    {
        body = GetComponent<Rigidbody2D>();
	}
	
	void Update ()
    {
        var sp = isRight ? speed : -speed;
        body.velocity = new Vector2(sp, 0);	
	}
}
