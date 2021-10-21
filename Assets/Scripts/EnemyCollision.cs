using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    //awake happens all the time, before start as well as when not being referred to
    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //are we touching another enemy?

        //do nothing

        //are we touching a bullet?
        if (collision.gameObject.tag == "Bullet")
        {
            //destroy bullet THEN destroy self
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        //are we touching the player?
        else if (collision.gameObject.tag == "Player")
        {
            //destroy the player
            Destroy(collision.gameObject);
        }
        Debug.Log(collision.gameObject.name);

    }


}
