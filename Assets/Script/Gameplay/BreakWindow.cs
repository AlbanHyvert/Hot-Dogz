using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakWindow : MonoBehaviour , IInteract
{
    [SerializeField] private float _minTimeSpawn = 1f;
    [SerializeField] private float _maxTimeSpawn = 5f;
    [SerializeField] private GameObject _shiba = null;
    private GameObject _giveShiba = null;
    [SerializeField] private int _hitWindow = 4;
    [SerializeField] Controller _shibaholder = null;

    #region Properties
    public GameObject GiveShiba { get { return _giveShiba; } set { _giveShiba = value; } }
    public int HitWindow { get { return _hitWindow; } }
    #endregion Properties

    private void SpawnShiba()
    {

    }

    void IInteract.OnInteract()
    {
        if(_shiba != null)
        {
            if(_hitWindow > 0)
            {
                _hitWindow--;
                Debug.Log("Window : " + _hitWindow);
            }

            if(_hitWindow <= 0)
            {
                GiveShiba = Instantiate(_shiba, _shibaholder.ShibaHolder.transform.position, Quaternion.identity, _shibaholder.ShibaHolder.transform);
                _shiba.GetComponent<Collider>().enabled = false;
                Debug.Log("Give SHiba :" + GiveShiba);
                _hitWindow = 4;
            }
        }
    }
}
