using System;
using UnityEngine;

public class ContainerCounter : BaseCounter
{

    public event EventHandler OnPlayerGrabbedObject;
    
    [SerializeField] private KitchenObjectsSO kitchenObjectSO;
    
    
    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            //spawns an object and immediately gives it to player
            Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab);
            kitchenObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(player);
            OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
        }
        
    }
    
}
