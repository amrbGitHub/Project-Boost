using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHandler : MonoBehaviour
{
    [HideInInspector]public bool isPaused;
    public AudioSource pauseMusic;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            Time.timeScale = isPaused ? 0 : 1;
            if (isPaused)
            {
                pauseMusic.Play();
            }
            else
            {
                pauseMusic.Stop();
            }
        }
    }
    public void OnResumeButtonClicked()
    {

        isPaused = !isPaused;
        Time.timeScale = 1;
        pauseMusic.Stop();

    }

}
