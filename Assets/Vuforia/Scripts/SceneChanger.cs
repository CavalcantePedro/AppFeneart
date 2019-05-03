using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private float delay;
    [SerializeField] private Animator anim;
    private string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "Splash")
        {
            StartCoroutine("Splash");
        }

        else
        {
            delay = 0.5f;
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
