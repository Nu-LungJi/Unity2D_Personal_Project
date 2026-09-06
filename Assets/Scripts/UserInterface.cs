using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;
using System.Threading;

public class UserInterface : MonoBehaviour
{
    public GameObject Unit_SpawnUI, No_Money, TabUI;
    public GameObject[] Units;
    private int Tab_Show = 2, Random_Money;
    private bool Money_Short = false;
    private float timer;
    Rigidbody2D rigid;
    Vector3 SpawnPoint;
    public TMP_Text Money_Reward;
    public static int User_Money;
    SpriteRenderer render;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        SpawnPoint = new Vector3(-13.67f, -3.3f, -0.1f);
        User_Money = 100;
        render = No_Money.GetComponent<SpriteRenderer>();
        timer = 2;
    }

    void Update()
    {
        Tab_UI();
        Write_Down();
        Click_Event();
        if(Money_Short){UnderCost();}
    }
    void Tab_UI(){
        if(Input.GetKeyDown(KeyCode.Tab)){Tab_Show = 0;}
        if(Input.GetKeyUp(KeyCode.Tab)){Tab_Show = 1;}

        if(Tab_Show == 0){
            Unit_SpawnUI.transform.position += new Vector3(0, 24 * Time.deltaTime, 0);
            TabUI.SetActive(false);
            if(Unit_SpawnUI.transform.position.y >= -1.5f){Tab_Show = 2;}
        }
        else if(Tab_Show == 1){
            Unit_SpawnUI.transform.position += new Vector3(0, -12 * Time.deltaTime, 0);
            TabUI.SetActive(true);
            if(Unit_SpawnUI.transform.position.y <= -3.5f){Tab_Show = 2;}
        }
    }
    private void Write_Down(){
        Money_Reward.text = User_Money.ToString();
    }
    private void Click_Event(){
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

            if (hit.collider != null)
            {
                if(hit.transform.gameObject.name == "Unit01_Image"){
                    if(User_Money >= 20){
                        Instantiate(Units[0], SpawnPoint, Quaternion.identity);
                        User_Money -= 20;
                    }
                    else if(User_Money < 100){
                        Money_Short = true;
                    }
                }
                else if(hit.transform.gameObject.name == "Unit02_Image"){
                    if(User_Money >= 50){
                        Instantiate(Units[1], SpawnPoint, Quaternion.identity);
                        User_Money -= 50;
                    }
                    else if(User_Money < 100){
                        Money_Short = true;
                    }
                }
                else if(hit.transform.gameObject.name == "Unit03_Image"){
                    if(User_Money >= 100){
                        Instantiate(Units[2], SpawnPoint, Quaternion.identity);
                        User_Money -= 100;
                    }
                    else if(User_Money < 100){
                        Money_Short = true;
                    }
                }
            }
        }
    }
    private void UnderCost(){
            timer -= 2 * Time.deltaTime;
            No_Money.SetActive(true);
            render.color = new Color(1,1,1, timer);
            if(timer <= 0){ 
                No_Money.SetActive(false);
                timer = 2;
                Money_Short = false;
            }
    }
}
