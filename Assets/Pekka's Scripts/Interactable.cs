using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    Transform player;

    bool isFocus = false;

    bool hasInteract = false;

    IEnumerator courutine;

    void Start() {
        courutine = CheckFocus();
        StartCoroutine(courutine);
    }

    IEnumerator CheckFocus(){
        while (true) {

            if (isFocus && hasInteract == false) {
                float distance = Vector3.Distance(player.position, transform.position);
                if (distance <= radius) {
                    Interact();
                    hasInteract = true;
                }
            }
            yield return null;
        }
    }

    // This method is meant to be overwritten
    public virtual void Interact() {

    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    public void Focus(Transform player) {
        isFocus = true;
        this.player = player;
        hasInteract = false;
    }

    public void Defocus() {
        isFocus = false;
        this.player = null;
        hasInteract = false;
    }
}