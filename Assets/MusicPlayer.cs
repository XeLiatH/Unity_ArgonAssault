using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    void Start()
    {
        Invoke("LoadNextScene", 5.0f);
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(1);
    }
}
