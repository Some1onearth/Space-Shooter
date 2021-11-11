using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public static Shoot shoot;
    public uint guns;
    public float spread;
    public float coneSize;
    public GameObject bullet;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && guns > 0)
        {
            if (guns == 1)
            {
                Instantiate(bullet, transform.position, transform.rotation);
                return;
            }

            float position = -spread / 2f;//spreads out the range where bullets come from
            float space = spread / (guns - 1); //keeps the space between each bullet
            Quaternion rotation = Quaternion.Euler(Vector3.up * -coneSize / 2);
            float turnAmount = coneSize / (guns - 1);
            for (int i = 0; i < guns; i++)
            {
                Instantiate(bullet, transform.position + Vector3.right * position, rotation);
                rotation *= Quaternion.Euler(Vector3.up * turnAmount);//rotates the spread shot direction.
                position += space;
            }
        }
        if (GameHandler.gameHandler.currentScore < 50)
        {
            guns = 1;
        }
        if (GameHandler.gameHandler.currentScore > 50 && GameHandler.gameHandler.currentScore < 100)
        {
            guns = 3;
        }
        if (GameHandler.gameHandler.currentScore > 100 && GameHandler.gameHandler.currentScore < 200)
        {
            guns = 5;
        }
        if (GameHandler.gameHandler.currentScore > 200)
        {
            guns = 7;
        }
        //can shoot
        //if (Input.GetButtonDown("Fire1"))
        //{
        //    Debug.Log("Fire!");
        //    Instantiate(bullet1, transform.position, transform.rotation);
        //}
    }
}
