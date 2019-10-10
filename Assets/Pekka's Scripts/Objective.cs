using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Objective : Interactable
{
    //public int ID;
    public int itemsNeeded;
    [SerializeField] int itemCount = 0;

    public UnityEvent ObjectiveCompleted = new UnityEvent();

    public override void Interact()
    {
        base.Interact();

        if (Inventory.inventory.CurrentItem != null)
        {
            Inventory.inventory.DestroyItem();
            itemCount++;

            if (itemCount >= itemsNeeded)
            {
                ObjectiveCompleted.Invoke();
            }
        }
    }

    //bool CheckDoWeHaveCorrectItem()
    //{
    //    if (Inventory.inventory.CurrentItem == null)
    //    {
    //        Debug.Log("WE DONT HAVE ITEM");
    //        return false;
    //    }

    //    else if (ID != Inventory.inventory.CurrentItem.ID)
    //    {
    //        Debug.Log("WE HAVE WRONG ITEM");
    //        return false;
    //    }
    //    else
    //    {
    //        return true;
    //    }
    //}
}
