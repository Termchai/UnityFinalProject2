﻿using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;
public class NetworkManager_Custom : NetworkManager {

    public Text ipAddress;
    public Text playerName;

    public void StartupHost() {
        SetPort();
        NetworkManager.singleton.StartHost();
    }
    public void JoinGame() {
        SetIPAddress();
        SetPort();
        Statistic.playerName = playerName.text;
        NetworkManager.singleton.StartClient();
    }
    void SetIPAddress() {
        NetworkManager.singleton.networkAddress = ipAddress.text;
    }
    void SetPort() {
        NetworkManager.singleton.networkPort = 7777;
    }
    void OnLevelWasLoaded(int level) {
        if (level == 0) {
            //SetupMenuSceneButtons();
            StartCoroutine(SetupMenuSceneButtons());
        }
        else {
            SetupOtherSceneButtons();
        }
    }
    IEnumerator SetupMenuSceneButtons() {
        yield return new WaitForSeconds(0.3f);
        GameObject.Find("ButtonStartHost").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("ButtonStartHost").GetComponent<Button>().onClick.AddListener(StartupHost);
        GameObject.Find("ButtonJoinGame").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("ButtonJoinGame").GetComponent<Button>().onClick.AddListener(JoinGame);
    }
    void SetupOtherSceneButtons() {
        //GameObject.Find("ButtonDisconnect").GetComponent<Button>().onClick.RemoveAllListeners();
        //GameObject.Find("ButtonDisconnect").GetComponent<Button>().onClick.AddListener(NetworkManager.singleton.StopHost);
    }
}