using UnityEngine;

public class Scrolling : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 2f;
    [SerializeField] private float resetPositionX = -19f;
    [SerializeField] private float startPositionX = 19f;

    private void Update()
    {
        transform.position += Vector3.left * scrollSpeed * Time.deltaTime;
        
        if (transform.position.x <= resetPositionX)
        {
            transform.position = new Vector3(startPositionX, transform.position.y, transform.position.z);
        }
    }
}
