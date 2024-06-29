using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CustomRenderPipeline : RenderPipeline 
{    

    CameraRenderer renderer = new CameraRenderer();
    public CustomRenderPipeline()
    {
        GraphicsSettings.useScriptableRenderPipelineBatching = true;
    }

    protected override void Render( ScriptableRenderContext context, Camera[] cameras    )
    { }    
    
    protected override void Render( ScriptableRenderContext context, List<Camera> cameras    )
    {
        Debug.Log("--------render----------");
        for (int i = 0; i < cameras.Count; i++)
        {            
            renderer.Render(context, cameras[i]);
        }    
    }
}