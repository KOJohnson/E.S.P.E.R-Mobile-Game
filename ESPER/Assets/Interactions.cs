using UnityEngine;
using UnityEngine.Events;


public class Interactions : MonoBehaviour
{  
    [SerializeField] LayerMask interactableLayer;
    [SerializeField] private int maxDistance = 3;
    private UnityEvent onInteract;

    // Update is called once per frame
    void Update()
    {
        
      
    }

    private void RayCastInteract()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit Hit;
        if (Physics.Raycast(ray, out Hit, maxDistance, interactableLayer))
        {
            Debug.Log(Hit.transform.name);
            if (Hit.collider.GetComponent<Interactable>() != false)
            {
                onInteract = Hit.collider.GetComponent<Interactable>().onInteract;
                onInteract.Invoke();
            }
        }
    }
}
