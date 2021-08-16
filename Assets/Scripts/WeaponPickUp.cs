using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SG
{
    public class WeaponPickUp : Interactable
    {
        public WeaponItem weapon;

        public override void Interact(PlayerManager playerManager)
        {
            base.Interact(playerManager);

            PickUpItem(playerManager);

        }

        private void PickUpItem(PlayerManager playerManager)
        {
            PlayerInventory playerInventory;
            PlayerLocomotion playerLocomotion;
            AnimatorHandler animatorHandler;

            animatorHandler = playerManager.GetComponentInChildren<AnimatorHandler>();
            playerInventory = playerManager.GetComponent<PlayerInventory>();
            playerLocomotion = playerManager.GetComponent<PlayerLocomotion>();
            playerLocomotion.rigidbody.velocity = Vector3.zero;
            animatorHandler.PlayTargetAnimation("PickUpItem", true);
            playerInventory.weaponsInventory.Add(weapon);
            playerManager.itemInteractableGameobject.GetComponentInChildren<Text>().text = weapon.itemName;
            playerManager.itemInteractableGameobject.SetActive(true);
            Destroy(gameObject);


        }
    }
}
