using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject bullet;
    public float spawnInterval = 3;
    public float spawnRadius = 15;
    float spawnTimer = 0;

    void Start ()
    {
		
	}
	
	void Update ()
    {
        if (spawnTimer < 0)
        {
            var b = Instantiate(bullet, transform);
            b.transform.localPosition = Vector2.zero;

            b.transform.localPosition = new Vector2(0, Random.Range(-spawnRadius, spawnRadius));
            //var randomSize = Random.Range(.1f, 1f);
            //b.transform.localScale = new Vector2(randomSize, ran);

            spawnTimer = spawnInterval;
        }

        spawnTimer -= Time.deltaTime;	
	}
}
