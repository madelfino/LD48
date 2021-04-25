using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuActions : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Main Scene");
    }

    public void ReturnToTitle()
    {
        SceneManager.LoadScene("Start Scene");
    }

    public void UpdateVolume()
    {
        Camera.main.GetComponent<AudioSource>().volume = GameObject.Find("VolumeSlider").GetComponent<Slider>().value;
    }
}
