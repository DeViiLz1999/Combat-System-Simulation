using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitLevel : MonoBehaviour
{
    public GameManager gameManager;

    public void QuitGame()
    {
        gameManager.QuitGame();
    }
}
