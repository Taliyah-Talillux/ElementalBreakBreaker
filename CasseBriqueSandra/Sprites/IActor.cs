using Microsoft.Xna.Framework;

namespace CasseBriqueSandra;

public interface IActor
{
    Vector2 Position { get; set; }
    Rectangle BoundingBox { get; }
    void Load();
    void Update(GameTime pGameTime);
    void Draw();
    void TouchedBy(IActor pBy);
    bool ToRemove { get; set; }
}
