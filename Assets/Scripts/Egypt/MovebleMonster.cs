using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MovebleMonster : MonsterOrObject {
    private float spead = 2f;
    private Knife knife;
    private SpriteRenderer sprite;
    private Vector3 direction;
    Animator anim;
    protected override void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        knife = Resources.Load<Knife>("Knife");
        anim = GetComponent<Animator>();
    }
    protected override void Start()
    {
        direction = transform.right;
    }
    protected override void Update()
    {
        Move();
    }
    void Move()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + transform.up * 0.5f + transform.right * direction.x * 0.6f, 0.1f);
        if (colliders.Length > 0 && colliders.All(x => !x.GetComponent<Hero>()))
        {
            direction *=-1f;
        }
        sprite.flipX = direction.x < 0;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, spead * Time.deltaTime);
        GetMonsterState = MonsterState.Move;
    }
    public MonsterState GetMonsterState
    {
        get { return (MonsterState)anim.GetInteger("State"); }
        set { anim.SetInteger("State", (int)value); }
    }
}
public enum MonsterState
{
    Move, //0
    die,  //1
    idle  //2
}
