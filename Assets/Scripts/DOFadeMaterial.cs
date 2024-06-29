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
        Debug.Log("----------------------------------------------------------------------------1");
        Debug.Log("DOFade関数ないです。");
        if (transparent_color == 1)
        {
            Debug.Log("DoFade関数==1が読み込まれています");
            StandardShaderUtils.ChangeRenderMode(mesh_renderer.material, StandardShaderUtils.BlendMode.Opaque);
        }
        else
        {
            Debug.Log("DoFade関数==1以外が読み込まれていますよおおお Fadeマテリアルに変更するよ。");
            StandardShaderUtils.ChangeRenderMode(mesh_renderer.material, StandardShaderUtils.BlendMode.Fade);
        }
        Debug.Log("DOFade関数内---transparent_color: " + transparent_color);
        Debug.Log("DOFade関数内---Fade??: " + mesh_renderer.material.renderQueue);
        mesh_renderer.material.color = new Color(default_color.r,default_color.g,default_color.b, transparent_color);
        Debug.Log("MeshRenderMode??: " + mesh_renderer.material);
        Debug.Log("----------------------------------------------------------------------------2");
    }
}
