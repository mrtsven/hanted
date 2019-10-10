using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory inventory;

    void Awake()
    {
        inventory = this;
    }



    public Transform hand;
    private PickUpItem currentItem;

    public AudioClip pickUp;

    AudioSource audioSource;




    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
    }

    public void TakeItem(PickUpItem item) {
        if (currentItem != null)
        {
            DropItem();
        }
        currentItem = item;
        audioSource.PlayOneShot(pickUp);

        currentItem.transform.position = hand.transform.position;
        currentItem.GetComponent<Rigidbody>().isKinematic = true;
        currentItem.transform.SetParent(hand);

    }

    public void DropItem() {
        currentItem.transform.SetParent(null);
        currentItem.GetComponent<Rigidbody>().isKinematic = false;
        currentItem = null;
    }

    public void DestroyItem(){
        if (currentItem == null){
            return;
        }

        Destroy(currentItem.gameObject);
        currentItem = null;
    }

    public PickUpItem CurrentItem => currentItem;
}
    
