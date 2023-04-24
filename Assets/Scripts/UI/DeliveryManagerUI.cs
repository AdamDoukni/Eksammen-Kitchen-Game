using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManagerUI : MonoBehaviour
{

    [SerializeField] private Transform container;
    [SerializeField] private Transform recipeTemplate;

    private void Awake() {
        recipeTemplate.gameObject.SetActive(false);
    }

    private void Start() {
        OrderManager.Instance.OnRecipeCompleted += OrderManager_OnRecipeCompleted;
        OrderManager.Instance.OnRecipeSpawned += DeliveryManager_OnRecipeSpawned;

        UpdateVisual();
    }

    private void OrderManager_OnRecipeCompleted(object sneder, System.EventArgs e) {
        UpdateVisual();
    }

    private void DeliveryManager_OnRecipeSpawned(object sender, System.EventArgs e) {
        UpdateVisual();
    }

    private void UpdateVisual() {
        foreach (Transform child in container) {
            if (child == recipeTemplate) continue;
            Destroy(child.gameObject);
        }

        foreach (RecipeSO recipeSO in OrderManager.Instance.GetWaitingRecipeSOList()) {
            Transform recipeTransform = Instantiate(recipeTemplate, container);
            recipeTransform.gameObject.SetActive(true);
            recipeTransform.GetComponent<OrderManagerSingleUI>().SetRecipeSO(recipeSO);
        }
    }
}





