using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class WordScript : MonoBehaviour {

    
    public bool isCorrect;
	// Use this for initialization
	void Start () {
     
	}
	
    public void setString (string msg)
    {
        GetComponent<TextMesh>().text = msg;
    }

    public void setIsCorrect(bool value)
    {
        isCorrect = value;
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            if(isCorrect)
            Destroy(gameObject);
            LevelLoader loader = GameObject.FindGameObjectWithTag("Level").GetComponent<LevelLoader>();
            loader.addWord();
        }

    }
    // Update is called once per frame
    void Update () {
	
	}
}
