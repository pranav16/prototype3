using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GamepadInput;
public class LevelLoader : MonoBehaviour
{

    public TextAsset tileMapText;
    public GameObject darkFloorTexture;
    public GameObject lightFloorTexture;
    public GameObject[] propsTexture;
    public GameObject[] playerPositions;
    public GameObject[] playerObjects;
    public GameObject wordObject;
    public List<int> ListOfFreeIndexs;
    public GameObject objectiveObject;
    private JsonData json;
    private List<string> wordsOnBoard;
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
        wordsOnBoard = new List<string>();
        ListOfFreeIndexs = new List<int>();
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
                                //GameObject floor = Instantiate(darkFloorTexture, positionBasedOnTileLocation(i, j), Quaternion.identity) as GameObject;
                                //floor.transform.SetParent(transform);
                                break;
                            }
                        case '2':
                            {
                                GameObject player = Instantiate(playerObjects[0], positionBasedOnTileLocation(i, j), Quaternion.identity) as GameObject;
                                //player.transform.SetParent(transform);
                                Player playerScript = player.GetComponent <Player>();
                                playerScript.index = GamePad.Index.One;
                                GameObject floor = Instantiate(lightFloorTexture, positionBasedOnTileLocation(i, j), Quaternion.identity) as GameObject;
                                floor.transform.SetParent(transform);
                                break;
                            }
                
                    case '3':
                        {
                            GameObject player = Instantiate(playerObjects[1], positionBasedOnTileLocation(i, j), Quaternion.identity) as GameObject;
                            //player.transform.SetParent(transform);
                            Player playerScript = player.GetComponent<Player>();
                            playerScript.index = GamePad.Index.Two;
                            GameObject floor = Instantiate(lightFloorTexture, positionBasedOnTileLocation(i, j), Quaternion.identity) as GameObject;
                            floor.transform.SetParent(transform);
                            break;
                        }
                    case '4':
                        {
                            GameObject player = Instantiate(playerObjects[2], positionBasedOnTileLocation(i, j), Quaternion.identity) as GameObject;
                            //player.transform.SetParent(transform);
                            Player playerScript = player.GetComponent<Player>();
                            playerScript.index = GamePad.Index.Three;
                            GameObject floor = Instantiate(lightFloorTexture, positionBasedOnTileLocation(i, j), Quaternion.identity) as GameObject;
                            floor.transform.SetParent(transform);
                            break;
                        }
                    case '5':
                        {
                            GameObject player = Instantiate(playerObjects[3], positionBasedOnTileLocation(i, j), Quaternion.identity) as GameObject;
                            //player.transform.SetParent(transform);
                            Player playerScript = player.GetComponent<Player>();
                            playerScript.index = GamePad.Index.Four;
                            GameObject floor = Instantiate(lightFloorTexture, positionBasedOnTileLocation(i, j), Quaternion.identity) as GameObject;
                            floor.transform.SetParent(transform);
                            break;
                        }
                    case '6':
                        {
                            Vector3 wordsLocation = positionBasedOnTileLocation(i, j);
                            positionsForWords.Add(wordsLocation);
                            GameObject floor = Instantiate(darkFloorTexture, positionBasedOnTileLocation(i, j), Quaternion.identity) as GameObject;
                            floor.transform.SetParent(transform);
                            break;
                        }
                    default:
                        {
                           
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

    public void addToFreeIndices(int index)
    {
        ListOfFreeIndexs.Add(index);
    }


   public void addWord()
    {
        if (json.isWordExhausted())
            return;
        GameObject wordCrate = Instantiate(wordObject, positionsForWords[ListOfFreeIndexs[0]], Quaternion.identity) as GameObject;
        WordScript script = wordCrate.GetComponentInChildren<WordScript>();
        string wordfirstHalf = json.getCurrentWord();
        string wordSecondHalf = json.getAccessibilityForWord();
        script.setString(wordfirstHalf);
        script.setIsOption(wordSecondHalf);
        script.setIndex(ListOfFreeIndexs[0]);
        wordsOnBoard.Add(wordfirstHalf);
        wordsOnBoard.Add(wordSecondHalf);
        ListOfFreeIndexs.RemoveAt(0);
        GameObject option = Instantiate(wordObject, positionsForWords[ListOfFreeIndexs[0]], Quaternion.identity) as GameObject;
       
        WordScript optionscript = option.GetComponentInChildren<WordScript>();
        optionscript.setString(wordSecondHalf);
        optionscript.setIsOption(wordfirstHalf);
        optionscript.setIndex(ListOfFreeIndexs[0]);
        ListOfFreeIndexs.RemoveAt(0);

    }


    public void removeWordFromBoardList(string word)
    {
        int indexToRemove = -1;
        for(int i = 0; i < wordsOnBoard.Count; i++)
        {
            if(wordsOnBoard[i] == word)
            {
                indexToRemove = i;
                break;
            }

        }
        if (indexToRemove >= 0)
            wordsOnBoard.RemoveAt(indexToRemove);

    }

    public bool isWordSecondHalfPresentOnBoard(string word)
    {
        for (int i = 0; i < wordsOnBoard.Count; i++)
        {
            if (wordsOnBoard[i] == word)
                return true;
        }
           return false;
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
            for(int i = 0;i < positionsForWords.Count;i++)
            {
                ListOfFreeIndexs.Add(i);
               
            }
            for (int i = 0; i < ListOfFreeIndexs.Count; i++)
                addWord();
         
        }
 
    }


}


