using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class OtherFunc
{
    public static Texture2D MSPLoadImage(string filename) // thanks aidan or whoever created this at first- lol
    {
        var a = Assembly.GetExecutingAssembly();
        var spriteData = a.GetManifestResourceStream("MaterialSlimesPlus." + filename);
        var rawData = new byte[spriteData.Length];
        spriteData.Read(rawData, 0, rawData.Length);
        var tex = new Texture2D(1, 1);
        tex.LoadImage(rawData);
        tex.filterMode = FilterMode.Bilinear;
        return tex;
    }
    public static Sprite MSPCreateSprite(Texture2D texture) => Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f), 1);
}

class ParseFunc
{
    static public Identifiable.Id ParseId(Type EnType, string EnValue)
    {
        return (Identifiable.Id)Enum.Parse(EnType, EnValue);
    }

    static public Gadget.Id ParseGad(Type EnType, string EnValue)
    {
        return (Gadget.Id)Enum.Parse(EnType, EnValue);
    }

    static public PediaDirector.Id ParsePed(Type EnType, string EnValue)
    {
        return (PediaDirector.Id)Enum.Parse(EnType, EnValue);
    }
}