using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public float speed = 20f;
    public float turnSpeed = 360;
    public AudioClip rockHitSfx;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = Camera.main.gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
        transform.Rotate(Vector3.back, turnSpeed * Time.deltaTime);

        if (transform.position.x > 20) Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("rock"))
        {
            audioSource.PlayOneShot(rockHitSfx);
            Destroy(collision.gameObject);
            Destroy(gameObject);
            GameObject.Find("submarine").GetComponent<SubmarineController>().IncrementScore();
        }
    }
}
