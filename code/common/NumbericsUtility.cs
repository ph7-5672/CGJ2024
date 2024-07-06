
public static class NumbericsUtility
{

    public static System.Numerics.Vector2 ToSystemNumerics(this Godot.Vector2 vector)
    { 
        return new System.Numerics.Vector2(vector.X, vector.Y);
    }

    public static System.Numerics.Vector3 ToSystemNumerics(this Godot.Vector3 vector)
    {
        return new System.Numerics.Vector3(vector.X, vector.Y, vector.Z);
    }

    public static Godot.Vector2 ToGodotNumerics(this System.Numerics.Vector2 vector)
    {
        return new Godot.Vector2(vector.X, vector.Y);
    }


    public static Godot.Vector3 ToGodotNumerics(this System.Numerics.Vector3 vector)
    {
        return new Godot.Vector3(vector.X, vector.Y, vector.Z);
    }

}