using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))] // Always needs a rigid body
public class PlayerMotor : MonoBehaviour
{
  public Vector3 velocity;
  public Vector3 rotation;
  public Vector3 cameraRotation;
  public Rigidbody rb;
  public Camera cam;

  public Animator animator;
  private static readonly int Running = Animator.StringToHash("Running");

  void Start()
  {
    rb = GetComponent<Rigidbody>();
  }

  public void Movement(Vector3 vel)
  {
    velocity = vel;
  }

  void PerformMovement()
  {
    if (velocity != Vector3.zero)
    {
      animator.SetBool(Running, true);
      rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime); // Moves player
    }
    else if (velocity == Vector3.zero)
    {
      animator.SetBool(Running, false);
    }
  }

  public void Rotation(Vector3 rot)
  {
    rotation = rot;
  }

  public void CameraRotation(Vector3 camRot)
  {
    cameraRotation = camRot;
  }

  void PerformRotation()
  {
    rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
    if (cam != null)
    {
      cam.transform.Rotate(-cameraRotation);
    }
    
  }
  private void FixedUpdate()
  {
    PerformMovement();
    PerformRotation();
  }
}
