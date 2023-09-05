using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using Unity.VisualScripting;
using UnityEngine;

namespace Oathstring
{
    public class EmptySpaceChecker : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        [SerializeField] private PlayerController playerController;
        private Transform respawnPoint;

        public void SetPlayerController(GameObject player)
        {
            this.player = player;
            playerController = this.player.GetComponent<PlayerController>();
        }

        private void Start()
        {
            respawnPoint = GameObject.Find("Respawn Point").transform;
        }

        private void Update() {
            if(player)
            {
                playerController.enabled = false;
                player.transform.position = respawnPoint.position;
                player.transform.rotation = respawnPoint.rotation;

                StartCoroutine(BackToPlatfrom());
                player = null;
            }
        }

        private IEnumerator BackToPlatfrom()
        {
            yield return new WaitForSeconds(0.3f);

            playerController.enabled = true;
        }
    }
}
