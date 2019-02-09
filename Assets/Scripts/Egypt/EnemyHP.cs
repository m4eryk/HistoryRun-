using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHP : MonoBehaviour
{
    public float HP = 100;
    Hero myGemaOj;
    void Awake()
    {
    }
    void Update()
    {
        Die();
    }
    void Die()
    {
        if (HP < 0) StartCoroutine("Dead");

    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        Hero hero = collider.GetComponent<Hero>();
        Knife knife = collider.GetComponent<Knife>();
        if (knife && knife is Knife)
        {
            HP -= 50;
        }
    }
    IEnumerator Dead()
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }
}
