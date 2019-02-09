using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootobleMonster : MonoBehaviour {

    public Transform Hit;
    public float RadiusHit;
    Animator anime;
    void Awake()
    {
        anime = GetComponent<Animator>();
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}
    void OnTriggerEnter2D(Collider2D collider2)
    {
            GetMonsterState = State.attack;
            StartCoroutine("Attacke");

    }
    void OnTriggerExit2D(Collider2D collider)
    {
        GetMonsterState = State.idle;
    }
    public State GetMonsterState
    {
        get { return (State)anime.GetInteger("State"); }
        set { anime.SetInteger("State", (int)value); }
    }
    IEnumerator Attacke()
    {
        yield return new WaitForSeconds(1.2f);
        Attack.Action(Hit.position, RadiusHit, 9, 1, false);
    }
}public enum State
{
    idle, //1
   attack //2
}
