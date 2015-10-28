using UnityEngine;
using System.Collections;
using GamepadInput;

public class Player : MonoBehaviour
{
    private Vector3 previousPosition;
    // Use this for initialization
    [HideInInspector]
    public GamePad.Index index;
    public float speed = 15.0f;
    private string state;
    private GameObject word;
    void Start()
    {
        state = "Idle";
      
    }
    public GamePad.Index getIndex()
    {
        return index;
    }
    // Update is called once per frame
    void Update()
    {
        
        GamePad.GetTrigger(GamePad.Trigger.RightTrigger,index);
        GamepadState state = GamePad.GetState(index);
        Vector3 position = transform.position;
        previousPosition = position;
        transform.position = position;
        if (state.LeftStickAxis.y > 0.0f && position.y < 8.0f)
        {
            position.y += speed * Time.deltaTime;
           
        }
        if (state.LeftStickAxis.y < 0.0f && position.y > -8.0f)
        {
            position.y -= speed * Time.deltaTime;
           

        }
        if (state.LeftStickAxis.x < 0.0f && position.x > -15.0f)
        {
            position.x -= speed * Time.deltaTime;
            
        }
        if (state.LeftStickAxis.x > 0.0f && position.x < 15.0f)
        {
            position.x += speed * Time.deltaTime;
        }
        transform.position = position;   
        if(word)
        {
            word.transform.position = position;
        }
           
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if(other.tag == "Obsticle")
        {
            transform.position = previousPosition;
        }

    }
   public void setWord(GameObject word)
    {
        this.word = word;
    }

    public void destroyWord()
    {
        GameObject.Destroy(word);
        word = null;
    }
    public GameObject getWord()
    {
        return word;
    }

    public void setState(string state)
    {
        this.state = state;
    }

    public string getState()
    {
        return state;
    }

 
}
