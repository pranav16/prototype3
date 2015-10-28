using UnityEngine;
using System.Collections;

public class WordCrate : MonoBehaviour {

 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	

	}
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player1")
        {
            //if (isCorrect)
            //Destroy(gameObject);
           Player pl = other.GetComponent<Player>();
            if (pl.getState() != "Idle")
                return;

            pl.setState("pickup");
            GameObject player = GameObject.FindGameObjectWithTag("Player1");
            pl.setWord(this.gameObject);
            this.GetComponent<BoxCollider2D>().enabled = false;

        }
        if (other.tag == "Player2")
        {
            //if (isCorrect)
            //Destroy(gameObject);
            Player pl = other.GetComponent<Player>();
            if (pl.getState() != "Idle")
                return;

            pl.setState("pickup");
            GameObject player = GameObject.FindGameObjectWithTag("Player1");
            pl.setWord(this.gameObject);
            this.GetComponent<BoxCollider2D>().enabled = false;
        }
        if (other.tag == "Player3")
        {
            //if (isCorrect)
            //Destroy(gameObject);
            Player pl = other.GetComponent<Player>();
            if (pl.getState() != "Idle")
                return;

            pl.setState("pickup");
            GameObject player = GameObject.FindGameObjectWithTag("Player1");
            pl.setWord(this.gameObject);
            this.GetComponent<BoxCollider2D>().enabled = false;

        }
        if (other.tag == "Player4")
        {
            //if (isCorrect)
            //Destroy(gameObject);
            Player pl = other.GetComponent<Player>();
            if (pl.getState() != "Idle")
                return;

            pl.setState("pickup");
            GameObject player = GameObject.FindGameObjectWithTag("Player1");
            pl.setWord(this.gameObject);
            this.GetComponent<BoxCollider2D>().enabled = false;
        }

    }
}
