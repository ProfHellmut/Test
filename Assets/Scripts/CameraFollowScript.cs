using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour {

    [SerializeField]
    GameObject target;

    [SerializeField]
    float smoothX, SmoothY;

    private Vector2 velocity;

    private void FixedUpdate()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, target.transform.position.x, ref velocity.x, smoothX);
        float posY = Mathf.SmoothDamp(transform.position.y, target.transform.position.y + 1.5f, ref velocity.y, SmoothY);

        transform.position = new Vector3(posX, posY,transform.position.z);
    }
}
