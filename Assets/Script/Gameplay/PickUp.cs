using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : Interactable
{
    [SerializeField] private Item _item = null;

    protected override void Interact()
    {
        base.Interact();
        Pick();
    }

    private void Pick()
    {
        Debug.Log("PickingUp : " + _item.name);
    }

    private void Update()
    {
        VerifDistance();
        if(_hasInteracted == true)
        {
            Interact();
        }
    }
}
