using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerGravity : MonoBehaviour
{
    public static PlayerGravity Instance;
    private CharacterController _characterController;

    private void Awake()
    {
        Instance = this;

        _characterController = GetComponent<CharacterController>();
    }

    public Vector3 HandleGravity(Vector3 vector)
    {
        if (_characterController.isGrounded)
        {
            float groundedGravity = -0.05f;
            vector.y = groundedGravity;
            return vector;
        }
        else
        {
            float groundedGravity = -9.8f;
            vector.y += groundedGravity * Time.deltaTime;
            return vector;
        }
    }
}
