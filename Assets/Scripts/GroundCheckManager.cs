using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheckManager : MonoBehaviour
{
    [SerializeField] private LayerMask sueloLayerMask;
    public bool isGrounded;
    private void OnTriggerStay2D(Collider2D collider)
    {
        isGrounded = collider != null && (((1 << collider.gameObject.layer) & sueloLayerMask) != 0);
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        isGrounded = false;
    }
}
