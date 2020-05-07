// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader "Pinwheel/OccludedHighlight" {
	Properties
	{
		_OccludedHighlightColor ("Occluded Highlight Color", Color) = (1,1,1,1)
		_Threshold ("Threshold", Range(0.0,1.0)) = 1
		_OverlayTexture ("Overlay", 2D) = "white" {}
		_HighlightMode ("Highlight Mode", Float) = 0
	}
	SubShader{
		
		Pass{
			Tags {
				"Queue"="Overlay"
				"IgnoreProjector"="True"
				"RenderType"="Transparent"
				"PreviewType"="Plane"
			}
			Cull Back Lighting Off ZWrite Off Ztest Always
			Blend SrcAlpha OneMinusSrcAlpha
			NAME "OCCLUDED"
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma shader_feature _SMOOTH_HIGHLIGHT
			#include "UnityCG.cginc"
			#include "Lighting.cginc"

			struct VertexInput{
				float4 vertex: POSITION;
				float3 normal: NORMAL;
			};

			struct VertexOutput{
				float4 pos: SV_POSITION;
				float4 screenPos: TEXCOORD1;
				float4 worldPos: TEXCOORD2;
				float3 worldNormal: TEXCOORD3;
			};

			fixed4 _OccludedHighlightColor;
			fixed _Threshold;
			sampler2D _OverlayTexture;
			float4 _OverlayTexture_ST;
			float _HighlightMode;
			sampler2D _CameraDepthTexture;

			VertexOutput vert(VertexInput i)
			{
				VertexOutput o;
				o.pos = UnityObjectToClipPos(i.vertex);
				o.screenPos = ComputeScreenPos(o.pos);
				o.worldPos = mul(unity_ObjectToWorld, i.vertex);
				o.worldNormal = UnityObjectToWorldNormal(i.normal);

				return o;
			}

			fixed4 frag(VertexOutput i) : COLOR
			{
				fixed depth = LinearEyeDepth(SAMPLE_DEPTH_TEXTURE_PROJ(_CameraDepthTexture, UNITY_PROJ_COORD(i.screenPos)));
				fixed occluded = step(depth-i.screenPos.w, 0);

				fixed3 viewDir = normalize(_WorldSpaceCameraPos - i.worldPos);
				
				fixed silhouetteStrength = 0;
				#if _SMOOTH_HIGHLIGHT
				silhouetteStrength = 1 - dot(viewDir, i.worldNormal);
				#else
				silhouetteStrength =  step(dot(viewDir, i.worldNormal), _Threshold);
				#endif

				float4 uvMultiplier = float4(_OverlayTexture_ST.xy, 1, 1);
				float4 uvOffset = float4(_OverlayTexture_ST.zw, 0, 0);
				fixed4 overlayColor = tex2Dproj(_OverlayTexture, UNITY_PROJ_COORD(i.screenPos)*uvMultiplier + uvOffset);

				fixed4 baseColor = _OccludedHighlightColor*overlayColor*occluded;
				
				fixed alpha = 1;
				#if _SMOOTH_HIGHLIGHT
				alpha = lerp(_Threshold, 1, silhouetteStrength)*_OccludedHighlightColor.a*occluded;
				#else
				alpha = silhouetteStrength*_OccludedHighlightColor.a;
				#endif

				return fixed4(baseColor.rgb, alpha);
			}

			ENDCG
		}
	}
	//FallBack "Diffuse"
}
