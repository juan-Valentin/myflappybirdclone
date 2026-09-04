using UnityEngine;
using UnityEngine.Serialization;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private float jumpForce = 5f;
    
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip flapClip;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocityY = jumpForce;
            
            // Swoosh sound effect
            audioSource.PlayOneShot(flapClip);
        }
    }
}