using System;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class MonitorControl : MonoBehaviour
{
    public VideoPlayer vid;
    public GameObject cam1;
    public GameObject cam2;
    public GameObject enter;
    private int myInt = 0;

    [SerializeField]
    

    public void TextChange()
    {
        TextMesh textObject = GameObject.Find("Message").GetComponent<TextMesh>();
        textObject.text = "Welcome to the " + "\n" + "game";
        textObject.fontSize = 130;
        textObject.color = Color.red;
    }

    public void TextChange1()
    {
        TextMesh textObject = GameObject.Find("Message").GetComponent<TextMesh>();
        textObject.text = "This game uses " + "\n" + "first person camera" + "\n" + " WASD movement";
    }

    public void TextChange2()
    {
        TextMesh textObject = GameObject.Find("Message").GetComponent<TextMesh>();
        textObject.text = "Get Ready";
    }

    
    public void TextChange3()
    {
        TextMesh textObject = GameObject.Find("Message").GetComponent<TextMesh>();
        Destroy(GameObject.Find("Message"));
        Destroy(GameObject.Find("New Text"));
    }


    private void Start()
    {
        cam1.SetActive(true);
        cam2.SetActive(false);
        enter.SetActive(false);
    }

    // Update is called once per frame
    void LateUpdate() 
    {
        if (myInt == 0)
        {
            if (Input.GetMouseButtonUp(0))
            {
                TextChange();
                myInt += 1;
            }
        }
        else if (myInt == 1)
        {
            if (Input.GetMouseButtonUp(0))
            {
                TextChange1();
                myInt += 1;
            }
        }
        else if (myInt == 2)
        { 
            if (Input.GetMouseButtonUp(0))
            {
                TextChange2();
                myInt += 1;
            }
        }
        
        else if (myInt == 3)
        {
            if (Input.GetMouseButtonUp(0))
            {
                TextChange3();
                cam1.SetActive(false);
                cam2.SetActive(true);
                enter.SetActive(true);
                myInt += 1;
                vid.Play();
            }
        }
        else if (myInt == 4)
        {
            if (Input.GetKeyUp(KeyCode.Return))
            {
                SceneManager.LoadScene("BackUp3");
            }
        }
      
        
    
        

    }
    
}
