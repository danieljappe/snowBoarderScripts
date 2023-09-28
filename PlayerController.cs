using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float normalSpeed = 20f;

    Rigidbody2D rb2d;
    SurfaceEffector2D SurfaceEffector2D;

    private Gamemanager gamemanager;

    // Start is called before the first frame update
    void Start()
    {
        gamemanager = FindObjectOfType<Gamemanager>();
        rb2d = GetComponent<Rigidbody2D>();
        SurfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        RotatePlayer();
        RespondToBoost();
    }

    void RespondToBoost(){
        if(Input.GetKey(KeyCode.UpArrow)) {
            SurfaceEffector2D.speed = boostSpeed;
        }
        else if (Input.GetKey(KeyCode.DownArrow)) {
            SurfaceEffector2D.speed = normalSpeed;
        }
    }

    void RotatePlayer(){
            if(Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(torqueAmount);
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-torqueAmount);
        }
    }
}
