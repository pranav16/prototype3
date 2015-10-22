using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelLoader : MonoBehaviour
{

    public TextAsset tileMapText;
    public GameObject darkFloorTexture;
    public GameObject lightFloorTexture;
    public GameObject[] propsTexture;
    public GameObject playerObject;
    public GameObject wordObject;
    public GameObject objectiveObject;
    private JsonData json;
    
    private string[] levelData;
    private float boardWidth,boardHeight;
    private GameObject jsonLevelLoader;
    private bool haveWordsBeenSpawned = false;
    private List<Vector3> positionsForWords;

    //private Transform board;

    // Use this for initialization
    void Start()
    {
        levelData = tileMapText.text.Split('\n');
        boardHeight = levelData.Length;
        positionsForWords = new List<Vector3>();
        for (int i = 0; i < levelData.Length; i++)
        {
            char[] line = levelData[i].ToCharArray();
            for (int j = 0; j < line.Length; j++)
            {
                boardWidth = line.Length;
            
                    switch (line[j])
                    {

                        case '0':
                            {
                                GameObject floor = Instantiate(lightFloorTexture, positionBasedOnTileLocation(i, j), Quaternion.identity) as GameObject;
                                floor.transform.SetParent(transform);
                                break;
                            }
                        case '1':
                            {
                                GameObject floor = Instantiate(darkFloorTexture, positionBasedOnTileLocation(i, j), Quaternion.identity) as GameObject;
                                floor.transform.SetParent(transform);
                                break;
                            }
                        case '2':
                            {
                                GameObject player = Instantiate(playerObject, positionBasedOnTileLocation(i, j), Quaternion.identity) as GameObject;
                                //player.transform.SetParent(transform);
                                GameObject floor = Instantiate(lightFloorTexture, positionBasedOnTileLocation(i, j), Quaternion.identity) as GameObject;
                                floor.transform.SetParent(transform);
                                break;
                            }
                    case '3':
                        {
                            Vector3 wordsLocation = positionBasedOnTileLocation(i, j);
                            positionsForWords.Add(wordsLocation);
                            GameObject floor = Instantiate(lightFloorTexture, positionBasedOnTileLocation(i, j), Quaternion.identity) as GameObject;
                            floor.transform.SetParent(transform);
                            break;
                        }
                        default:
                        {
                            GameObject floor = Instantiate(lightFloorTexture, positionBasedOnTileLocation(i, j), Quaternion.identity) as GameObject;
                            floor.transform.SetParent(transform);
                            break;
                        }
                          
                    }
                
            }
        }
         jsonLevelLoader = GameObject.FindGameObjectWithTag("Json");
    }
    Vector3 positionBasedOnTileLocation(int row,int coloumn)
    {
        float xCoordinate,yCoordinate;

        yCoordinate = boardHeight/2 - row - 1;
        xCoordinate = coloumn - boardWidth/2 + 1;

        return new Vector3(xCoordinate,yCoordinate,0.0f);
    }

   public void addWord()
    {
        if (positionsForWords.Count <= 0 || json.isWordExhausted())
            return;

        int randomRange = Random.Range(0, positionsForWords.Count);
        GameObject word = Instantiate(wordObject, positionsForWords[randomRange], Quaternion.identity) as GameObject;
        WordScript script = wordObject.GetComponent<WordScript>();
        script.setString(json.getCurrentWord());
        if (json.getAccessibilityForWord() == "true")
        {
            script.setIsCorrect(true);
        }
        else
        {
            script.setIsCorrect(false);
        }
        positionsForWords.RemoveAt(randomRange);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!haveWordsBeenSpawned)
        {
            json = jsonLevelLoader.GetComponent<JsonData>();
            if(json.getIsReady())
            {
                haveWordsBeenSpawned = true;
            }
            GameObject objective  = Instantiate(objectiveObject, new Vector3(-2.5f,8.0f,0.0f), Quaternion.identity) as GameObject;
            WordScript scriptObjective = objective.GetComponent<WordScript>();
            scriptObjective.setString(json.getObjective());
            int count = 0;
            while (count < 2)
            {
                addWord();
                count++;
            }    
        }
 
    }


}


