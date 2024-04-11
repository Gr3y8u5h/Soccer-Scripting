//
// Weather Maker for Unity
// (c) 2016 Digital Ruby, LLC
// Source code may be used for personal or commercial projects.
// Source code may NOT be redistributed or sold.
// 
// *** A NOTE ABOUT PIRACY ***
// 
// If you got this asset from a pirate site, please consider buying it from the Unity asset store at https://assetstore.unity.com/packages/slug/60955?aid=1011lGnL. This asset is only legally available from the Unity Asset Store.
// 
// I'm a single indie dev supporting my family by spending hundreds and thousands of hours on this and other assets. It's very offensive, rude and just plain evil to steal when I (and many others) put so much hard work into the software.
// 
// Thank you.
//
// *** END NOTE ABOUT PIRACY ***
//

// Resources:
// http://library.nd.edu/documents/arch-lib/Unity/SB/Assets/SampleScenes/Shaders/Skybox-Procedural.shader
//

// TODO: Better sky: https://github.com/ngokevin/kframe/blob/master/components/sun-sky/shaders/fragment.glsl
// TODO: Better sky: https://threejs.org/examples/js/objects/Sky.js

Shader "WeatherMaker/WeatherMakerSkySphereShader"
{
	Properties
	{
	}
	SubShader
	{
		Tags { "Queue" = "Geometry+1" }

		CGINCLUDE

		#pragma target 3.5
		#pragma exclude_renderers gles
		#pragma exclude_renderers d3d9

		#define WEATHER_MAKER_ENABLE_TEXTURE_DEFINES

		#include "WeatherMakerSkyBoxShaderInclude.cginc"

		#pragma fragmentoption ARB_precision_hint_fastest
		#pragma glsl_no_auto_normalization
		#pragma multi_compile_instancing

		fixed4 frag(wm_volumetric_data i) : SV_Target
		{
			WM_INSTANCE_FRAG(i);
			return ComputeSkySphereColorVolumetric(i, false, true);
		}

		ENDCG

		Pass
		{
			Tags { }
			Cull Front Lighting Off ZWrite Off ZTest Always
			Blend SrcAlpha OneMinusSrcAlpha

			CGPROGRAM

			#pragma vertex GetVolumetricData
			#pragma fragment frag

			ENDCG
		}

		Pass
		{
			Tags { }
			Cull Off Lighting Off ZWrite Off ZTest Off Fog{ Mode Off }
			Blend SrcAlpha Zero

			CGPROGRAM

			#pragma vertex GetVolumetricData
			#pragma fragment frag

			ENDCG
		}
	}

	FallBack Off
}
