using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    private Vector3 previousPosition;
    // Use this for initialization
 
    public float speed = 200.0f;
    private Rigidbody2D rb2D;
    void Start()
    {
        
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 position = transform.position;
        previousPosition = position;
        transform.position = position;
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            position.y += speed * Time.deltaTime;
            

        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            position.y -= speed * Time.deltaTime;
           

        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            position.x -= speed * Time.deltaTime;
            
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            position.x += 200.0f * Time.deltaTime;
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
