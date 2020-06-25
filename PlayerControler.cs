using UnityEngine.EventSystems;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerControler : MonoBehaviour
{
    public Camera cam;
    public LayerMask movementMask;
    public PlayerMotor motor;
    public Interactables focus;
    
    
    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
            

        
            if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, movementMask))
            { 
                motor.MoveToPoint(hit.point);
                
                Vector3 vector = (hit.point - transform.position).normalized;
                Quaternion lookRotation = Quaternion.LookRotation(new Vector3(vector.x, 0f, vector.z));
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 100f);   
                
                
                
                
                RemoveFocus();
            }
        } 
        
        if (Input.GetMouseButtonDown(1))
        {
            if (Input.GetMouseButtonDown(1))
            {
                Ray ray2 = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit2;

                if (Physics.Raycast(ray2, out hit2, 100))
                {
                    Interactables interactables = hit2.collider.GetComponent<Interactables>();
                    if (interactables != null)
                    {
                        SetFocus(interactables);
                    }
                }
            }
        }
    }

    void SetFocus(Interactables newFocus)
    {
        if (newFocus != focus)
        { 
            if (focus != null)
                focus.OnDefocused();
            focus = newFocus; 
            motor.FollowTarget(newFocus);
        }
        
        
        focus = newFocus;  
        newFocus.onFocused(transform);
        motor.FollowTarget(newFocus);
    }

    void RemoveFocus()
    {   
        if (focus != null)
            focus.OnDefocused();
        focus = null; 
        motor.StopFollowingTarget();
    }
    
    
        

}
