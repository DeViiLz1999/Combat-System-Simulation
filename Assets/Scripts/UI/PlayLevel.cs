using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayLevel : MonoBehaviour
{
    public GameManager gameManager;

    public void RestartGame()
    {
        gameManager.RestartGame();
    }
}
