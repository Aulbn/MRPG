using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    public static void PauseGame()
    {
        Time.timeScale = 0;
    }

    public static void UnpauseGame()
    {
        Time.timeScale = 1;
    }


}
