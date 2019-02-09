using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterOrObject : Unit
{  protected virtual void Awake() { }
   protected virtual void Start() { }
   protected virtual  void Update() { }
   protected virtual void OnTriggerEnter2D(Collider2D collider)
    {
        Knife knife = collider.GetComponent<Knife>();
        if (knife && knife is Knife)
        {
            Destroy(gameObject);
        }

    }
}
