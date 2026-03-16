using UnityEngine;

public class PlayScript : MonoBehaviour
{
    public GameObject[] hidden;
    public GameObject[] shown;
    public AudioSource gameMusic;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startGame()
    {
        gameMusic.Play();
        foreach(GameObject h in hidden)
        {
            h.SetActive(true);
        }
        Destroy(GameObject.FindGameObjectWithTag("placeholder"));
        foreach(GameObject s in shown)
        {
            s.SetActive(false);
        }

    }
}
