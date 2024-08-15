Shader "Custom/waterfall"
{
    Properties
    {
        _MainTex("Particle Texture", 2D) = "white" { }
        _Gradual("Gradual Factor", Range(0.0, 1.0)) = 1.0
    }
        SubShader
        {
            Tags { "QUEUE" = "Transparent" "IGNOREPROJECTOR" = "true" "RenderType" = "Transparent" "PreviewType" = "Plane" }

            Pass
            {
                Tags { "QUEUE" = "Transparent" "IGNOREPROJECTOR" = "true" "RenderType" = "Transparent" "PreviewType" = "Plane" }
                ZWrite Off
                Cull Off
                Blend SrcAlpha OneMinusSrcAlpha
                ColorMask RGB

                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                #include "UnityCG.cginc"

                struct appdata_t
                {
                    float4 vertex : POSITION;
                    float4 color : COLOR;
                    float2 uv : TEXCOORD0;
                };

                struct v2f
                {
                    float4 pos : POSITION;
                    float2 uv : TEXCOORD0;
                };

                uniform float _Gradual;
                uniform sampler2D _MainTex;
                uniform float4 _MainTex_ST;

                v2f vert(appdata_t v)
                {
                    v2f o;
                    o.pos = UnityObjectToClipPos(v.vertex);
                    o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                    return o;
                }

                float4 frag(v2f i) : SV_Target
                {
                    // Sample the texture
                    float4 texColor = tex2D(_MainTex, i.uv);

                    // Calculate the transparency based on Gradual
                    // Gradual Fade is calculated based on the vertical UV coordinate
                    float gradualFade = (1.0 - i.uv.y) * _Gradual;
                    gradualFade = clamp(gradualFade, 0.0, 1.0); // Ensure gradualFade is between 0 and 1

                    // Apply fade to the final color
                    return texColor ;
                }
                ENDCG
            }
        }
            FallBack "Diffuse"
}

