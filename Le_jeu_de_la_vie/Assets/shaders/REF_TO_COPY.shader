Shader "Learning/Unlit/SHADER_TO_COPY"
{
    Properties
    {   
		_WaveScale("Wave scale", Float) = 0.07
        _ReflDistort("Reflection distort", Range(0,1.5)) = 0.5  // slider
        _RefrColor("Refraction color", Color) = (0.34, 0.85, 0.92, 1) // color
        _RefrVector("Refraction color", Vector) = (1, 0, 0, 1)
        _ReflectionTex("Environment Reflection", 2D) = "white" {} // textures 
        _RefractionTex("Environment Refraction", 2D) = "black" {} 	
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }

		Pass
        {
			HLSLPROGRAM
            #pragma vertex vert  
            #pragma fragment frag

            #include "UnityCG.cginc"
			
			float _WaveScale, _ReflDistort;
			sampler2D _ReflectionTex, _RefractionTex;
			float4 _RefrColor, _RefrVector;
			
			struct vertexInput
            {
                float4 vertex : POSITION;						
            };
			
            struct v2f
            {
                float4 vertex : SV_POSITION;    
            };

            v2f vert (vertexInput v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                return o;
            }

            float4 frag(v2f i) : SV_Target
            {
                return float4(1,0,0,0); 
            }
            ENDHLSL
        }
    }
}
