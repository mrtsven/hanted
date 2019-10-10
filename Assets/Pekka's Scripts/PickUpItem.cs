using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : Interactable
{
    public int ID;


    public override void Interact() {
        base.Interact();
        PickUp();
    }

    private void PickUp() {
        Inventory.inventory.TakeItem(this);

    }
}
