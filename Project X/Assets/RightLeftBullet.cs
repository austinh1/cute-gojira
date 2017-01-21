using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightLeftBullet : MonoBehaviour
{
    public float speed = 10;
    Rigidbody2D body;
	
	void Start ()
    {
        body = GetComponent<Rigidbody2D>();
	}
	
	void Update ()
    {
        body.velocity = new Vector2(-speed, 0);	
	}
}
