using UnityEngine;
using Ebac.Core.singleton;
using System.Collections.Generic;

public class ColorManager : Singleton<ColorManager>
{
    public List<Material> materials;
    public List<ColorStup> colorStups;

    public void ChangeColorByType(ArtManager.ArtType artType)
    {
        var setup = colorStups.Find(i => i.artType == artType);

        for(int i = 0; i < materials.Count; i++)
        {
            materials[i].SetColor("_BaseColor", setup.colors[i]);
        }
    }


}

[System.Serializable]
public class ColorStup
{
    public ArtManager.ArtType artType;
    public List<Color> colors;    
}
