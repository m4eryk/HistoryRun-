using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class Warior : MonoBehaviour {
    Vector3 direction;
    float spead = 4f;
    public SpriteRenderer sprite_1,sprite_2;
    bool goHero = false, text = false;
    public SpriteRenderer sprite;
    public Animator animator_1,animator_2;
	// Use this for initialization
	void Start () {
        direction = transform.right;
        State_2 = AllyState.move;
        State = AllyState.move;
    }
	
	// Update is called once per frame
	void Update () {

        if (!CheckDoor.OpenDoor) Move();
        else MoveDoor();
        
	}
    public AllyState State
    {
        get { return  (AllyState)animator_1.GetInteger("State");}
        set { animator_1.SetInteger("State", (int)value); }
    }
    public AllyState State_2
    {
        get { return (AllyState)animator_2.GetInteger("State"); }
        set { animator_2.SetInteger("State", (int)value); }
    }
    
    void Move()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + transform.up * 0.5f + transform.right * -direction.x * 0.5f, 0.7f);
        if (goHero)
        {
            direction *=-1f;
            goHero = false;
            State_2 = AllyState.move;
            State = AllyState.move;
        }
        if (colliders.Length > 0 && colliders.All(x => x.GetComponent<Hero>()))
        {
            direction *= 0f;
            text = true;
            Gun.Active = true;
            State = AllyState.idle;
            State_2 = AllyState.idle;

        }
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, spead * Time.deltaTime);
        sprite_1.flipX = direction.x > 0;
        sprite_2.flipX = direction.x > 0;
        if (text) sprite.enabled = text;

    }
    void MoveDoor()
    {
        direction = transform.right;
        State_2 = AllyState.move;
        State = AllyState.move;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, spead * Time.deltaTime);
        sprite_1.flipX = direction.x > 0;
        sprite_2.flipX = direction.x > 0;
        sprite.enabled = false;
        StartCoroutine("Go3Lvl");

    }
    void OnTriggerEnter2D(Collider2D collider)
    {   
        Hero hero = collider.GetComponent<Hero>();
        if (hero && hero is Hero) { goHero = false; }
        else goHero = true; 
    }
    public enum AllyState
    {
        idle, //0
        move  //1 
    }
    
    IEnumerator Go3Lvl()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Forest");
    }
}
