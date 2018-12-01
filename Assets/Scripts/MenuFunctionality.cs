using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuFunctionality : MonoBehaviour {

    //On NewGameButton click
    public void NewGameButton()
    {
        SceneManager.LoadScene(2);
    }

    //On ContinueButton click
    public void ContinueButton()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("Level"));
    }

    //On LeaderBoardButton click
    public void LeaderBoardButton()
    {
       // SceneManager.LoadScene(0);
    }

    //On CreditsButton click
    public void CreditsButton()
    {
        // SceneManager.LoadScene(0);
    }

    //On LeaveButton click
    public void LeaveButton()
    {
        //Quit the game
        Application.Quit();
    }
}
