using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : Interactable
{
    [SerializeField] private Item _item = null;

    public override void Interact()
    {
        base.Interact();

        Pick();
    }

    private void Pick()
    {
        Debug.Log("PickingUp : " + _item.name);
    }
}
