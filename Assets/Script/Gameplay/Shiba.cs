using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shiba : MonoBehaviour
{
    private Rigidbody _shibaRb = null;
    private GameObject _shibaGO = null;
    [SerializeField] private int _scorePlus = 10;
    private int _shibaCount = 0;

    public Rigidbody ShibaRb { get { return _shibaRb; } set { _shibaRb = value; } }
    public GameObject ShibaGO { get { return _shibaGO; } set { _shibaGO = value; } }

    private void Start()
    {
        ShibaRb = GetComponent<Rigidbody>();
        ShibaGO = GetComponent<GameObject>();
    }

    public void Update()
    {
        UIController.OnHeatChange(_scorePlus);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Pool"))
        {
            GameManager.Instance.Score += _scorePlus;
            transform.SetParent(other.transform);
            ShibaRb.isKinematic = true;
            _shibaCount++;
        }

        if(_shibaCount >= 10)
        {
            Object.Destroy(gameObject, 0.2f);
        }
    }
}
