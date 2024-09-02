using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    public Transform player;
    
   void LateUpdate()//called after fixed update and update as it only needs to be updated after our player has moved.
   {
        Vector3 newPos = player.position;
        newPos.y = transform.position.y;
        transform.position = newPos;

        transform.rotation = Quaternion.Euler(90f, player.eulerAngles.y, 0f); // used for when the player rotates, so the minimap also rotates when the player does.

   }
}
