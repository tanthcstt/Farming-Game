using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MobileInteractButton : MonoBehaviour
{
    private Button interactBtn;
    [SerializeField] PlayerAbilityManager playerAbilityManager;
    [SerializeField] PlayerInteraction playerInteraction;

    private Image btnImage;
    private static int prevAbilityIndex;
    [Header("Ability icons")]
    public List<Sprite> abilityIcons;
    [Header("Interaction Icon")]
    [SerializeField] private Sprite openDoor;
    [SerializeField] private Sprite getOnBoat;
    [SerializeField] private Sprite getOffBoat;
    [SerializeField] private Sprite trading;
    [SerializeField] private Sprite crafting;
    void Start()
    {
        prevAbilityIndex = -1;
        btnImage = transform.GetChild(0).GetComponent<Image>();
        interactBtn = GetComponent<Button>();
        interactBtn.onClick.AddListener(Interact);
        UpdateAbilityIcon();
    }

    private void Update()
    {
        if (playerInteraction.CurrentType == PlayerInteraction.InteractionType.useAbility)
        {
            UpdateAbilityIcon();
        } else
        {
            UpdateIteractionIcon();
        }
    }
    private void Interact()
    {      
        if (playerInteraction.CurrentType == PlayerInteraction.InteractionType.useAbility)
        {
            playerAbilityManager.UseAbility();           
        } else
        {
            playerInteraction.Interact();
        }
    }
    private void UpdateAbilityIcon()
    {
      
        int currentAbilityIndex = InputManager.Instance.HotbarSelection;
        if (prevAbilityIndex == currentAbilityIndex) return;
        btnImage.sprite = abilityIcons[currentAbilityIndex];
        prevAbilityIndex = currentAbilityIndex;
    }

    private void UpdateIteractionIcon()
    {
        prevAbilityIndex = -1;

        switch (playerInteraction.CurrentType)
        {
            case PlayerInteraction.InteractionType.GetOnBoat:
                btnImage.sprite = getOnBoat;

                break;
            case PlayerInteraction.InteractionType.OpenDoor:
                btnImage.sprite = openDoor;
                break;
            case PlayerInteraction.InteractionType.Trading:
                btnImage.sprite = trading;
                break;
            case PlayerInteraction.InteractionType.Crafting:
                btnImage.sprite = crafting;
                break;
            case PlayerInteraction.InteractionType.BoatDriving:
                btnImage.sprite = getOffBoat;
                break;
        }
    }
}
