using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    public GameObject char1;
    public GameObject char2;
    public GameObject char3;
    public GameObject char4;

    public Button right;
    public Button left;
    public Button play;

    int charNum = 0;

    void Start()
    {
        charNum = 1;
    }

    public void isPlayBtnOnClick()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void isRightBtnOnClick()
    {
        charNum++;
        if (charNum > 4)
            charNum = 1;
        setCharacter(charNum);
    }
    public void isLeftBtnOnClick()
    {
        charNum--;
        if (charNum < 1)
            charNum = 4;
        setCharacter(charNum);
    }

    private void setCharacter(int num)
    {
        if (num == 1)
        {
            char1.SetActive(true);
            char2.SetActive(false);
            char3.SetActive(false);
            char4.SetActive(false);
        }
        else if (num == 2)
        {
            char1.SetActive(false);
            char2.SetActive(true);
            char3.SetActive(false);
            char4.SetActive(false);
        }
        else if (num == 3)
        {
            char1.SetActive(false);
            char2.SetActive(false);
            char3.SetActive(true);
            char4.SetActive(false);
        }
        else if (num == 4)
        {
            char1.SetActive(false);
            char2.SetActive(false);
            char3.SetActive(false);
            char4.SetActive(true);
        }
    }
}
