using UnityEngine;
using Unity.Netcode;
using Cinemachine;

public class AssignCamera : NetworkBehaviour
{
    public GameObject FollowCam;
    public GameObject AimCam;
    private Transform CamRoot;
    public CinemachineVirtualCamera Follow;
    public CinemachineVirtualCamera Aim;

    void Start()
    {
        if (IsClient && IsOwner)
        {
            FollowCam = GameObject.Find("PlayerFollowCamera");
            AimCam = GameObject.Find("PlayerAimCamera");

            Follow = FollowCam.GetComponent<CinemachineVirtualCamera>();
            Aim = AimCam.GetComponent<CinemachineVirtualCamera>();

            CamRoot = this.transform.GetChild(0);

            Follow.m_Follow = CamRoot;
            Aim.m_Follow = CamRoot;
        }
    }

    void Update()
    {
        if (FollowCam == null)
        {
            Debug.Log("Can't find the cameras");
        }
    }
}
