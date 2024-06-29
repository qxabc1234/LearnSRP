#ifndef CUSTOM_UNLIT_PASS_INCLUDED
#define CUSTOM_UNLIT_PASS_INCLUDED
#include "../ShaderLibrary/Common.hlsl"

CBUFFER_START(UnityPerMaterial)
float4 _BaseColor;
CBUFFER_END

struct Attributes {
	float3 positionOS : POSITION;
};


float4 UnlitPassVertex(Attributes input) : SV_POSITION{
	float3 positionWS = TransformObjectToWorld(input.positionOS);
	return TransformWorldToHClip(positionWS);
}

float4 UnlitPassFragment() : SV_TARGET{
	return _BaseColor;
}

#endif
