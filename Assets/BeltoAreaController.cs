using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
public class BeltoAreaController : SerializedMonoBehaviour
{
    public CreateGatsuBeltoPos create_gatsu_belto_pos;

    public List<Transform> BeltoColliderAreaPositions;
    public List<Transform> BeltoManLists;
    public bool FirstBeltoAreaAlreadyPassed = true;
    public float WaitBeltoAreaToNextPointTime = 1;
    private float WaitBeltoAreaToNextPointTimeNow = 1;
    public GameObject gatsu_belto_prefab;
    public GameObject toumei_prefab;
    [Button]
    public void Create()
    {
        int r = Random.Range(0,5);
        GameObject gatsu_belto_man;
        GatsuBeltoMan gatsu_belto_man_script;
        GatsuBeltoMan.GatsuManOrTransParent who;
        if (r == 3)
        {
            gatsu_belto_man = Instantiate(toumei_prefab, create_gatsu_belto_pos.transform.position, Quaternion.identity);
            who = GatsuBeltoMan.GatsuManOrTransParent.TransparentMan;
        }
        else
        {
            gatsu_belto_man = Instantiate(gatsu_belto_prefab, create_gatsu_belto_pos.transform.position, Quaternion.identity);
            who = GatsuBeltoMan.GatsuManOrTransParent.GatsuMan;
        }
        gatsu_belto_man_script = gatsu_belto_man.GetComponent<GatsuBeltoMan>();
        gatsu_belto_man_script.belto_area_controller = this;
        gatsu_belto_man_script.gatsuman_or_transparentman = who;
        BeltoManLists.Insert(0, gatsu_belto_man.transform);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
