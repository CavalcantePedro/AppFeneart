using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GotTarget : MonoBehaviour
{
    private MeshRenderer mesh;
    [SerializeField]private string playerPrefsForThisTarget;
    private int contador;
   
    // Start is called before the first frame update
    void Start()
    {   
        //ResetDebug();
        contador = PlayerPrefs.GetInt("Placar",0);
        mesh = gameObject.GetComponent<MeshRenderer>();
        StartCoroutine("CheckingTarget");
    }

    // Update is called once per frame
    IEnumerator CheckingTarget()
    {
        for(;;)
        {
            contador = PlayerPrefs.GetInt("Placar");
            if(mesh.enabled)
            {
            
                if(PlayerPrefs.GetInt(playerPrefsForThisTarget) == 0)
                {
                contador++;
                PlayerPrefs.SetInt(playerPrefsForThisTarget,1);
                PlayerPrefs.SetInt("Placar", contador);
                }

                else
                {
                    print("já pego irmao");
                }

            }
        yield return new WaitForSeconds(0.5f);
        }
    }

    void ResetDebug()
    {
         PlayerPrefs.SetInt("Canga" , 0);
        PlayerPrefs.SetInt("Canga2" , 0);
        PlayerPrefs.SetInt("Cantil" , 0);
        PlayerPrefs.SetInt("Bolsa" , 0);
        PlayerPrefs.SetInt("Placar" , 0);
    }
}
