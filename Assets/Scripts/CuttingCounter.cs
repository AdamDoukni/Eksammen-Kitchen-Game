using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter {

    [SerializeField] private CuttingRecipeSO[] cuttingRecipeSOArray;

    public override void Interact(Player player)
        {
            if (!HasKitchenObject()) {
                // There is no KitchenObject here
                if (player.HasKitchenObject()) {
                    // Player is carrying something
                    if (HasRecipeWithInput(player.GetKitchenObject().GetKitchenObjectSO())){
                        player.GetKitchenObject().SetKitchenObjectParent(this);
                    }
                } else {
                    // Player not Carrying anything
                }
        } else {
            // There is a KitchenObject here 
            if (player.HasKitchenObject()) {
            // Player is carrying something 
            } else {
                //Player is not caryying anything
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }

    public override void InteractAlternate(Player player)
    {
       if (HasKitchenObject() && HasRecipeWithInput(GetKitchenObject().GetKitchenObjectSO())) {

            KitchenObjectSO outputKitchenObejctSO = GetOutputForInput(GetKitchenObject().GetKitchenObjectSO()); 
            GetKitchenObject().DestroySelf();
            
            KitchenObject.SpawnKitchenObject(outputKitchenObejctSO, this);
        
       }
    }

    private bool HasRecipeWithInput(KitchenObjectSO inputKitchenObjectSO) {
        foreach (CuttingRecipeSO cuttingRecipeSO in cuttingRecipeSOArray) {
            if (cuttingRecipeSO.input == inputKitchenObjectSO){
                return true;
            }        
        }

        return false;
    }

    private KitchenObjectSO GetOutputForInput(KitchenObjectSO inputKitchenObjectSO) {
        foreach (CuttingRecipeSO cuttingRecipeSO in cuttingRecipeSOArray) {
            if (cuttingRecipeSO.input == inputKitchenObjectSO) {
                return cuttingRecipeSO.output;
            }
        }
        return null;
    }

}
