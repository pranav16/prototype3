using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    private Vector3 previousPosition;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Vector3 position = transform.position;
        previousPosition = position;
        transform.position = position;
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            position.y += 1.0f;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            position.y -= 1.0f;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            position.x -= 1.0f;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            position.x += 1.0f;
        }
        transform.position = position;
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if(other.tag == "Obsticle")
        {
            transform.position = previousPosition;
        }

    }
 
}
