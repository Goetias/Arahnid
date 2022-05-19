using UnityEngine;

public class CreatingCameraRay
{
    private Camera _camera;

    public CreatingCameraRay(Camera camera)
    {
        _camera = camera;
    }

    public Ray Create()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction);

        return ray;
    }
}
