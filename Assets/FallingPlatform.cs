using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour {

    Rigidbody2D rb;

    Vector3 startPoint;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;

        startPoint = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            rb.isKinematic = false;
            Invoke("ReturnToOrigin", 4f);
        }
    }

    void ReturnToOrigin()
    {
        Debug.Log(startPoint);
        rb.velocity = new Vector2(0, 0);
        rb.isKinematic = true;
        transform.position = startPoint;
    }
}
