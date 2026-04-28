using UnityEngine;

public class PlayScript : MonoBehaviour
{
    public AudioSource gameMusic;
    public AudioSource menuMusic;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startGame()
    {
        Time.timeScale = 1;
        gameMusic.Play();
        menuMusic.Stop();

    }
}
