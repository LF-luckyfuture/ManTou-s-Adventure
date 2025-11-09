using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playAgain : MonoBehaviour
{
    public void playAgainInGame()
    {
        SceneManager.LoadScene(1);
    }
}
