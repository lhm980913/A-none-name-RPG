Shader "Custom/ui" {
	Properties {
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Mask ("Mask (RGB)", 2D) = "white" {}
		_Hphub ("Hphub (RGB)", 2D) = "white" {}
		_Hp ("hp",range(0,1)) = 1

	}
	SubShader {
		Tags { "RenderType"="Transparent" }
		
		Pass{
		Blend SrcAlpha OneMinusSrcAlpha
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma vertex vert
		#pragma fragment frag
		#include"UnityCG.cginc"

		sampler2D _MainTex;
		sampler2D _Mask;
		sampler2D _Hphub;
		float _hp;
		//float4 _hphub_TexelSize;

		struct a2v {
			float2 uv : TEXCOORD0;
			float4 vert : POSITION0;
		};

		struct v2f{
			float4 uv : TEXCOORD0;
			float4 pos : SV_POSITION;
		};

		v2f vert(a2v v)
		{
			v2f o;
			o.pos = UnityObjectToClipPos(v.vert);
			//o.uv = v.uv * _hphub.xy + _hphub.zw;
			o.uv.xy = v.uv;
			o.uv.zw = v.uv * fixed2(_hp, 1);
			return o;
		}

		fixed4 frag(v2f i) : SV_Target 
		{
			float4 mainColor = tex2D(_MainTex, i.uv.xy);
			float4 maskColor = tex2D(_Mask, i.uv.xy);
			float4 hpColor = tex2D(_Hphub, i.uv.xy);
			float3 BottomColor = hpColor.rgb * maskColor.rgb;
			float3 TopColor = mainColor.rgb * (1 - maskColor.r) ;
			return fixed4(BottomColor * maskColor.a+ TopColor * (1 - maskColor.a),maskColor.a + mainColor.a );
		}

		

		
		ENDCG
		}
	}
	FallBack "Diffuse"
}
