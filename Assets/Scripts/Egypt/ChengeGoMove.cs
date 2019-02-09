using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChengeGoMove : MonoBehaviour {
    protected static bool GoMove = false;
    Animator anime;
    SpriteRenderer sprite;

    // Use this for initialization
    void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {

    }
    public static bool Go
    {
        get { return GoMove; }
        set { GoMove = value; }
    }
    void Awake()
    {
        anime = GetComponent<Animator>();
        GetState = CraneState.idle;
        sprite = GetComponentInChildren<SpriteRenderer>();
    }
    void State()
    {
        GetState = CraneState.Contin;
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        Knife knife = collider.GetComponent<Knife>();
        if (knife && knife is Knife)
        {
            Go = true;
            GetState = CraneState.move;
            Destroy(knife);
        }
    }
    public CraneState GetState
    {
        get { return (CraneState)anime.GetInteger("State"); }
        set { anime.SetInteger("State", (int)value); }
    }
}
public enum CraneState
{
    idle, //0
    move, //1
    Contin //2
}
