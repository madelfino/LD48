using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackAndForth : MonoBehaviour
{
    bool goingRight = true;
    float speed = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (goingRight)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            if (transform.position.x > 20) goingRight = false;
        } else
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            if (transform.position.x < -20) goingRight = true;
        }
    }
}
