using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TheWord : MonoBehaviour {

    public TheDictionary TheDictionary = new TheDictionary();
    public string Word;
    public bool InProgress;
    protected Text Text;
    protected Text WordsMadeObject;
    protected Text Score;
    protected List<string> WordsMade = new List<string>();

	// Use this for initialization
	void Start () {
        Text = GetComponent<Text>();
        WordsMadeObject = GameObject.Find("WordsMade").GetComponent<Text>();
        Score = GameObject.Find("Score").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        Text.text = Word;
	}

    public void Complete()
    {
        if (TheDictionary.IsWord(Word))
        {
            WordsMade.Add(Word);

            WordsMadeObject.text += "\n " + Word;

            Score.text = (int.Parse(Score.text) + TheDictionary.WordScore(Word)).ToString();
        }

        InProgress = false;

        Word = "";

        ResetLetters();
    }

    protected void ResetLetters()
    {
        GameObject[] letters = GameObject.FindGameObjectsWithTag("Letter");

        for (int i = 0; i < letters.Length; i++)
        {
            letters[i].GetComponent<Letter>().WordCompleted();
        }
    }
}
