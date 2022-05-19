using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : InputEvent
{
    [SerializeField] private Camera MainCamera;
    [SerializeField] private InventoryInfo Inventory;
    [SerializeField] private DisplayOfText Display;

    private CreatingCameraRay CreatingRay;
    private const float _rayLength = 1.5f;

    private bool _isHover = false;


    private void Awake()
    {
        CreatingRay = new CreatingCameraRay(MainCamera);
    }

    private void Update()
    {
        TryIntercation();
    }

    private void TryIntercation()
    {
        RaycastHit[] hits = Physics.RaycastAll(CreatingRay.Create(), _rayLength);

        CheckNoneHover(hits);

        foreach (RaycastHit hit in hits)
        {
            _isHover = hit.collider.TryGetComponent(out InteractionItem item);

            if (_isHover == true)
            {
                HoverInteract(item);

                if (IsPressed == true)
                    ActiveInteract(item);

                break;
            }
        }
    }

    private void CheckNoneHover(RaycastHit[] hits)
    {
        if (hits.Length == 0)
        {
            Display.DisplayNull();
            _isHover = false;
        }
    }

    private void HoverInteract(InteractionItem item)
    {
        item.HoverInteract();
        Display.Display("ItemInteraction", item.GetNameKey());
    }

    private void ActiveInteract(InteractionItem item)
    {
        if (item.TryGetComponent(out IRecordInventory recorder))
        {
            Debug.Log("In Inventory");
            recorder.Record(Inventory);
        }

        item.ActiveInteract();
    }
}
