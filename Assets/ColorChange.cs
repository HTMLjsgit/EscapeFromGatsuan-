using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
public class ColorChange : SerializedMonoBehaviour
{
    public Color32 target_color;
    public bool start_change;
    private MeshRenderer mesh_renderer;
    // Start is called before the first frame update
    void Start()
    {
        mesh_renderer = this.gameObject.GetComponent<MeshRenderer>();
        if (start_change)
        {
            ChangeColor();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [Button]
    public void ChangeColor()
    {
        //mesh_renderer.materials[0].color = target_color;
    }
}
