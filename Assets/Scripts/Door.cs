using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;
    
    private bool _isOpen;
    
    public void SwitchDoorState()
    {
        _isOpen = !_isOpen;
        _animator.SetBool("isOpen", _isOpen);
    }
}