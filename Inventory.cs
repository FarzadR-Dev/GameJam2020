using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public static Inventory instance;
    public int space = 20;

    public delegate void OnItemChanged();

    public OnItemChanged onItemChangedCallback; 
    
        
    
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory was found!");
            return;
        }
        instance = this;
    }
    
    
    public List<Item> items = new List<Item>();

    public bool Add(Item item)
    {
        if (!item.IsDefaultItem)
        {
            if (items.Count >= space)
            {
                Debug.Log("Inventory Space is Full");
                return false;
            } 
            items.Add(item); 
             
            if (onItemChangedCallback != null)
                 onItemChangedCallback.Invoke();
        }
        return true;
    }
 
    public void Remove(Item item)
    {
        items.Remove(item);  
        
        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }



}
