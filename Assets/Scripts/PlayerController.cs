using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    public float speed = 0;
    private int count;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public AudioSource winAudio;
    public AudioSource pickUpAudio;
    public AudioSource loseAudio;
    public AudioSource BGM;
    public ParticleSystem deathBurst;
    public ParticleSystem pickupBurst;
    public ParticleSystem enemyBurst;


    void Start()
    {
        rb = GetComponent <Rigidbody>();
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
        
    }

    void OnMove (InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 7)
        {
            BGM.Stop();
            winAudio.Play();
            winTextObject.SetActive(true);
            Instantiate(enemyBurst, GameObject.FindGameObjectWithTag("Enemy").transform.position, Quaternion.identity);
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        }
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3 (movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            pickUpAudio.Play();
            Instantiate(pickupBurst, other.transform.position, Quaternion.identity);
            other.gameObject.SetActive(false);
            count += 1;
            SetCountText();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
            {
                BGM.Stop();
                loseAudio.Play();
                Instantiate(deathBurst, transform.position, Quaternion.identity);
                deathBurst.Play();
                gameObject.SetActive(false);
                winTextObject.gameObject.SetActive(true);
                winTextObject.GetComponent<TextMeshProUGUI>().text = "You Lose!";
                collision.gameObject.GetComponentInChildren<Animator>().SetFloat("speed_f", 0);
            }
    }


}
