using UnityEngine;

public class ClearCounter : BaseCounter
{
    [SerializeField] private KitchenObjectsSO kitchenObjectSO;
    
    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            //no kitchen object here
            if (player.HasKitchenObject())
            {
                //player has something
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
    }
        else
        {
            //has a kitchen object
            if (player.HasKitchenObject())
            {
                //player is carrying something
            }
            else
            {
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
        
    }
}

