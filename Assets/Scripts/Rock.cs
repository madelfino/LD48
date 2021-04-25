using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    float turnSpeed;
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        turnSpeed = Random.Range(-150f, 150f);
        speed = Random.Range(3f, 13f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        transform.Rotate(Vector3.right, turnSpeed * Time.deltaTime);

        if (transform.position.x < -20)
        {
            Destroy(gameObject);
        }
    }
}
