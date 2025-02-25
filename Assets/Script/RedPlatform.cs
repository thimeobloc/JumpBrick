using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPlatform : MonoBehaviour
{
    public float speed = 2f;
    public float moveRange = 1f;

    private Vector3 startPos;
    private int direction = 1;

    void Start()
    {
        transform.position = new Vector3(0f, this.transform.position.y, this.transform.position.z);
        startPos = transform.position;
    }

    void FixedUpdate()
    {
        transform.position += Vector3.right * speed * direction * Time.deltaTime;
          //transform.position  +=  Vector3(direction, this.transform.position.y, this.transform.position.z) * speed *Time.deltaTime ;

        if (Mathf.Abs(transform.position.x - startPos.x) > moveRange)
        {
            direction *= -1; // Change de direction
        }
    }
}
