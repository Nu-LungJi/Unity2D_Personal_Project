using UnityEngine;
using UnityEngine.SceneManagement;
public class GameState : MonoBehaviour
{
    private SpriteRenderer EndScreen_RD, Settingrender01, Settingrender02, Settingrender03;
    private SpriteRenderer VictoryScreen_RD, VictoryUIrender, VictoryMarkrender;
    public GameObject EndScreen, Particle01, Particle02, LoGo01, Set01, Set02, Set03;
    public GameObject VictoryScreen, VictoryUI, VictoryMark;
    public GameObject[] Monsters, Units;
    private float timer;
    public static bool Game_Fail = false, Game_Victory = false;
    void Start()
    {
        EndScreen_RD = EndScreen.GetComponent<SpriteRenderer>();
        VictoryScreen_RD = VictoryScreen.GetComponent<SpriteRenderer>();

        Settingrender01 = Set01.GetComponent<SpriteRenderer>();
        Settingrender02 = Set02.GetComponent<SpriteRenderer>();
        Settingrender03 = Set03.GetComponent<SpriteRenderer>();

        VictoryUIrender = VictoryUI.GetComponent<SpriteRenderer>();
        VictoryMarkrender = VictoryMark.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        GameEnd();
        GameStart();
    }
    void GameEnd(){
        if(Game_Fail){
            timer += Time.deltaTime;
            GameOver();
        }
        if(Game_Victory){
            timer += Time.deltaTime;
            GameVictory();
        }
    }
    void GameOver(){
        Destroy(Particle01);
        Destroy(Particle02);
        EndScreen.SetActive(true);
        EndScreen_RD.color = new Color(0,0,0, timer / 3);

        Set01.SetActive(true);
        Set02.SetActive(true);
        Set03.SetActive(true);

        if(timer > 2){
            Settingrender01.color = new Color(1,1,1, timer - 2);
            Settingrender02.color = new Color(1,1,1, timer - 2);
            Settingrender03.color = new Color(1,1,1, timer - 2);
            if(timer > 3){timer = 3;}
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

            if (hit.collider != null){
                if(hit.transform.gameObject.name == "RE"){
                    if(SceneManager.GetActiveScene().name == "Game"){SceneManager.LoadScene(SceneManager.GetActiveScene().name);}
                    if(SceneManager.GetActiveScene().name == "Game01"){SceneManager.LoadScene("Game");}
                    if(SceneManager.GetActiveScene().name == "Game02"){SceneManager.LoadScene("Game");}
                    if(SceneManager.GetActiveScene().name == "Game03"){SceneManager.LoadScene("Game");}
                    if(SceneManager.GetActiveScene().name == "Game04"){SceneManager.LoadScene("Game");}
                } 
                if(hit.transform.gameObject.name == "Exit"){
                    UnityEditor.EditorApplication.isPlaying = false;
                    Application.Quit();
                }    
            }
        }
    }
    void GameStart(){
         if (Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

            if (hit.collider != null){
                if(hit.transform.gameObject.name == "StartBTN"){
                    SceneManager.LoadScene("Tutorial");
                } 
                if(hit.transform.gameObject.name == "ExitBTN"){
                    UnityEditor.EditorApplication.isPlaying = false;
                    Application.Quit();
                }    
            }
        }
    }
    void GameVictory(){
        Destroy(Particle01);
        Destroy(Particle02);
        VictoryScreen.SetActive(true);
        if(timer <= 2){
            VictoryScreen_RD.color = new Color(0,0,0, timer / 3);
        }

        if(timer > 2){
            VictoryUI.SetActive(true);
            VictoryMark.SetActive(true);

            VictoryMarkrender.color = new Color(1,1,1, timer - 2);
            VictoryUIrender.color = new Color(1,1,1, timer - 2);
            if(timer > 3){timer = 3;}
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

            if (hit.collider != null){
                if(hit.transform.gameObject.name == "Main"){
                    GameStart();
                    SceneManager.LoadScene("GameStart");
                } 
                if(hit.transform.gameObject.name == "Next"){
                    if(SceneManager.GetActiveScene().name == "Game"){SceneManager.LoadScene("Game01");Game_Victory = false;}
                    if(SceneManager.GetActiveScene().name == "Game01"){SceneManager.LoadScene("Game02");Game_Victory = false;}
                    if(SceneManager.GetActiveScene().name == "Game02"){SceneManager.LoadScene("Game03");Game_Victory = false;}
                    if(SceneManager.GetActiveScene().name == "Game03"){SceneManager.LoadScene("Game04");Game_Victory = false;}
                    if(SceneManager.GetActiveScene().name == "Game04"){SceneManager.LoadScene("GameStart");Game_Victory = false;}
                }    
            }
        }
    }
}
