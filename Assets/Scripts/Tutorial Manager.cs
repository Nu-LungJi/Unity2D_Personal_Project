using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    public GameObject T1, T2, T3;
    int index = 0;
    void Start()
    {
        
    }

    void Update()
    {
        Next();
        if(index == 0){
            T1.SetActive(true);
            T2.SetActive(false);
            T3.SetActive(false);
        }
        if(index == 1){
            T1.SetActive(false);
            T2.SetActive(true);
            T3.SetActive(false);
        }
        if(index == 2){
            T1.SetActive(false);
            T2.SetActive(false);
            T3.SetActive(true);
        }
        if(index == 3){
            SceneManager.LoadScene("Game");
        }
    }
    void Next(){
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

            if (hit.collider != null)
            {
                if(hit.transform.gameObject.name == "Next"){
                    index += 1;
                }
            }
        }
        
    }
}
