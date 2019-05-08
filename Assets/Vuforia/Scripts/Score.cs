using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
	public GameObject canguaceiroInicial;

	public GameObject canguaceiroFinal;
	public GameObject tutorialObject;

    [TextArea(1,3)]
    [SerializeField]private string tutorialSpeech;

    [TextArea(1,3)]
    [SerializeField]private string winSpeech;

    [SerializeField] private Text speechTxt;

    private bool winAlrealdyRun;


    void Start()
    {   
        winAlrealdyRun = false;
        
        if(PlayerPrefs.GetInt("Placar") < 4)
        {
            canguaceiroInicial.SetActive(true);
            StartCoroutine(LetterByLeter(tutorialSpeech));
        }
    }

    // Update is called once per frame
    void Update()
    {
		Cont();
    }

	public void FinishReading()
	{
        print("fechei");
		if (PlayerPrefs.GetInt("Placar") < 4)
		{
			canguaceiroInicial.SetActive(false);
			tutorialObject.SetActive(false);
            
		}
	}

	    IEnumerator Win()
	{
        canguaceiroInicial.SetActive(false);
        yield return new WaitForSeconds(2.5f);
		canguaceiroFinal.SetActive(true);
		tutorialObject.SetActive(true);
        StartCoroutine(LetterByLeter(winSpeech));
	}

     IEnumerator LetterByLeter(string sentence)
    {
        print("aq ó");
        speechTxt.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            if(letter == '#')
            {
                yield return new WaitForSeconds(1f);
            }
            else
            {
            speechTxt.text += letter;
            }
            yield return null;
        }

    }

	public void Cont()
	{
		switch (PlayerPrefs.GetInt("Placar"))
		{
			case 1:
				Singleton.GetInstance.placar.text = "1/4";
				break;

			case 2:
				Singleton.GetInstance.placar.text = "2/4";
				break;

			case 3:
				Singleton.GetInstance.placar.text = "3/4";
				break;

			case 4:
				Singleton.GetInstance.placar.text = "4/4";
                if(!winAlrealdyRun)
                {
				StartCoroutine(Win());
                winAlrealdyRun = true;
                }
				break;
		}
	}
}