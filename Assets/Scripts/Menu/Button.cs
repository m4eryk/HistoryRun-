using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour {

    void OnGUI()
    {
        Rect start = new Rect(600f, 250f, 200, 40);
        Rect exit = new Rect(600f, 650f, 200, 40);
        Rect Egypt = new Rect(600f, 350f, 200, 40);
        Rect Castel = new Rect(600f, 450f, 200, 40);
        Rect Forest = new Rect(600f, 550f, 200, 40);
        if (GUI.Button(start, "Начть"))
        {
            SceneManager.LoadScene("Egypt");
        }
        if (GUI.Button(exit, "Выход"))
        {
           Application.Quit();
        }
        if (GUI.Button(Egypt, "Уровень: Египет"))
        {
            SceneManager.LoadScene("Egypt");
        }
        if (GUI.Button(Castel, "Уровень: Осада замка"))
        {
            SceneManager.LoadScene("Castel");
        }
        if (GUI.Button(Forest, "Уровень: Скачки по лесу"))
        {
            SceneManager.LoadScene("Forest");
        }

    }
}
