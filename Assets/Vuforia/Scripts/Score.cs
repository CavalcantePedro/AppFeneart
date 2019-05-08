using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
	public GameObject canguaceiroInicial;
	public GameObject canguaceiroFinal;
	public GameObject tutorialCanvas;



    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
		Cont();
    }

	public void FinishReading()
	{
		if (PlayerPrefs.GetInt("Placar") < 4)
		{
			canguaceiroInicial.SetActive(false);
			tutorialCanvas.SetActive(false);
		}
	}

	    IEnumerator Win()
	{
        canguaceiroInicial.SetActive(false);
        yield return new WaitForSeconds(2.5f);
		canguaceiroFinal.SetActive(true);
		tutorialCanvas.SetActive(true);
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
				//StartCoroutine(Win());
				break;
		}
	}
}