using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public partial class CustomRenderPipeline : RenderPipeline
{

    CameraRenderer renderer = new CameraRenderer();

    bool allowHDR;

    bool useDynamicBatching, useGPUInstancing, useLightsPerObject;

    ShadowSettings shadowSettings;

    PostFXSettings postFXSettings;

    int colorLUTResolution;

    float renderScale;

    public CustomRenderPipeline(
        bool allowHDR,
        bool useDynamicBatching, bool useGPUInstancing, bool useSRPBatcher,
        bool useLightsPerObject, ShadowSettings shadowSettings,
        PostFXSettings postFXSettings, int colorLUTResolution, float renderScale
    )

    {
        this.colorLUTResolution = colorLUTResolution;
        this.allowHDR = allowHDR;
        this.postFXSettings = postFXSettings;
        this.shadowSettings = shadowSettings;
        this.useDynamicBatching = useDynamicBatching;
        this.useGPUInstancing = useGPUInstancing;
        this.useLightsPerObject = useLightsPerObject;
        this.renderScale = renderScale;
        GraphicsSettings.useScriptableRenderPipelineBatching = useSRPBatcher;
        GraphicsSettings.lightsUseLinearIntensity = true;
        InitializeForEditor();
    }

    protected override void Render(ScriptableRenderContext context, Camera[] cameras) { }

    protected override void Render(
        ScriptableRenderContext context, List<Camera> cameras
    )
    {
        for (int i = 0; i < cameras.Count; i++)
        {
            renderer.Render(
                context, cameras[i], allowHDR,
                useDynamicBatching, useGPUInstancing, useLightsPerObject,
                shadowSettings, postFXSettings, colorLUTResolution, renderScale
            );
        }
    }
}