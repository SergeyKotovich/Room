using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform _inventory;
    
    private InteractableItem _lastInteractableItem;
    private InteractableItem _lastPickedUpItem;
    

   
    void Update()
    {
        HighlightSelectedObject();

        if (Input.GetMouseButtonDown(0) && _lastPickedUpItem != null)
        {
            _lastPickedUpItem.ThrowAway(transform.forward);
            _lastPickedUpItem = null;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            TryPickUpItem();

            var door = RaycastUtils.GetSelectedObject<Door>();
            if (door != null)
            {
                door.SwitchDoorState();
            }
        }
    }

    private void TryPickUpItem()
    {
        var interactableItem = RaycastUtils.GetSelectedObject<InteractableItem>();
        if (interactableItem != _lastPickedUpItem)
        {
            if (_lastPickedUpItem != null)
            {
                _lastPickedUpItem.Drop();
            }

            if (interactableItem != null)
            {
                interactableItem.PickUp(_inventory);
            }

            _lastPickedUpItem = interactableItem;
        }
    }

    private void HighlightSelectedObject()
    {
        var interactableItem = RaycastUtils.GetSelectedObject<InteractableItem>();
        if (_lastInteractableItem != interactableItem)
        {
            if (_lastInteractableItem != null)
            {
                _lastInteractableItem.RemoveFocus();
            }

            if (interactableItem != null)
            {
                interactableItem.SetFocus();
            }

            _lastInteractableItem = interactableItem;
        }
    }
}