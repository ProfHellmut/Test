using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour {

    [SerializeField]
    Vector3 startPos, endPos;

    [SerializeField]
    float speed;

	// Use this for initialization
	void Start () {
        StartCoroutine(MoveToEnd());
	}

    IEnumerator MoveToEnd()
    {
        while(true)
        {
            if (transform.position.x == endPos.x)
                transform.position = new Vector3(startPos.x, transform.position.y, transform.position.z);

            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }

        yield return null;
    }
}
