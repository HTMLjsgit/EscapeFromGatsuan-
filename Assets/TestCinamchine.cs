using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class TestCinamchine : MonoBehaviour
{
    private CinemachineVirtualCamera cvc;
    // Start is called before the first frame update
    void Start()
    {
        cvc = this.gameObject.GetComponent<CinemachineVirtualCamera>();
        cvc.GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.Value = 0;
        cvc.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.Value = 0;

    }

    // Update is called once per frame
    void Update()
    {

        //cvc.GetCinemachineComponent<CinemachineOrbitalTransposer>().m_TrackedObjectOffset.y = 0;
    }
}
