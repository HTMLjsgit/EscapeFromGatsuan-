// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:0,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:True,hqlp:False,rprd:True,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:2865,x:32719,y:32712,varname:node_2865,prsc:2|custl-4762-OUT;n:type:ShaderForge.SFN_Vector1,id:1715,x:31092,y:33505,varname:node_1715,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Transform,id:418,x:30881,y:33239,varname:node_418,prsc:2,tffrom:0,tfto:3|IN-1236-OUT;n:type:ShaderForge.SFN_NormalVector,id:1236,x:30689,y:33239,prsc:2,pt:False;n:type:ShaderForge.SFN_SceneColor,id:3,x:32098,y:32890,varname:node_3,prsc:2;n:type:ShaderForge.SFN_Add,id:4762,x:32413,y:32945,varname:node_4762,prsc:2|A-3-RGB,B-333-OUT;n:type:ShaderForge.SFN_ComponentMask,id:9757,x:31092,y:33228,varname:node_9757,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-418-XYZ;n:type:ShaderForge.SFN_Multiply,id:4324,x:31324,y:33282,varname:node_4324,prsc:2|A-9757-OUT,B-1715-OUT;n:type:ShaderForge.SFN_Add,id:1595,x:31595,y:33352,varname:node_1595,prsc:2|A-4324-OUT,B-1715-OUT;n:type:ShaderForge.SFN_Tex2d,id:4448,x:31772,y:33232,ptovrint:False,ptlb:Matcap,ptin:_Matcap,varname:_Matcap,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:b906817369d69ef47941d7d9ca264564,ntxv:2,isnm:False|UVIN-1595-OUT;n:type:ShaderForge.SFN_Multiply,id:333,x:32103,y:33176,varname:node_333,prsc:2|A-4448-RGB,B-1216-OUT;n:type:ShaderForge.SFN_Slider,id:1216,x:31630,y:33552,ptovrint:False,ptlb:Matcap_Strength,ptin:_Matcap_Strength,varname:_Matcap_Strength,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.18,max:1;n:type:ShaderForge.SFN_Color,id:4344,x:31654,y:33080,ptovrint:False,ptlb:Color,ptin:_Color,varname:_Color,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:0.03921569;proporder:4448-1216;pass:END;sub:END;*/

Shader "Shader Forge/oy_MatcapSimple" {
    Properties {
        _Matcap ("Matcap", 2D) = "black" {}
        _Matcap_Strength ("Matcap_Strength", Range(0, 1)) = 0.18
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        GrabPass{ }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
				"VRCFallback" = "Hidden"
            }
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
			UNITY_DECLARE_SCREENSPACE_TEXTURE(_GrabTexture); //for Single Pass Instancing
			uniform sampler2D _Matcap; uniform float4 _Matcap_ST;
            uniform float _Matcap_Strength;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
				UNITY_VERTEX_INPUT_INSTANCE_ID //for Single Pass Instancing
			};
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float3 normalDir : TEXCOORD0;
                float4 projPos : TEXCOORD1;
                UNITY_FOG_COORDS(2)
				UNITY_VERTEX_OUTPUT_STEREO //for Single Pass Instancing
            };
            VertexOutput vert (VertexInput v) {
				VertexOutput o = (VertexOutput)0;

				UNITY_SETUP_INSTANCE_ID(v); //for Single Pass Instancing
				UNITY_INITIALIZE_OUTPUT(VertexOutput, o); //for Single Pass Instancing
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o); //for Single Pass Instancing
				
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
				UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(i); //for Single Pass Instancing
				i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                float2 sceneUVs = (i.projPos.xy / i.projPos.w);
                float4 sceneColor = UNITY_SAMPLE_SCREENSPACE_TEXTURE(_GrabTexture, sceneUVs); //for Single Pass Instancing
////// Lighting:
                float node_1715 = 0.5;
                float2 node_1595 = ((mul( UNITY_MATRIX_V, float4(i.normalDir,0) ).xyz.rgb.rg*node_1715)+node_1715);
                float4 _Matcap_var = tex2D(_Matcap,TRANSFORM_TEX(node_1595, _Matcap));
                float3 finalColor = (sceneColor.rgb+(_Matcap_var.rgb*_Matcap_Strength));
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
