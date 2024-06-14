using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorControl : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetBoolToTrue(string name)
    {
        anim.SetBool(name, true);
    }
    public void SetBoolToFalse(string name)
    {
        anim.SetBool(name, false);
    }

}
