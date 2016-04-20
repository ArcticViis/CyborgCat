using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using System.Collections;
using System;

public class MainMenu : MonoBehaviour {

    public Button promptYes;
    public Button play;

    // Use this for initialization
    void Start () {


        promptYes.onClick.AddListener(delegate () { Quit(); });

        play.onClick.AddListener(delegate () { Play(); });
    }

    private void Play()
    {
        SceneManager.LoadScene("blah");
    }

    private void Quit()
    {
        Application.Quit();
    }
}
