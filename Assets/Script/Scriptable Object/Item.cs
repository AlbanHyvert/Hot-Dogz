using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    [SerializeField] private string _name = "New Item";
    [SerializeField] private Sprite _icon = null;
    [SerializeField] private bool _isDefaultItem = false;

    #region Properties
    public string Name { get { return _name; } }
    public bool IsDefaultItem { get { return _isDefaultItem; } set { _isDefaultItem = value; } }
    public Sprite Icon { get { return _icon; } }
    #endregion
}
