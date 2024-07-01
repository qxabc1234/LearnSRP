using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CustomRenderPipeline : RenderPipeline 
{
    bool useDynamicBatching, useGPUInstancing;
    ShadowSettings shadowSettings;

    CameraRenderer renderer = new CameraRenderer();
    public CustomRenderPipeline(bool useDynamicBatching, bool useGPUInstancing, bool useSRPBatcher,
        ShadowSettings shadowSettings)
    {
        this.shadowSettings = shadowSettings;
        this.useDynamicBatching = useDynamicBatching;
        this.useGPUInstancing = useGPUInstancing;
        GraphicsSettings.useScriptableRenderPipelineBatching = useSRPBatcher;
        GraphicsSettings.lightsUseLinearIntensity = true;

    }

    protected override void Render( ScriptableRenderContext context, Camera[] cameras    )
    { }    
    
    protected override void Render( ScriptableRenderContext context, List<Camera> cameras    )
    {
        Debug.Log("--------render----------");
        for (int i = 0; i < cameras.Count; i++)
        {            
            renderer.Render(context, cameras[i], useDynamicBatching, useGPUInstancing,
                shadowSettings);
        }    
    }
}