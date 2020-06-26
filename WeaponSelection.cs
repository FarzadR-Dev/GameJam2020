using UnityEngine;

public class WeaponSelection : MonoBehaviour
{
    public int activeWeapon;

    private void SelectWeapon()
    {
        var i = 0;
        foreach (Transform weapon in transform)
        {
            weapon.gameObject.SetActive(i == activeWeapon);
            i++;
        }
    }
    void Start()
    {
        SelectWeapon();
    }
    
    void Update()
    {
        var previousWeapon = activeWeapon;
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (activeWeapon >= transform.childCount - 1)
                activeWeapon = 0;
            else
                activeWeapon++;
        }
        if (previousWeapon != activeWeapon)
            SelectWeapon();
    }
}
