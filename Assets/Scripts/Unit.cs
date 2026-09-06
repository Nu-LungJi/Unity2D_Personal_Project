using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{
    private Animator animator;
    private bool Is_Alive = true;
    public GameObject ATTRange;
    public float Max_HP, HP, timer;
    public Image HP_Image;
    private float Speed = 10;
    public GameObject other;
    Rigidbody2D rb;
    public LayerMask EnemyLayer;
    float FindRange = 1.5f;
    CapsuleCollider2D CCD;

    public GameObject[] Body;
    SpriteRenderer render01, render02, render03, render04, render05, render06;
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        CCD = GetComponent<CapsuleCollider2D>();

        render01 = Body[0].GetComponent<SpriteRenderer>();
        render02 = Body[1].GetComponent<SpriteRenderer>();
        render03 = Body[2].GetComponent<SpriteRenderer>();
        render04 = Body[3].GetComponent<SpriteRenderer>();
        render05 = Body[4].GetComponent<SpriteRenderer>();
        render06 = Body[5].GetComponent<SpriteRenderer>();

        timer = 0;
    }

    void Update()
    {
        Movement();
        Sensoring();
        if(HP_Image.rectTransform.sizeDelta.x <= 0){
            timer += Time.deltaTime;
            Die();
            CCD.enabled = false;
            if(timer <= 1){
                render01.color = new Color(1, 1, 1, 1-timer);
                render02.color = new Color(1, 1, 1, 1-timer);
                render03.color = new Color(1, 1, 1, 1-timer);
                render04.color = new Color(1, 1, 1, 1-timer);
                render05.color = new Color(1, 1, 1, 1-timer);
                render06.color = new Color(1, 1, 1, 1-timer);
            }
            if(timer > 1){
                Destroy(gameObject);
                timer = 0;
            }
        }
        Victory();
    }
    void Movement(){
        if(Is_Alive){
            transform.Translate(Vector2.right * Speed * Time.deltaTime);
        }if(GameState.Game_Fail == true){Speed = 0;}
    }
    void Die(){
        if( HP_Image.rectTransform.sizeDelta.x <= 0.0001f){
            Is_Alive = false;
            animator.SetBool("Death", true);    
        }
    }
    void Damaged(float Damage_Value){
            HP -= Damage_Value;

            HP_Image.rectTransform.anchoredPosition = new Vector2( - (1 - HP / Max_HP) / 2, 0);
            HP_Image.rectTransform.sizeDelta = new Vector2( HP / Max_HP , 0.2f);
    }
    void Victory(){
        if(gameObject.transform.position.x >= 13.5f){
            GameState.Game_Victory = true;
            Speed = 0;
        }
    }
    private void Sensoring(){
        var EnemyObj = Physics2D.OverlapCircle(transform.position, FindRange, EnemyLayer);
        if(EnemyObj != null){
            Speed = 0;
            animator.SetBool("Attack", true);
            if(animator.GetCurrentAnimatorStateInfo(0).IsName("attack") == true){
                float animTime = animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
                if((animTime - (int)animTime) > 0.5f && (animTime - (int)animTime) < 0.8f){
                    ATTRange.SetActive(true);
                }else{
                    ATTRange.SetActive(false);
                }
            }
        }
        if(EnemyObj == null){
            Speed = 2;
            animator.SetBool("Attack", false);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Monster01AR"){
            Damaged(10);
        }if(other.gameObject.name == "Monster02AR"){
            Damaged(15);
        }if(other.gameObject.name == "Monster03AR"){
            Damaged(20);
        }

    }
}
