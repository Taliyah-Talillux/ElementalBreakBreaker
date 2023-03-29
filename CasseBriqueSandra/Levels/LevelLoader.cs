using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace CasseBriqueSandra.Levels;

public class LevelLoader
{
    public static List<Brick> Load(int pLevel)
    {
        string json = File.ReadAllText(@"Levels/Level_" + pLevel + ".json");

        var bricks = new List<Brick>();
        var level = JsonSerializer.Deserialize<List<BrickJson>>(json);


        foreach (var brick in level)
        {
            var newBrick = new Brick(new Vector2(brick.x, brick.y),ConvertNumberToElementalType(brick.type), brick.speed, brick.distance, brick.group);
            bricks.Add(newBrick);

        }
        return bricks;
    }
    public static ElementalType ConvertNumberToElementalType(string pType)
    {
        switch (pType)
        {
            case "Basic":
                return ElementalType.Basic;
            case "Cryo":
                return ElementalType.Cryo;
            case "Hydro":
                return ElementalType.Hydro;
            case "Electro":
                return ElementalType.Electro;
            case "Pyro":
                return ElementalType.Pyro;
        }
        throw new NotImplementedException("Element " + pType + " n'existe pas");
    }


}
