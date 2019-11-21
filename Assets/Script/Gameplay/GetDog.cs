using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDog : MonoBehaviour, IInteract
{
    [SerializeField] private Item _item = null;

    void IInteract.OnInteract()
    {
        Debug.Log("YAS BOI");
    }
}
