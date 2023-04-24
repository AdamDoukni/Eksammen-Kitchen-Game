using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour, IKitchenObjectParent {
    public float Speed = 5f;
    float MovementX;
    float MovementY;

    Rigidbody Rb;


    public static Player Instance { get; private set; }
      

    public event EventHandler<OnSelectedCounterChangedEventArgs> OnSelectedCounterChanged;
    public class OnSelectedCounterChangedEventArgs : EventArgs {
        public BaseCounter selectedCounter;
    }

    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private GameInput gameInput; 
    [SerializeField] private LayerMask countersLayerMask;
    [SerializeField] private Transform kitchenObjectHoldPoint;

   
   
    private bool isWalking;
    private Vector3 lastInteractDir;
    private BaseCounter selectedCounter;
    private KitchenObject kitchenObject;
   

    private void Start() {
        gameInput.OnInteractAction += GameInput_OnInteractAction;
        gameInput.OnInteractAlternateAction += GameInput_OnInteractAlternateAction;
    }

      private void GameInput_OnInteractAlternateAction(object sender, System.EventArgs e) {
        if (selectedCounter != null){
            selectedCounter.InteractAlternate(this);
        }
    }
    
    private void GameInput_OnInteractAction(object sender, System.EventArgs e) {
        if (selectedCounter != null){
            selectedCounter.Interact(this);
        }
    }
    private void FixedUpdate() {
       Rb.velocity = new Vector2(MovementX * Speed * Time.deltaTime, MovementY * Speed * Time.deltaTime);

          if (Input.GetKey(KeyCode.UpArrow))
          {
              MovementX = 1;
          }
          else if (Input.GetKey(KeyCode.DownArrow))
          {
              MovementX = -1;
          }
          else if (Input.GetKey(KeyCode.LeftArrow))
          {
              MovementY = -1;
          }
          else if (Input.GetKey(KeyCode.RightArrow))
          {
              MovementY = 1;
          }
          else
          {
              MovementY = 0;
          }

          if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
          {
              MovementX = 0;
          }
          else if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
          {
              MovementY = 0;
          }
          
        
    
    }
    private void Update() {   
         HandleInteractions();
        
    }

    public bool IsWalking() {
        return isWalking;
    }

    private void HandleInteractions(){ 
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();

        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        if (moveDir != Vector3.zero) {
            lastInteractDir = moveDir;
        }

        float interactDistance = 2f;
        if (Physics.Raycast(transform.position, lastInteractDir, out RaycastHit raycastHit, interactDistance, countersLayerMask)) {
        if    (raycastHit.transform.TryGetComponent( out BaseCounter baseCounter)) {

            if (baseCounter != selectedCounter) {
                SetSelectedCounter(baseCounter);
            }
        } else {
            SetSelectedCounter(null);
        }      
        } else {
            SetSelectedCounter(null);
        }
    }



    private void SetSelectedCounter(BaseCounter selectedCounter) {
        this.selectedCounter = selectedCounter;

        OnSelectedCounterChanged?.Invoke(this, new OnSelectedCounterChangedEventArgs {
                    selectedCounter = selectedCounter
                });
    }

    public Transform GetKitchenObjectFollowTransform()
    {
       return kitchenObjectHoldPoint;
    }

    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        this.kitchenObject = kitchenObject;
    }

    public KitchenObject GetKitchenObject()
    {
        return kitchenObject;
    }

    public void ClearKitchenObject()
    {
        kitchenObject = null;
    }

    public bool HasKitchenObject()
    {
        return kitchenObject != null;
    }
}
   