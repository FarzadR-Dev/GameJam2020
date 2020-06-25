using UnityEngine;


[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
   new public string name = "New Item";
   public Sprite icon = null;
   public bool IsDefaultItem = false;

   public virtual void Use()
   {
      Debug.Log("WE ARE USING " + name);
   }




}
