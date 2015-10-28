using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class WordScript : MonoBehaviour {

    
    public string option;
    public string word;
    private int gridIndex;
	// Use this for initialization
	void Start () {
     
	}
	
    public void setString (string msg)
    {
        gridIndex = 0;
        word = msg;
        GetComponent<TextMesh>().text = msg;
    }
    public string getname()
    {
        return word;
    }
    public void setIsOption(string value)
    {
        option = value;
    }

    public string getOption()
    {
        return option;
    }
    public bool hasSecondHalf(string value)
    {
        if (value == word)
            return true;
        return false;
    }

    public int getIndex()
    {
        return gridIndex;
    }

    public void setIndex(int index)
    {
        gridIndex = index;
    }

    void OnTriggerEnter2D(Collider2D other)
    {

       

    }
    // Update is called once per frame
    void Update () {
      


    }
}
