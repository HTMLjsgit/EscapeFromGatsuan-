// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:0,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:True,hqlp:False,rprd:True,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:2865,x:32719,y:32712,varname:node_2865,prsc:2|custl-4762-OUT;n:type:ShaderForge.SFN_Vector1,id:1715,x:31092,y:33505,varname:node_1715,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Transform,id:418,x:30881,y:33239,varname:node_418,prsc:2,tffrom:0,tfto:3|IN-1236-OUT;n:type:ShaderForge.SFN_NormalVector,id:1236,x:30689,y:33239,prsc:2,pt:False;n:type:ShaderForge.SFN_SceneColor,id:3,x:32098,y:32890,varname:node_3,prsc:2;n:type:ShaderForge.SFN_Add,id:4762,x:32413,y:32945,varname:node_4762,prsc:2|A-3-RGB,B-333-OUT;n:type:ShaderForge.SFN_Color,id:8421,x:31328,y:32910,ptovrint:False,ptlb:Reflection_Color,ptin:_Reflection_Color,varname:_Reflection_Color_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_ComponentMask,id:9757,x:31092,y:33228,varname:node_9757,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-418-XYZ;n:type:ShaderForge.SFN_Multiply,id:4324,x:31324,y:33282,varname:node_4324,prsc:2|A-9757-OUT,B-1715-OUT;n:type:ShaderForge.SFN_Add,id:1595,x:31595,y:33352,varname:node_1595,prsc:2|A-4324-OUT,B-1715-OUT;n:type:ShaderForge.SFN_Tex2d,id:4448,x:31772,y:33232,ptovrint:False,ptlb:Matcap,ptin:_Matcap,varname:_Matcap,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:b906817369d69ef47941d7d9ca264564,ntxv:2,isnm:False|UVIN-1595-OUT;n:type:ShaderForge.SFN_Multiply,id:333,x:32103,y:33176,varname:node_333,prsc:2|A-4448-RGB,B-3811-OUT,C-4408-OUT;n:type:ShaderForge.SFN_Multiply,id:3811,x:31561,y:33539,varname:node_3811,prsc:2|A-8421-RGB,B-1216-OUT;n:type:ShaderForge.SFN_Slider,id:1216,x:31209,y:33610,ptovrint:False,ptlb:Matcap_Strength,ptin:_Matcap_Strength,varname:_Matcap_Strength,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.18,max:1;n:type:ShaderForge.SFN_Color,id:5325,x:31348,y:33814,ptovrint:False,ptlb:Emission_Base_Color,ptin:_Emission_Base_Color,varname:_Emission_Base_Color,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:8346,x:31161,y:34022,varname:node_8346,prsc:2|IN-5163-OUT,IMIN-7388-OUT,IMAX-9973-OUT,OMIN-633-OUT,OMAX-9199-OUT;n:type:ShaderForge.SFN_Vector1,id:7388,x:30904,y:34037,varname:node_7388,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:9973,x:30904,y:34090,varname:node_9973,prsc:2,v1:1;n:type:ShaderForge.SFN_Vector1,id:9199,x:30965,y:34242,varname:node_9199,prsc:2,v1:1;n:type:ShaderForge.SFN_Power,id:47,x:31353,y:34081,varname:node_47,prsc:2|VAL-8346-OUT,EXP-2014-OUT;n:type:ShaderForge.SFN_Vector1,id:2014,x:31159,y:34272,varname:node_2014,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Slider,id:633,x:30682,y:34217,ptovrint:False,ptlb:Matcap_Emission_Bottom,ptin:_Matcap_Emission_Bottom,varname:_Matcap_Emission_Bottom,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.01,max:1;n:type:ShaderForge.SFN_Multiply,id:7942,x:31518,y:33921,varname:node_7942,prsc:2|A-5325-RGB,B-47-OUT;n:type:ShaderForge.SFN_Color,id:4344,x:31654,y:33080,ptovrint:False,ptlb:Color,ptin:_Color,varname:_Color,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:0.03921569;n:type:ShaderForge.SFN_AmbientLight,id:252,x:30267,y:34102,varname:node_252,prsc:2;n:type:ShaderForge.SFN_LightColor,id:4020,x:30431,y:34122,varname:node_4020,prsc:2;n:type:ShaderForge.SFN_Add,id:8789,x:30473,y:33893,varname:node_8789,prsc:2|A-9105-OUT,B-8388-RGB,C-252-RGB;n:type:ShaderForge.SFN_Multiply,id:5163,x:30702,y:33955,varname:node_5163,prsc:2|A-8789-OUT,B-4020-RGB;n:type:ShaderForge.SFN_Add,id:4408,x:31690,y:34005,varname:node_4408,prsc:2|A-7942-OUT,B-47-OUT;n:type:ShaderForge.SFN_SceneColor,id:8388,x:30267,y:33972,varname:node_8388,prsc:2;n:type:ShaderForge.SFN_Dot,id:1566,x:29563,y:33692,varname:node_1566,prsc:2,dt:1|A-5866-OUT,B-1266-OUT;n:type:ShaderForge.SFN_NormalVector,id:5866,x:29394,y:33644,prsc:2,pt:False;n:type:ShaderForge.SFN_LightVector,id:1266,x:29394,y:33786,varname:node_1266,prsc:2;n:type:ShaderForge.SFN_ViewReflectionVector,id:8339,x:29394,y:33906,varname:node_8339,prsc:2;n:type:ShaderForge.SFN_Dot,id:8177,x:29563,y:33842,varname:node_8177,prsc:2,dt:1|A-1266-OUT,B-8339-OUT;n:type:ShaderForge.SFN_Add,id:9105,x:29939,y:33744,varname:node_9105,prsc:2|A-1566-OUT,B-7794-OUT;n:type:ShaderForge.SFN_Exp,id:7113,x:29563,y:34042,varname:node_7113,prsc:2,et:1|IN-3590-OUT;n:type:ShaderForge.SFN_Power,id:7794,x:29762,y:33880,varname:node_7794,prsc:2|VAL-8177-OUT,EXP-7113-OUT;n:type:ShaderForge.SFN_Vector1,id:3590,x:29394,y:34086,varname:node_3590,prsc:2,v1:2;proporder:8421-4448-1216-5325-633;pass:END;sub:END;*/

Shader "Shader Forge/oy_Matcap" {
    Properties {
        _Reflection_Color ("Reflection_Color", Color) = (1,1,1,1)
        _Matcap ("Matcap", 2D) = "black" {}
        _Matcap_Strength ("Matcap_Strength", Range(0, 1)) = 0.18
        _Emission_Base_Color ("Emission_Base_Color", Color) = (0,0,0,1)
        _Matcap_Emission_Bottom ("Matcap_Emission_Bottom", Range(0, 1)) = 0.01
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
			"VRCFallback" = "Hidden"
        }
        GrabPass{ }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
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
			uniform float4 _Reflection_Color;
            uniform sampler2D _Matcap; uniform float4 _Matcap_ST;
            uniform float _Matcap_Strength;
            uniform float4 _Emission_Base_Color;
            uniform float _Matcap_Emission_Bottom;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
				UNITY_VERTEX_INPUT_INSTANCE_ID //for Single Pass Instancing
			};
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                float4 projPos : TEXCOORD2;
                UNITY_FOG_COORDS(3)
				UNITY_VERTEX_OUTPUT_STEREO //for Single Pass Instancing
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;

				UNITY_SETUP_INSTANCE_ID(v); //for Single Pass Instancing
				UNITY_INITIALIZE_OUTPUT(VertexOutput, o); //for Single Pass Instancing
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o); //for Single Pass Instancing

				o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
				UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(i); //for Single Pass Instancing
				i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float2 sceneUVs = (i.projPos.xy / i.projPos.w);
                float4 sceneColor = UNITY_SAMPLE_SCREENSPACE_TEXTURE(_GrabTexture, sceneUVs); //for Single Pass Instancing
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float node_1715 = 0.5;
                float2 node_1595 = ((mul( UNITY_MATRIX_V, float4(i.normalDir,0) ).xyz.rgb.rg*node_1715)+node_1715);
                float4 _Matcap_var = tex2D(_Matcap,TRANSFORM_TEX(node_1595, _Matcap));
                float node_7388 = 0.0;
                float3 node_47 = pow((_Matcap_Emission_Bottom + ( ((((max(0,dot(i.normalDir,lightDirection))+pow(max(0,dot(lightDirection,viewReflectDirection)),exp2(2.0)))+sceneColor.rgb+UNITY_LIGHTMODEL_AMBIENT.rgb)*_LightColor0.rgb) - node_7388) * (1.0 - _Matcap_Emission_Bottom) ) / (1.0 - node_7388)),0.5);
                float3 finalColor = (sceneColor.rgb+(_Matcap_var.rgb*(_Reflection_Color.rgb*_Matcap_Strength)*((_Emission_Base_Color.rgb*node_47)+node_47)));
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdadd
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
			UNITY_DECLARE_SCREENSPACE_TEXTURE(_GrabTexture); //for Single Pass Instancing
			uniform float4 _Reflection_Color;
            uniform sampler2D _Matcap; uniform float4 _Matcap_ST;
            uniform float _Matcap_Strength;
            uniform float4 _Emission_Base_Color;
            uniform float _Matcap_Emission_Bottom;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
				UNITY_VERTEX_INPUT_INSTANCE_ID //for Single Pass Instancing
			};
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                float4 projPos : TEXCOORD2;
                LIGHTING_COORDS(3,4)
                UNITY_FOG_COORDS(5)
				UNITY_VERTEX_OUTPUT_STEREO //for Single Pass Instancing
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;

				UNITY_SETUP_INSTANCE_ID(v); //for Single Pass Instancing
				UNITY_INITIALIZE_OUTPUT(VertexOutput, o); //for Single Pass Instancing
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o); //for Single Pass Instancing
				
				o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
				UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(i); //for Single Pass Instancing
				i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float2 sceneUVs = (i.projPos.xy / i.projPos.w);
                float4 sceneColor = UNITY_SAMPLE_SCREENSPACE_TEXTURE(_GrabTexture, sceneUVs); //for Single Pass Instancing
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float node_1715 = 0.5;
                float2 node_1595 = ((mul( UNITY_MATRIX_V, float4(i.normalDir,0) ).xyz.rgb.rg*node_1715)+node_1715);
                float4 _Matcap_var = tex2D(_Matcap,TRANSFORM_TEX(node_1595, _Matcap));
                float node_7388 = 0.0;
                float3 node_47 = pow((_Matcap_Emission_Bottom + ( ((((max(0,dot(i.normalDir,lightDirection))+pow(max(0,dot(lightDirection,viewReflectDirection)),exp2(2.0)))+sceneColor.rgb+UNITY_LIGHTMODEL_AMBIENT.rgb)*_LightColor0.rgb) - node_7388) * (1.0 - _Matcap_Emission_Bottom) ) / (1.0 - node_7388)),0.5);
                float3 finalColor = (sceneColor.rgb+(_Matcap_var.rgb*(_Reflection_Color.rgb*_Matcap_Strength)*((_Emission_Base_Color.rgb*node_47)+node_47)));
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
