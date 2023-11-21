using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string nombreEscena;
    public void LoadScene(string nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena);
    }

    public void Exit()
    {

        Application.Quit();
        Debug.Log("salir");
    }
}
