using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SubmarineController : MonoBehaviour
{
    public float speed = 5f;
    public float turnSpeed = 60f;
    public GameObject projectilePrefab;
    public GameObject healthIndicator;
    int health = 3;
    GameObject[] hearts;
    public AudioClip rockHitSfx;
    public Text scoreText;
    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        hearts = new GameObject[3];
        for (int i = 0; i < health; i++)
        {
            hearts[i] = (Instantiate(healthIndicator, new Vector3(-15f + i, 12f, 12f), healthIndicator.transform.rotation));
        }
    }

    // Update is called once per frame
    void Update()
    {
        float horizInput = Input.GetAxis("Horizontal");
        float vertInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.up * vertInput * Time.deltaTime * speed, Space.World);
        transform.Translate(Vector3.right * horizInput * Time.deltaTime * speed, Space.World);
        if (transform.position.x < -18) transform.position = new Vector3(-18f, transform.position.y, transform.position.z);
        if (transform.position.x > 9) transform.position = new Vector3(9f, transform.position.y, transform.position.z);
        if (transform.position.y < -13) transform.position = new Vector3(transform.position.x, -13f, transform.position.z);
        if (transform.position.y > 11) transform.position = new Vector3(transform.position.x, 11f, transform.position.z);

        GameObject.Find("Propeller").transform.Rotate(Vector3.forward, 180f * Time.deltaTime);
        
        //transform.Rotate(Vector3.up, vertInput * Time.deltaTime * turnSpeed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, transform.position + new Vector3(3f, 0f, 0f), projectilePrefab.transform.rotation);
        }
    }

    public void IncrementScore()
    {
        score++;
        scoreText.text = "Rocks Mined: " + score;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("rock"))
        {
            Destroy(collision.gameObject);
            Camera.main.GetComponent<AudioSource>().PlayOneShot(rockHitSfx);
            health -= 1;
            Destroy(hearts[health]);
            if (health <= 0)
            {
                SceneManager.LoadScene("Game Over Scene");
            }
        } else if (collision.gameObject.CompareTag("tentacle"))
        {
            SceneManager.LoadScene("Game Over Scene");
        }
    }
}
