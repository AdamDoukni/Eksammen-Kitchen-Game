using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChopingCounterVisual : MonoBehaviour {

    private const string CUT = "cut";

    [SerializeField] private ChopingCounter chopingCounter;
    private Animator animator;

    private void Awake(){
        animator = GetComponent<Animator>();
    }

    private void Start() {
        chopingCounter.OnCut += CuttingCounter_OnCut;
    }

    private void CuttingCounter_OnCut(object sender, System.EventArgs e) {
        animator.SetTrigger(CUT);
    }
}
 
