using UnityEngine;

[RequireComponent(typeof(PlayerMotor))] // Always needs the player motor script
public class PlayerController : MonoBehaviour
{
    public float speed = 12f;
    public PlayerMotor playerMotor;
    public float sensitivity = 3f;

    void Start()
    {
        playerMotor = GetComponent<PlayerMotor>();
    }

    void Update()
    {
        // Calculate movement as a 3D vector
        var xMovement = Input.GetAxisRaw("Horizontal");
        var zMovement = Input.GetAxisRaw("Vertical");

        var movHorizontal = transform.right * xMovement;
        var movVertical = transform.forward * zMovement;
        
        // Final movement vector
        var velocity = (movHorizontal + movVertical).normalized * speed;
        
        // Apply movement to playerMotor script
        playerMotor.Movement(velocity);
        
        // Calculate rotation for turning around
        var yRotation = Input.GetAxisRaw("Mouse X");
        var rotation = new Vector3(0f, yRotation, 0f) * sensitivity;
        var xRotation = Input.GetAxisRaw("Mouse Y");
        var cameraRotation = new Vector3(xRotation, 0f, 0f) * sensitivity;
        
        //Apply rotation
        playerMotor.Rotation(rotation);
        playerMotor.CameraRotation(cameraRotation);
    }
}
