using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour {


    private float speed = 5.0f;
    private Transform target;
    public Transform anmitarget;
    public int Lvl;
    private void Awake()
    {
        target = FindObjectOfType<Hero>().transform;
       

    }
    private void Update()
    {
        
        Vector3 position = target.position;

        if(!(position.x<-0.3)&& !(position.x>44f) && Lvl ==1)
        {
            position.z = -10.0f;
            position.y = -1f;
            transform.position = Vector3.Lerp(transform.position, position, speed * Time.deltaTime);
        }
        if (Lvl == 2)
        {
            if (!(position.x < 0f))
            {
                position.z = -10.0f;
                position.y = 0.5f;
                transform.position = Vector3.Lerp(transform.position, position, speed * Time.deltaTime);
            }
            if (anmitarget)
            {
                Vector3 positionwaror = anmitarget.position;
                if (!(positionwaror.x < 0f))
                {
                    positionwaror.y = 0.5f;
                    positionwaror.z = -10f;
                    transform.position = Vector3.Lerp(transform.position, positionwaror, speed * Time.deltaTime);
                }
            }
        }
        if (Lvl == 3)
        {
            if (!(position.x < 0.5f) && !(position.x > 105f))
            {
               
                position.z = -11.0f;
                position.y = 0f;
                transform.position = Vector3.Lerp(transform.position, position, speed * Time.deltaTime);
                
            }
        }
    }
}
