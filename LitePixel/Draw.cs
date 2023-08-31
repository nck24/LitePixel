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
        VAO vao;
        VBO vbo;

        public string vertCode = default!;
        public string frtagCode = default!;
        

        public Window(int width = 1280, int height = 720, string title = "")
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

        private readonly float[] vertices1 =
        {
            // x     y     R      G     B     A
            -0.5f, -0.5f, 1.0f,  0.0f, 0.0f, 1.0f, // Bottom-left vertex
             0.5f, -0.5f, 0.0f,  1.0f, 0.0f, 1.0f,// Bottom-right vertex
             0.0f,  0.5f, 0.0f,  0.0f, 1.0f, 1.0f,// Top vertex
        };
        
        private readonly float[] vertices2 =
        {
            // x     y     R      G     B     A
            -1.0f,  1.0f, 1.0f, 1.0f, 1.0f, 1.0f, // Bottom-left vertex
            -0.25f, 0.0f, 1.0f, 1.0f, 1.0f, 1.0f,// Bottom-right vertex
            -0.1f, -0.5f, 1.0f, 1.0f, 1.0f, 1.0f,// Top vertex
        };

        void SetUp(){
            this.vertCode = File.ReadAllText(@"C:\Users\Niko\Documents\Projects\VS Code\C# not personal\LitePixel\Shaders\VertexShader.glsl");
            this.frtagCode = File.ReadAllText(@"C:\Users\Niko\Documents\Projects\VS Code\C# not personal\LitePixel\Shaders\FragmentShader.glsl");

            this.sp = new ShaderProgram(vertCode, frtagCode);

            GL.ClearColor(Color4.Black);

            this.vbo = new VBO(3, VertexPositionColor.vertInfo);
            this.vbo.SetData(vertices1, 3);

            this.vao = new VAO(this.vbo);

            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);

            GL.Clear(ClearBufferMask.ColorBufferBit);
            
            this.sp.Use();
            this.vao.BindVAO();
            GL.DrawArrays(PrimitiveType.Triangles, 0, 3);
            this.SwapBuffers();
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);
        }

        public void DrawAnotherTriangle(){
            this.SwapBuffers();

            this.vbo.SetData(vertices2, 3);

            this.sp.Use();
            this.vao.BindVAO();
            GL.DrawArrays(PrimitiveType.Triangles, 0, 3);
            this.SwapBuffers();
        }
    }
}

