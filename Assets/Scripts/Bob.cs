using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bob : MonoBehaviour
{
    float t;

    // Start is called before the first frame update
    void Start()
    {
        t = Random.Range(0f, 3.14f);
    }

    // Update is called once per frame
    void Update()
    {
        t += 4 * Time.deltaTime;
        //transform.Translate(Vector3.up * 0.02f * Mathf.Sin(t), Space.World);
        transform.Rotate(Vector3.forward, 30f * Time.deltaTime);
    }
}
