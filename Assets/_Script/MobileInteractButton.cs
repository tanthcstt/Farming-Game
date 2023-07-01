using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MobileInteractButton : MonoBehaviour
{
    private Button interactBtn;
    [SerializeField] PlayerAbilityManager playerAbilityManager;

    void Start()
    {
        interactBtn = GetComponent<Button>();
        interactBtn.onClick.AddListener(Interact);
        
    }

    private void Interact()
    {
        Debug.Log("click");
        playerAbilityManager.UseAbility();
    }
}
