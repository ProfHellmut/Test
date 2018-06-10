using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour {

    public GameObject player;
    public int points;

    Vector3 startPosition;
    Vector3 currentPosition;

    bool isGrabbed = false;

    public bool IsGrabbed
    {
        get
        {
            return isGrabbed;
        }

        set
        {
            isGrabbed = value;
        }
    }

    LevelManager manager;

    // Use this for initialization
    void Start () {
        startPosition = transform.position;
        manager = FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {

        if (IsGrabbed)
        {
            currentPosition.x = player.transform.position.x;
            currentPosition.y = player.transform.position.y + 0.7f;
        }            
        else
            currentPosition = startPosition;

        transform.position = currentPosition;

    }

    public void Collect()
    {
        Destroy(this.gameObject);
    }

    private void OnDestroy()
    {
        manager.Points += points;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision);
        if (collision.gameObject.tag == "Player" && player.GetComponent<PlayerScript>().Collectible == null)
        {
            IsGrabbed = true;
        }
    }


}
