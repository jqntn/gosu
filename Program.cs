using System.Numerics;
using Raylib_cs;

Raylib.SetConfigFlags(ConfigFlags.VSyncHint);
Raylib.InitWindow(800, 800, "ゴース");

Texture2D texture = Raylib.GetShapesTexture();

Shader shader = Raylib.LoadShader(null, "gastly.frag");

int timeLoc = Raylib.GetShaderLocation(shader, "utime");

float time = 0.0f;

while (!Raylib.WindowShouldClose())
{
    time += 0.15f * Raylib.GetFrameTime();

    Raylib.SetShaderValue(shader, timeLoc, time, ShaderUniformDataType.Float);

    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.RayWhite);

    Raylib.BeginShaderMode(shader);
    Raylib.DrawTexturePro(
        texture,
        new Rectangle(0.0f, 0.0f, texture.Width, texture.Height),
        new Rectangle(0.0f, 0.0f, Raylib.GetScreenWidth(), Raylib.GetScreenHeight()),
        Vector2.Zero,
        0.0f,
        Color.White
    );
    Raylib.EndShaderMode();

    Raylib.EndDrawing();
}

Raylib.UnloadShader(shader);
Raylib.CloseWindow();
