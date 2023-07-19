using LitePixel.OpenGL;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

namespace LitePixel
{
    public class Window : GameWindow
    {
        ShaderProgram sp = default!;
        int vao;
        int vbo;

        public Window(int width = 1280, int height = 720, string title = "Maze Generator")
            : base(new GameWindowSettings(){
                UpdateFrequency = 60,
            },
                new NativeWindowSettings(){
                Title = title,
                Size = new Vector2i(width, height),
                WindowBorder = WindowBorder.Fixed,
                StartVisible = false,
                StartFocused = false,
                API = ContextAPI.OpenGL,
                Profile = ContextProfile.Core,
                APIVersion = new Version(3, 3)
                })
                {
            this.CenterWindow();

            SetUp();
        }

        private readonly float[] vertices =
        {
            // x     y     R      G     B     A
            -0.5f, -0.5f, 1.0f,  0.0f, 0.0f, 1.0f, // Bottom-left vertex
             0.5f, -0.5f, 0.0f,  1.0f, 0.0f, 1.0f,// Bottom-right vertex
             0.0f,  0.5f, 0.0f,  0.0f, 1.0f, 1.0f,// Top vertex
        };

        void SetUp(){
            this.sp = new ShaderProgram(@"C:\Users\Niko\Documents\Projects\VS Code\C# not personal\LitePixel\Shaders\VertexShader.glsl", 
                @"C:\Users\Niko\Documents\Projects\VS Code\C# not personal\LitePixel\Shaders\FragmentShader.glsl");

            GL.ClearColor(Color4.Aquamarine);

            vbo = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, vbo);
            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);

            vao = GL.GenVertexArray();
            GL.BindVertexArray(vao);
            GL.VertexAttribPointer(0, 2, VertexAttribPointerType.Float, false, 6 * sizeof(float), 0);
            GL.VertexAttribPointer(1, 4, VertexAttribPointerType.Float, false, 6 * sizeof(float), 2 * sizeof(float));

            GL.EnableVertexAttribArray(0);
            GL.EnableVertexAttribArray(1);

            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);

            GL.Clear(ClearBufferMask.ColorBufferBit);
            
            this.sp.Use();
            GL.BindVertexArray(vao);
            GL.DrawArrays(PrimitiveType.Triangles, 0, 3);
            this.SwapBuffers();
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);

            GL.Clear(ClearBufferMask.ColorBufferBit);

            sp.Use();
            GL.BindVertexArray(vao);
            GL.DrawArrays(PrimitiveType.Triangles, 0, 3);
            SwapBuffers();
        }
    }
}