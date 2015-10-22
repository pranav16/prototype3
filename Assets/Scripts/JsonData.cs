using UnityEngine;
using System.Collections;
using SimpleJSON;
using System.Collections.Generic;


public class JsonData : MonoBehaviour {

    public TextAsset JsonLevel;
    private string jsonString;
    public static string Objective;
    public List<string> words;
    public List<string> accessibility;
    private int currentWord;
    private bool isReady = false;
   
    // Use this for initialization
    void Start () {
        jsonString = JsonLevel.text;
        var json = JSON.Parse(jsonString);
        Objective = json["objective"].Value;
        Debug.Log(Objective);
        JSONArray array = json["words"].AsArray;
        for(int i = 0; i< array.Count; i ++)
        {
            words.Add(array[i]["word"].Value);
            Debug.Log(words[i]);
            accessibility.Add(array[i]["option"].Value);

        }
        isReady = true;
        currentWord = 0;
     
    }

    public bool isWordExhausted()
    {

        if(currentWord < words.Count)
        {
            return false;
        }

        return true; 

    }
    public string getCurrentWord()
    {
       return words[currentWord];
    }
    public string getObjective()
    {
        return Objective;
    }

    public string getAccessibilityForWord()
    {
     
       return accessibility[currentWord++];
        
    }
	public bool getIsReady()
    {
        return isReady;
    }
	// Update is called once per frame
	void Update () {
	
	}
}
