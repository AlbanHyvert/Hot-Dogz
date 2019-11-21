using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] private float _radius = 3f;
    private bool _isFocus = false;
    protected bool _hasInteracted = false; 
    private Transform _player = null;

    #region Properties
    public float Radius { get { return _radius; } set { _radius = value; } }
    #endregion Properties

    protected virtual void Interact()
    {

    }

    protected void VerifDistance()
    {
        if(_isFocus == true && !_hasInteracted)
        {
            float distance = Vector3.Distance(_player.position, transform.position);
            if(distance <= Radius)
            {
                _hasInteracted = true;
            }
        }
    }

    public void OnFocused(Transform playerTransform)
    {
        _isFocus = true;
        _player = playerTransform;
        _hasInteracted = false;
    }

    public void OnDeFocused()
    {
        _isFocus = false;
        _player = null;
        _hasInteracted = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Radius);
    }
}
