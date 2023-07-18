using System.IO;
using OpenTK.Graphics.OpenGL4;

namespace LitePixel.OpenGL
{
    public class ShaderProgram
    {
        public readonly int handle;

        public ShaderProgram(string vert, string frag){

            // set up the vertex shader
            string vertCode = File.ReadAllText(vert);
            int vertHandle = GL.CreateShader(ShaderType.VertexShader);
            GL.ShaderSource(vertHandle, vertCode);
            GL.CompileShader(vertHandle);
            CheckCompileError(GL.GetError(), "Vertex Shader");

            // set up the fragment shader
            string fragCode = File.ReadAllText(frag);
            int fragHandle = GL.CreateShader(ShaderType.FragmentShader);
            GL.ShaderSource(fragHandle, fragCode);
            GL.CompileShader(fragHandle);
            CheckCompileError(GL.GetError(), "Fragment Shader");
            

            this.handle = GL.CreateProgram();

            GL.AttachShader(this.handle, vertHandle);
            GL.AttachShader(this.handle, fragHandle);

            GL.LinkProgram(this.handle);

            GL.DetachShader(this.handle, vertHandle);
            GL.DetachShader(this.handle, fragHandle);
            GL.DeleteShader(vertHandle);
            GL.DeleteShader(fragHandle);
        }

        void CheckCompileError(ErrorCode er, string name){
            if (er != ErrorCode.NoError){
                throw new Exception($"{name} did not compile");
            }
        }
    }
}