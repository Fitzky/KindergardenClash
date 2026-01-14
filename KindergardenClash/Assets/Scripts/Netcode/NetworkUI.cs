using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;

public class NetworkUI : MonoBehaviour
{
    [SerializeField] private Button serverButton;   //No client, server only
    [SerializeField] private Button hostButton;     //Client + Server
    [SerializeField] private Button clientButton;   //No server, client only

    void Awake()
    {
        serverButton.onClick.AddListener(call:() => NetworkManager.Singleton.StartServer());
        hostButton.onClick.AddListener(call:() => NetworkManager.Singleton.StartHost());
        serverButton.onClick.AddListener(call:() => NetworkManager.Singleton.StartClient());
    }
}
