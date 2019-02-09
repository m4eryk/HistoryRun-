using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Trap : Unit {
    public float HP = 100;
    private Vector3 direction;
    public float spead;
    void Start()
    {
        direction = -transform.up;
    }
    void Update()
    {
    }
    public void OnTriggerEnter2D(Collider2D collider)
    {
        Unit unit = collider.GetComponent<Unit>();
       
            if (unit && unit is Hero)
            {
                Hero hero = collider.GetComponent<Hero>();
                hero.State =(HeroState)5;
                hero.StartCoroutine("IsDead");
            }

    }
}
