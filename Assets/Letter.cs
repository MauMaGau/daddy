using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Letter : MonoBehaviour {

    public string Character;

    protected TextMesh TextObject;
    protected List<string> Listicle = new List<string> {
        "a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z"
    };
    protected TheWord TheWord;
    protected bool IsUsed;

	// Use this for initialization
	void Start () {
        Character = Listicle[Random.Range(0, 25)].ToUpper();

        TextObject = GetComponent<TextMesh>();
        TextObject.text = Character;

        TheWord = GameObject.Find("TheWord").GetComponent<TheWord>();
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void WordCompleted()
    {
        if (IsUsed)
        {
            Character = Listicle[Random.Range(0, 25)].ToUpper();
            TextObject.text = Character;
        }

        IsUsed = false;
    }

    public void OnMouseDown()
    {
        if (IsUsed == true)
        {
            return;
        }

        IsUsed = true;

        TheWord.Word += Character;
        TheWord.InProgress = true;
    }
}
