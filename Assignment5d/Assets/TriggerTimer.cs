﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTimer : MonoBehaviour
{

    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
        player.GetComponent<PlayerJump>().a -= 10;
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    print("TEST");
    //}

    //private void OnCollisionEnter
    //{
    //    gameObject.GetComponent<PlayerJump>().a -= 10;
    //a = a - 10;
    //    print("TEST");
    //}

}
