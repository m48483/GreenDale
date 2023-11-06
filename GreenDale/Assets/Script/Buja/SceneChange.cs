using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    // Start is called before the first frame update
    public void newGame()
    {
        SceneManager.LoadScene("NewCharacter");
    }

    public void continueGame()
    {
        SceneManager.LoadScene("FarmScene");
    }
}
