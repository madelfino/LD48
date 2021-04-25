using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleBounce : MonoBehaviour
{
    float t;

    // Start is called before the first frame update
    void Start()
    {
        t = 0;
    }

    // Update is called once per frame
    void Update()
    {
        t += 4 * Time.deltaTime;
        transform.Rotate(Vector3.forward, 0.3f * Mathf.Sin(t));
    }
}
