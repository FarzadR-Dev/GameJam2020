using UnityEngine.SceneManagement;
using UnityEngine; 
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{

    void OnTriggerEnter()
    {
        SceneManager.LoadScene("ForestDayLevel");
    }
    
}
