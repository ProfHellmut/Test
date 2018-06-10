using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public float moveSpeed = 10f;
    float movement;

    public float jumpHeight = 5f;

    int grounded = 0;
    Rigidbody2D rb;

    Transform respawnPoint;
    bool alive = true;

    Animator anim;

    GameObject collectible = null;

    public GameObject Collectible
    {
        get
        {
            return collectible;
        }
    }

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        respawnPoint = this.transform;
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        movement = Input.GetAxis("Horizontal");
        

        if ((Input.GetButtonDown("Jump") || Input.GetKeyDown("joystick button 0")) && grounded < 2)
        {
            Jump();
            grounded++;
        }

        if (!alive)
        {
            transform.position = respawnPoint.position;
            alive = true;
        }
        Debug.Log(collectible);

        Animations();
	}

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(movement * moveSpeed, rb.velocity.y);
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.AddForce(new Vector2(0, jumpHeight));
    }

    void Animations()
    {
        anim.SetFloat("walk", Mathf.Abs(movement));
        anim.SetBool("jump", grounded > 0);
        
        if (movement >= 0)
            transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        else
            transform.localScale = new Vector3(-1.2f, 1.2f, 1.2f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Platform")
            grounded = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Respawn")
            respawnPoint = collision.gameObject.transform;

        if (collision.gameObject.tag == "Lava" || collision.gameObject.tag == "Spikes")
        {
            alive = false;
            collectible.GetComponent<Collectible>().IsGrabbed = false;
            collectible = null;
        }
            

        if (collision.gameObject.tag == "Collectible" && collectible == null)
            collectible = collision.gameObject;

        if (collision.gameObject.tag == "Coinbox" && collectible != null)
        {
            collectible.GetComponent<Collectible>().Collect();
            collectible = null;
        }
    }

}
