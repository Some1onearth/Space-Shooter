using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public AudioSource _as;
    public AudioClip[] audioClipArray;
    void Awake()
    {
        _as = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //movement forwards backwards left and right
        //temporary storage to calculate movement vector
        Vector3 movement;
        //assigns the x axis of the movement vector to match the players' hoizontal input
        movement.x = Input.GetAxisRaw("Horizontal");
        //leave y axis alone as we don't want to be move up and down
        movement.y = 0;
        //assigns the z axis of the movement vector to match the player's vertical input
        movement.z = Input.GetAxisRaw("Vertical");
        //make vector framemate independant
        movement *= Time.deltaTime;
        //apply speed multiplayer
        movement *= speed;

        transform.Translate(movement);

            //can shoot
            if (Input.GetButtonDown("Fire1"))
            {
                _as.clip = audioClipArray[Random.Range(0, audioClipArray.Length)];
                _as.PlayOneShot(_as.clip);
            }
            //can get killed by enemy

        //Clamp players' position to read inside the field
        Vector3 clampPos = transform.position;
        clampPos.x = Mathf.Clamp(clampPos.x, -10, 10);
        clampPos.z = Mathf.Clamp(clampPos.z, -5, 5);
        clampPos.y = 0;

        transform.position = clampPos;
    }
}
