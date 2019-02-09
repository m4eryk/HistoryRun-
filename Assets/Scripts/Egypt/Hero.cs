using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using System.Linq;

public class Hero : Unit {
    public new AudioSource audio;
    public float Spead;
    public float lives = 100;
    public float JumpForce;
    public int Lvl;
    bool IsGround = false, IsTrap=false;
    float groundRadius = 2f;
    public bool IsRight = false, GiveDamage=false;
    Animator anim;
    new Rigidbody2D rigidbody2D;
    public SpriteRenderer sprite;
    private Knife knife;
    public Transform RHit,LHit;
    public float RadiusHit=0.5f;
    public bool GiveTNT { get; set; }
    bool Horse { get; set; }
    public Text text;
    // Use this for initialization
    void Awake() {
        Horse = false;
        rigidbody2D = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        knife = Resources.Load<Knife>("Knife");
        if (Lvl == 3) Horse = true;
        if (text && !Horse) text.text = lives.ToString("0");
        if (audio) audio.Play();

    }
    public bool Giveammo { get; set; }
    // Update is called once per frame
    void Update() {
     
        if (!Horse)
        {
            if(text) text.text = lives.ToString("0");
            if (IsGround && lives > 0 && !Giveammo) State = HeroState.Idle_1;
            if (IsGround && Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
            {
                Jump();
            }
            if (Input.GetButton("Horizontal") && !Giveammo)
            {
                Run();
            }
            if (Input.GetButtonDown("Fire2")) Shoot();
            if (Input.GetButtonDown("Fire1") && IsRight) { Attack.Action(RHit.position, RadiusHit, 9, 50, false); State = HeroState.Attack_1; }
            else if (Input.GetButtonDown("Fire1") && !IsRight) { Attack.Action(LHit.position, RadiusHit, 9, 50, false); State = HeroState.Attack_1; }
            if (transform.position.y < -10) StartCoroutine("IsDead");
            if (GiveDamage) StartCoroutine("GiveDmg");
            if (Giveammo && Input.GetButton("Horizontal")) GiveItemsRun();
            if (Giveammo && !(Input.GetButton("Horizontal"))) State = HeroState.giveammoidle;
            if (GiveTNT && Input.GetButton("Horizontal")) GiveItemsTNTRun();
            if (GiveTNT && !(Input.GetButton("Horizontal"))) State = HeroState.givetnt;
            
        }
        else
        {
            if (transform.position.y <-10) { text.text = "НЕУДАЧА"; StartCoroutine("Dead"); };
            RunHourse();
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
            {
                JumpForce = 20f;

                if(IsGround) JumpHourse();
            }
            if (Wood.Die) { text.text = "НЕУДАЧА"; StartCoroutine("Dead"); }
        }
        if (Input.GetKeyDown(KeyCode.Escape)) SceneManager.LoadScene("MainMenu");
    }
    IEnumerator Dead() {
        yield return new WaitForSeconds(2f);
        text.text = " ";
        Wood.Die = false;
        SceneManager.LoadScene("Forest");
    }


    void FixedUpdate()
    {
        IsGroundPos();
    }
    void GiveItemsRun()
    {
        Vector3 direction = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, Spead * Time.deltaTime);
        if (direction.x < 0.0F) { sprite.flipX = true; IsRight = false; }
        else { sprite.flipX = false; IsRight = true; }
        if (IsGround) State = HeroState.giveammorun;
    }
    void Run()
    {
        Spead = 5;
        Vector3 direction = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, Spead * Time.deltaTime);
        if (direction.x < 0.0F) { sprite.flipX = true; IsRight = false;}
        else { sprite.flipX = false; IsRight = true; }
        State = HeroState.Run;
    }
    void RunHourse()
    {
        Spead = 5;
        Vector3 direction = transform.right * 3f;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, Spead * Time.deltaTime);
        if (direction.x < 0.0F) { sprite.flipX = true; IsRight = false; }
        else { sprite.flipX = false; IsRight = true; }
        if (IsGround) State = HeroState.hourse;
    }
    void GiveItemsTNTRun()
    {
        Vector3 direction = transform.right * Input.GetAxis("Horizontal");
        Spead = 2;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, Spead * Time.deltaTime);
        if (direction.x < 0.0F) { sprite.flipX = true; IsRight = false; }
        else { sprite.flipX = false; IsRight = true; }
        if (IsGround) State = HeroState.givetntrun;
    }

    void Jump()
    {
        State = HeroState.Jump;
        rigidbody2D.AddForce(transform.up * JumpForce, ForceMode2D.Impulse);
    } void JumpHourse()
    {
        rigidbody2D.AddForce(transform.up * JumpForce, ForceMode2D.Impulse);
    }
    void Shoot()
    {
        Vector3 postion = transform.position;
        postion.x += (sprite.flipX ? -0.6f : 0.6f);
        Knife newknife = Instantiate(knife, postion, knife.transform.rotation) as Knife;
        newknife.Parent = gameObject;
        newknife.Direction = newknife.transform.right * (sprite.flipX ? -1.0f : 1.0f);
    }
    void IsGroundPos()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, groundRadius);
        foreach (Collider2D col in collider)
        IsGround = collider.Length > 1;
        if (!IsGround && !IsTrap && !Horse) State = HeroState.Jump;

    }
    public HeroState State
    {
        get { return (HeroState)anim.GetInteger("State"); }
        set { anim.SetInteger("State",(int)value); }
    }
    public void OnTriggerEnter2D(Collider2D collider)
    {
        Unit unit = collider.GetComponent<Unit>();
        if (unit)
        {
            ReceiveDamage();
            sprite.color = Color.red;
            GiveDamage = true;
        }
    }
   

    public override void ReceiveDamage()
    {
        lives--;
        Debug.Log(lives);
        rigidbody2D.velocity = Vector3.zero;
        rigidbody2D.AddForce(transform.up  * 1.4f, ForceMode2D.Impulse);
        sprite.color=Color.red;
        if (lives < 0) {State = HeroState.Die; StartCoroutine("IsDead");}
    }
    IEnumerator IsDead()
    {
        yield return new WaitForSeconds(1.6f);
        SceneManager.LoadScene("Egypt");
    }
    IEnumerator GiveDmg()
    {
        yield return new WaitForSeconds(1.3f);
        sprite.color = Color.white;
        GiveDamage = false;
    }
}
public enum HeroState
    {
        Idle_1, //0
        Run,    //1
        Jump,   //2
        Trap,   //3
        Attack_1,   //4
        Die, //5
        giveammorun, //6
        giveammoidle, //7
        givetnt, //8
        givetntrun, //9
        hourse //10
}