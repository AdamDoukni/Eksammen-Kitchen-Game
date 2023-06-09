using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlateCompleteVisual : MonoBehaviour
{

    [Serializable]
    public struct KitchenObjectSO_GameObject {
    public KitchenObjectSO kitchenObjectSO;
    public GameObject gameObject;
    }

    [SerializeField] private PlateKitchenObject plateKitchenObject;
    [SerializeField] private List<KitchenObjectSO_GameObject> KitchenObjectSO_GameObjectList;

    private void Start() {
        plateKitchenObject.OnIngredientAdded += Platekitchenobject_OnIngredientAdded;
        foreach (KitchenObjectSO_GameObject kitchenObjectSOGameObject in KitchenObjectSO_GameObjectList) {
            kitchenObjectSOGameObject.gameObject.SetActive(false) ;
        }
    }

    private void Platekitchenobject_OnIngredientAdded(object sender, PlateKitchenObject.OnIngredientAddedEventArgs e) {
        foreach (KitchenObjectSO_GameObject kitchenObjectSOGameObject in KitchenObjectSO_GameObjectList) {
            if (kitchenObjectSOGameObject.kitchenObjectSO == e.kitchenObjectSO) {
                kitchenObjectSOGameObject.gameObject.SetActive(true);
            }
        }
    }

}
