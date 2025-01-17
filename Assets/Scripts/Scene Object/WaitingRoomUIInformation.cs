﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class WaitingRoomUIInformation : NetworkBehaviour
{
    public TextCountdown countdown;
    public GameObject playerOneReadyUI;
    public GameObject playerTwoReadyUI;
    public GameObject hint;
    public string nextSceneName = "Play Scene Features Test";

    [SyncVar]
    public bool playerOneReady = false;
    [SyncVar]
    public bool playerTwoReady = false;

    private GameObject localPlayer = null;
    private int playerID;
    private bool sceneIsLoaded;

    private void Start()
    {
        playerOneReadyUI.SetActive(false);
        playerTwoReadyUI.SetActive(false);
        sceneIsLoaded = false;
    }

    private void Update()
    {
        Debug.LogError(playerID);
        if(NetworkClient.ready && localPlayer == null)
        {
            SetLocalPlayer();
        }
        if (OVRInput.GetDown(OVRInput.Button.One) || Input.GetKeyDown(KeyCode.A))
        {
            SetPlayerReadyState(playerID);
        }
        SetPlayerReadyUI();
        if (AllPlayerAreReady()) {
            hint.SetActive(false);
            countdown.gameObject.SetActive(true);
            if (isServer && countdown.timer <= 0 && sceneIsLoaded == false)
            {
                sceneIsLoaded = true;
                GameManager.singleton.LoadScene(nextSceneName);
            }
        }
        else
        {
            hint.SetActive(true);
            countdown.gameObject.SetActive(false);
            countdown.timer = countdown.countdown;
        }
    }

    private void SetLocalPlayer()
    {
        localPlayer = NetworkClient.localPlayer.gameObject;
        if (Vector3.Distance(localPlayer.transform.position, playerOneReadyUI.transform.position) < Vector3.Distance(localPlayer.transform.position, playerTwoReadyUI.transform.position))
        {
            playerID = 1;
        }
        else
        {
            playerID = 2;
        }
    }

    [Command(requiresAuthority = false)]
    private void SetPlayerReadyState(int id)
    {
        if(id == 1)
        {
            playerOneReady = playerOneReady ? false : true;
        }
        else
        {
            playerTwoReady = playerTwoReady ? false : true;
        }
    }

    private void SetPlayerReadyUI()
    {
        if (playerOneReady)
        {
            playerOneReadyUI.SetActive(true);
        }
        else
        {
            playerOneReadyUI.SetActive(false);
        }
        if (playerTwoReady)
        {
            playerTwoReadyUI.SetActive(true);
        }
        else
        {
            playerTwoReadyUI.SetActive(false);
        }
    }

    private bool AllPlayerAreReady()
    {
        return playerOneReady && playerTwoReady;
    }
}
