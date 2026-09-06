using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public GameObject VictoryScreen, VictoryUI, VictoryMark;
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "Game"){GameState.Game_Victory = false;GameState.Game_Fail = false;}
        if(SceneManager.GetActiveScene().name == "Game01"){GameState.Game_Victory = false;GameState.Game_Fail = false;}
        if(SceneManager.GetActiveScene().name == "Game02"){GameState.Game_Victory = false;GameState.Game_Fail = false;}
        if(SceneManager.GetActiveScene().name == "Game03"){GameState.Game_Victory = false;GameState.Game_Fail = false;}
        if(SceneManager.GetActiveScene().name == "Game04"){GameState.Game_Victory = false;GameState.Game_Fail = false;}
    }
}
