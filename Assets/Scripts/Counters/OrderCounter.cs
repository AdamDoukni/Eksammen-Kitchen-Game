using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderCounter : BaseCounter
{

    public override void Interact(Player player) {
        if (player.HasKitchenObject()) {
            if (player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject)) {
                // Only accepts Plates
                OrderManager.Instance.OrderRecipe(plateKitchenObject);
                player.GetKitchenObject().DestroySelf();
            }
        }
    }    
    public override void Interact(Player1 player) {
        if (player.HasKitchenObject()) {
            if (player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject)) {
                // Only accepts Plates
                OrderManager.Instance.OrderRecipe(plateKitchenObject);
                player.GetKitchenObject().DestroySelf();
            }
        }
    }    
}