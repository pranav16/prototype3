using UnityEngine;
using System.Collections;
using GamepadInput;

public class PickUpPoint : MonoBehaviour {


    private string wordHalf;

	// Use this for initialization
	void Start () {
        wordHalf = "";
    }
	
	// Update is called once per frame
	void Update () {
	

	}
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player1")
        {
            Player pl = other.GetComponent<Player>();
            GamepadState state = GamePad.GetState(pl.getIndex());
            if (pl.getState() != "pickup" || !state.B)
                return;
            WordScript script = pl.getWord().GetComponentInChildren<WordScript>();
            LevelLoader loader = GameObject.FindGameObjectWithTag("Level").GetComponent<LevelLoader>();
            if ((wordHalf == "" || script.hasSecondHalf(wordHalf)) && (loader.isWordSecondHalfPresentOnBoard(script.getOption()) || script.getname() == wordHalf))
            {

                pl.setState("Idle");
                loader.removeWordFromBoardList(script.getname());
                loader.addToFreeIndices(script.getIndex());
                pl.destroyWord();
                if (wordHalf == "")
                {
                    wordHalf = script.getOption();
                }
                else
                {
                    wordHalf = "";
                    loader.addWord();
                }
            }

        }
        if (other.tag == "Player2")
        {

            Player pl = other.GetComponent<Player>();
            GamepadState state = GamePad.GetState(pl.getIndex());
            if (pl.getState() != "pickup" || !state.B)
                return;
            WordScript script = pl.getWord().GetComponentInChildren<WordScript>();
            LevelLoader loader = GameObject.FindGameObjectWithTag("Level").GetComponent<LevelLoader>();
            if ((wordHalf == "" || script.hasSecondHalf(wordHalf)) && (loader.isWordSecondHalfPresentOnBoard(script.getOption()) || script.getname() == wordHalf))
            {

                pl.setState("Idle");

                loader.removeWordFromBoardList(script.getname());
                loader.addToFreeIndices(script.getIndex());
                pl.destroyWord();

                if (wordHalf == "")
                {
                    wordHalf = script.getOption();
                }
                else
                {
                    loader.addWord();
                    wordHalf = "";
                }
            }

        }
        if (other.tag == "Player3")
        {
            Player pl = other.GetComponent<Player>();
            GamepadState state = GamePad.GetState(pl.getIndex());
            if (pl.getState() != "pickup" ||!state.B)
                return;
            WordScript script = pl.getWord().GetComponentInChildren<WordScript>();
            LevelLoader loader = GameObject.FindGameObjectWithTag("Level").GetComponent<LevelLoader>();

            if ((wordHalf == "" || script.hasSecondHalf(wordHalf)) && (loader.isWordSecondHalfPresentOnBoard(script.getOption()) || script.getname() == wordHalf))
            {

                pl.setState("Idle");

                loader.removeWordFromBoardList(script.getname());
                loader.addToFreeIndices(script.getIndex());
                pl.destroyWord();
                if (wordHalf == "")
                {

                    wordHalf = script.getOption();
                }
                else
                {
                    loader.addWord();
                    wordHalf = "";
                }


            }
        }
        if (other.tag == "Player4")
        {

            Player pl = other.GetComponent<Player>();
            GamepadState state = GamePad.GetState(pl.getIndex());
            if (pl.getState() != "pickup" || !state.B)
                return;
            WordScript script = pl.getWord().GetComponentInChildren<WordScript>();
            LevelLoader loader = GameObject.FindGameObjectWithTag("Level").GetComponent<LevelLoader>();
            if ((wordHalf == "" || script.hasSecondHalf(wordHalf)) && (loader.isWordSecondHalfPresentOnBoard(script.getOption()) || script.getname() == wordHalf))
            {

                pl.setState("Idle");
                loader.removeWordFromBoardList(script.getname());
                loader.addToFreeIndices(script.getIndex());
                pl.destroyWord();

                if (wordHalf == "")
                {
                    wordHalf = script.getOption();
                }
                else
                {
                    loader.addWord();
                    wordHalf = "";
                }
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        
       

    }

}


