using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private float delay;
    [SerializeField] private Animator anim;
    private string sceneName;
    private bool canBackHome;
    // Start is called before the first frame update
    void Start()
    {
        canBackHome = false;
        
        if(SceneManager.GetActiveScene().name == "Splash")
        {
            
            StartCoroutine("Splash");
        }

        else if(SceneManager.GetActiveScene().name != "Home")
        {
            canBackHome = true;
        }

        else
        {
            delay = 0.5f;
        }
    }

    void Update()
    {
        if(canBackHome)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                sceneName =  "Home";
                StartCoroutine(Transition());
            }
            
        }

        else 
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                Singleton.GetInstance.pinManager.ClosePinInfo();
            }
        }
    }

   public void ChangeScene(string name)
   {
       sceneName = name;
       StartCoroutine("Transition");
   }

   IEnumerator Transition()
   {
       anim.SetTrigger("changingScene");
       yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);   

   }

   IEnumerator Splash()
   {
       yield return new WaitForSeconds(2f);
       anim.SetTrigger("changingScene");
       yield return new WaitForSeconds(delay);
       SceneManager.LoadScene("Home");   

   }

}
