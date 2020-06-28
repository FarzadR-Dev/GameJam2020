using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.SceneManagement;

public class BackToLevel : MonoBehaviour
{
    void OnTriggerEnter()
    {
        SceneManager.LoadScene("BackUp3");
    }
}
