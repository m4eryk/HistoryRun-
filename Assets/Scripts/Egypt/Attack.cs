using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

    static GameObject NearTarget(Vector3 postion, Collider2D[] array)
    {
        Collider2D current = null; //текущий колойдер занулил. проверить не входит ли в входной массив
        float dist = Mathf.Infinity;
        foreach (Collider2D collider in array)
        {
            float curdist = Vector3.Distance(postion, collider.transform.position);

            if (curdist < dist)
            {
                current = collider;
                dist = curdist;
            }
        }
        return (current != null) ? current.gameObject : null;
    }
    public static void Action(Vector2  point, float radius, int LeyerMask, float damage, bool allTargets)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(point, radius, 1 << LeyerMask);

        if (!allTargets)
        {
            GameObject obj = NearTarget(point, colliders);
            if (obj != null && obj.GetComponent<EnemyHP>() && !obj.GetComponent<Hero>())
            {
                obj.GetComponent<EnemyHP>().HP -= damage;
            }
            if(obj && obj.GetComponent<Hero>())
            {
                obj.GetComponent<Hero>().lives -= damage;
                obj.GetComponent<Hero>().GiveDamage = true;
                obj.GetComponent<Hero>().sprite.color = Color.red;
            }
            return;
        }

        foreach (Collider2D hit in colliders)
        {
            if (hit.GetComponent<EnemyHP>())
            {
                hit.GetComponent<EnemyHP>().HP -= damage;
            }
        }

    }
}
