using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RockSpawner : MonoBehaviour
{
    public GameObject[] rockPrefabs;
    float delay = 2f;
    int depth = 0;
    public Text depthText;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnRock", delay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRock()
    {
        if (SceneManager.GetActiveScene().name == "Main Scene")
        {
            if (delay > 0.1f)
            {
                delay -= 0.05f;
            }
            else if (GameObject.Find("submarine").GetComponent<SubmarineController>().score > depth * 12)
            {
                depth += 1;
                depthText.text = "Depth: " + depth;
                if (depth > 10)
                {
                    SceneManager.LoadScene("Victory Scene");
                }

                Color c = new Color(0, 0, Mathf.Max(1 - depth * 0.1f, 0));
                Camera.main.backgroundColor = c;
                delay = 1.5f;
            }
        } else
        {
            delay = 1f;
        }
        int rockIndex = Random.Range(0, rockPrefabs.Length);
        Instantiate(rockPrefabs[rockIndex], new Vector3(20f, Random.Range(-11f, 13f), 12), rockPrefabs[rockIndex].transform.rotation);
        Invoke("SpawnRock", delay);
    }
}
