﻿Shader "Custom/TextureCombiner"
{
    Properties
    {
		_MainTex("Texture", 2D) = "white" {}
		_SecondaryTex("Texture", 2D) = "white" {}
		_futureLocation("Future position", Vector) = (0,0,0,0)
    }
    SubShader
    {
        Tags { "Queue" = "Transparent" "RenderType" = "Transparent" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows alpha:fade

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;
		sampler2D _SecondaryTex;

		float4 _futureLocation;

        struct Input
        {
            float2 uv_MainTex;
			float2 uv_SecondaryTex;
			float3 worldPos;
        };

		struct v2f {
			float2 uv : TEXCOORD0;
			float4 pos : SV_POSITION;
		};

		v2f vert(
			float4 vertex : POSITION, // vertex position input
			float2 uv : TEXCOORD0 // first texture coordinate input
		)
		{
			v2f o;
			o.pos = UnityObjectToClipPos(vertex);
			o.uv = uv;
			return o;
		}
			
        half _Glossiness;
        half _Metallic;
        fixed4 _Color;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color

			float dx, dy;
			dx = _futureLocation.x - IN.worldPos.x;
			dx *= dx;

			dy = _futureLocation.y - IN.worldPos.y;
			dy *= dy;
			
			float factor = 8.0f / ((dx + dy));
			factor *= factor;

			IN.uv_MainTex.y = 1 - IN.uv_MainTex.y;
			IN.uv_SecondaryTex.y = 1 - IN.uv_SecondaryTex.y;

			IN.uv_MainTex.x = 1 - IN.uv_MainTex.x;
			IN.uv_SecondaryTex.x = 1 - IN.uv_SecondaryTex.x;

			fixed4 n1 = min(1, 1 / factor) * tex2D(_MainTex, IN.uv_MainTex);
			fixed4 n2 = min(1, factor) * tex2D(_SecondaryTex, IN.uv_SecondaryTex);
			fixed4 c = sqrt(n1 * n1 + n2 * n2);
            o.Albedo = c.rgb;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
