using System.Collections;
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
    }

    // Update is called once per frame
    void Update () {
        if(bossManager.phase == BossPhase.phase1)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "EndDonjon")
        {
            bossManager.phase = BossPhase.phase2;
        }
    }
}
