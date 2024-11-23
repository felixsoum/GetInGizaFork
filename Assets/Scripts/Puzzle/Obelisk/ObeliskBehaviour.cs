using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObeliskBehaviour : MonoBehaviour
{
    [SerializeField] private int obNum = 0;
    [SerializeField] private ObeliskPuzzle obelisk;
    private bool isMoving;
    private bool isAdviceVisible;

    private Transform player;

    void Start()
    {
        if(obelisk is null)
        {
            obelisk = GetComponentInParent<ObeliskShadow>().gameObject.GetComponentInParent<ObeliskPuzzle>();
        }
    }

    void Update()
    {
        if(isMoving && Input.GetKeyDown(KeyCode.E))
        {
            var xPos = Mathf.RoundToInt(player.position.x);
            obelisk.MoveObelisk(obNum, xPos);
            isMoving = false;
            CollectableBehaviour.DisableAdvice();
            isAdviceVisible = false;
        }
        if (isAdviceVisible && Input.GetKeyDown(KeyCode.E))
        {
            CollectableBehaviour.EnableAdvice("Press E to put Obeslik in your position, Press Tab to stop");
            isMoving = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            if(player is null)
            {
                player = collision.transform;
            }
            if (!isAdviceVisible)
            {
                CollectableBehaviour.EnableAdvice("Press E to move Obelisk");
                isAdviceVisible = true;

            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            if (isMoving == false)
            {
                CollectableBehaviour.DisableAdvice();
                isAdviceVisible = false;
            }
        }
    }

    //void OnTriggerStay2D(Collider2D other)
    //{
    //    if (!isMoving)
    //    {
    //        return;
    //    }

    //    if (Input.GetKeyDown(KeyCode.Tab))
    //    {
    //        isMoving = false;
    //    }
    //    var isPlayer = other.gameObject.GetComponent<PlayerController>();
    //    if (isPlayer)
    //    {
    //        var playerPos = other.transform.position.x;
    //        var distanceToPlayer = Mathf.Abs(playerPos - transform.position.x);
    //        float maxDistance = 0.01f;
    //        Debug.Log(distanceToPlayer);
    //        if(distanceToPlayer <= maxDistance)
    //        {
    //            if (Input.GetKey(KeyCode.LeftArrow))
    //            {
    //                obelisk.MoveObelisk(obNum, -1f); // Move Obelisk 1 left
    //            }
    //            else if (Input.GetKey(KeyCode.RightArrow))
    //            {
    //                obelisk.MoveObelisk(obNum, 1f); // Move Obelisk 1 left
    //            }
    //        }
    //    }
    //}
}
