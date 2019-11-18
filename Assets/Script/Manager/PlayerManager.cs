using Prof.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{
    #region Fields
    private float _heat = 0f;
    private float _cooldown = 0f;
    //[SerializeField] private Player _player = null;
    #endregion Fields

    #region Properties
    public float Heat { get { return _heat; } set { _heat = value; } }
    public float CoolDown { get { return _cooldown; } set { _cooldown = value; } }
    #endregion Properties

}
