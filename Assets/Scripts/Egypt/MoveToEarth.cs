using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MoveToEarth : ChengeGoMove {

    private Vector3 direction;
    public float spead;
    
    void Start()
    {
        direction = -transform.up;
    }
    void Update()
    {
        if(ChengeGoMove.Go) Move();
        
    }
   public void Move()
    {
        Debug.Log("move");
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position - transform.up, 0.2f);
            if (colliders.Length > 0 && colliders.All(x => !x.GetComponent<Hero>()))
            {
            
                GetState = CraneState.Contin;
                Debug.Log(GetState.ToString());
                direction *= 0f;
                Go = false;
                return;
            }
        Debug.Log(colliders.Length);
            transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, spead);
        // StartCoroutine("Slow");
        
    }
    //IEnumerator Slow()
    //{
    //    yield return new WaitForSeconds(1f);
    //    Move();
    //}
}
