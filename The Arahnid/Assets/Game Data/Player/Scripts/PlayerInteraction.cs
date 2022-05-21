using UnityEngine;

public class PlayerInteraction : InputEvent, ITimeService
{
    [SerializeField] private Camera MainCamera;
    [SerializeField] private InventoryInfo Inventory;
    [SerializeField] private DisplayOfText Display;

    private CreatingCameraRay CreatingRay;
    private const float _rayLength = 1.5f;

    private bool _isHover = false;

    private void Update()
    {
        if (_isEnabled == true)
            TryIntercation();
        else Debug.Log("Time is stopped!");
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

    private void Start()
    {
        CreatingRay = new CreatingCameraRay(MainCamera);
        Subscribe();
    }

    private void OnDestroy()
    {
        Unsubscribe();
    }

    public void Pause()
    {
        _isEnabled = false;
    }

    public void Play()
    {
        _isEnabled = true;
    }

    public void Subscribe()
    {
        GameState.Instance.OnPause += Pause;
        GameState.Instance.OnRun += Play;
    }

    public void Unsubscribe()
    {
        GameState.Instance.OnPause -= Pause;
        GameState.Instance.OnRun -= Play;
    }
}
