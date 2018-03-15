﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public BossManager bossManager;

    public Transform endMovePos;
    
    public float speed = 1f;

    private Vector2 startPos;

    private void Start()
    {
        startPos = transform.position;
        speed += speed * GameController.Instance.speedRatio;
    }

    // Update is called once per frame
    void Update () {
        if(bossManager.phase == BossPhase.phase1)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if(bossManager.phase == BossPhase.phase2)
        {
            if(bossManager.qte != "" && InputManager.IsDown(bossManager.qte))
            {
                print("Good !");
                bossManager.NextQTE();
            }
            else
            {
                foreach(string key in bossManager.allKeyInputsName)
                {
                    if(key != bossManager.qte)
                    {
                        if(InputManager.IsDown(key))
                        {
                            bossManager.EndGame(false);
                        }
                    }
                }
            }
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "EndDonjon")
        {
            Destroy(collision.gameObject);
            bossManager.phase = BossPhase.phase2;
            bossManager.ShowQTE();
        }

        if(collision.collider.tag == "Trap")
        {
            bossManager.EndGame(false);
        }
    }


}
