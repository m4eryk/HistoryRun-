using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {
    protected bool GoMove;
    public virtual void ReceiveDamage()
    {
       
    }
    public virtual void Die()
    {
        Destroy(gameObject);
    }
}
