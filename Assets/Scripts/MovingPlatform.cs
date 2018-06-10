using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

    public Vector3 start, end;

    public Vector3 moveAngle;

    bool moveRight = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (moveRight)
        {
            transform.position += moveAngle * Time.deltaTime;            

            if (Vector3.Distance(transform.position, end) < 0.1f)
                moveRight = false;
        }
        else
        {
            transform.position -= moveAngle * Time.deltaTime;

            if (Vector3.Distance(transform.position, start) < 0.1f)
                moveRight = true;
        }

	}
}
