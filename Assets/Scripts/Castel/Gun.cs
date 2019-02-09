using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Collider2D trigger;
    public SpriteRenderer sprite;
    Animator anime;
    CheckDoor opendoor;
    public static int fullPornHub;
    public static bool Active { get; set; }
    public static bool GoActive { get; set; }
    public static int FullPornHub { get { return fullPornHub; } set { fullPornHub = value; } }
    void Start()
    {
        anime = GetComponent<Animator>();
        opendoor = GetComponent<CheckDoor>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Active) trigger.enabled = true;
        if (FullPornHub == 2) {
            StartCoroutine("Shoot");
            StartCoroutine("CD"); }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        sprite.enabled = true;
    }
    void OnTriggerStay2D(Collider2D collider)
    {
        Unit unit = collider.GetComponent<Hero>();
        if (unit && unit is Hero && Input.GetKeyDown(KeyCode.E))
        {
            if (unit.GetComponent<Hero>().Giveammo) FullPornHub += 1;
            if (unit.GetComponent<Hero>().GiveTNT) FullPornHub += 1;
            unit.GetComponent<Hero>().Giveammo = false;
            unit.GetComponent<Hero>().GiveTNT = false;
            GoActive = true;
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        sprite.enabled = false;
    }
    public GunState gunState
    {
        get { return (GunState)anime.GetInteger("State"); }
        set { anime.SetInteger("State", (int)value); }
    }
    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(1f);
        gunState = GunState.shoot;
        FullPornHub = 0;
    }
    IEnumerator CD()
    {
        yield return new WaitForSeconds(2.7f);
        FullPornHub = 0;
        gunState = GunState.idle;
    }
}
public enum GunState
{
    idle, //0
    shoot //1
}
