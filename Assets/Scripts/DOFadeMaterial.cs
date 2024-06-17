using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
public class DOFadeMaterial : SerializedMonoBehaviour
{
    public MeshRenderer mesh_renderer;
    private Color default_color;
    public float target_transparent;
    // Start is called before the first frame update
    void Start()
    {
        if(mesh_renderer == null)
        {
            mesh_renderer = this.gameObject.GetComponent<MeshRenderer>();
        }
        default_color = mesh_renderer.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [Button]
    public void DOFade(float transparent_color)
    {
        if(transparent_color == 1)
        {
            Debug.Log("DoFadeä÷êî==1Ç™ì«Ç›çûÇ‹ÇÍÇƒÇ¢Ç‹Ç∑");
            StandardShaderUtils.ChangeRenderMode(mesh_renderer.material, StandardShaderUtils.BlendMode.Opaque);
        }
        else
        {
            StandardShaderUtils.ChangeRenderMode(mesh_renderer.material, StandardShaderUtils.BlendMode.Fade);
        }
        mesh_renderer.material.color = new Color(default_color.r,default_color.g,default_color.b, transparent_color);
    }
}
