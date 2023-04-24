using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientCounterVisual : MonoBehaviour {

    private const string OPEN_CLOSR = "OpenClose";

    [SerializeField] private IngredientCounter ingredientCounter;
    private Animator animator;

    private void Awake(){
        animator = GetComponent<Animator>();
    }

    private void Start() {
        ingredientCounter.OnPlayerGrabbedObject += ContainerCounter_OnplayerGrabbedObject;
    }

    private void ContainerCounter_OnplayerGrabbedObject(object sender, System.EventArgs e) {
        animator.SetTrigger(OPEN_CLOSR);
    }
}
 
