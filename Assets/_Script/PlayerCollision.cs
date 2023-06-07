using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {      
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Items"))
        {
            InventoryManager.Instance.PickUpItem(collision.collider.gameObject);
        }
    }
}
