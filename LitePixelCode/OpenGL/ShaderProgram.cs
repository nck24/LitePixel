using System.IO;
using OpenTK.Graphics.OpenGL4;

namespace LitePixel.OpenGL
{
    public class ShaderProgram
    {
        public readonly int handle;

        public ShaderProgram(string vert, string frag){
            string err;
            // set up the vertex shader
            string vertCode = File.ReadAllText(vert);
            int vertHandle = GL.CreateShader(ShaderType.VertexShader);
            GL.ShaderSource(vertHandle, vertCode);
            GL.CompileShader(vertHandle);
            GL.GetShaderInfoLog(vertHandle, out err);
            CheckCompileError(err, "Vertex shader");

            // set up the fragment shader
            string fragCode = File.ReadAllText(frag);
            int fragHandle = GL.CreateShader(ShaderType.FragmentShader);
            GL.ShaderSource(fragHandle, fragCode);
            GL.CompileShader(fragHandle);
            GL.GetShaderInfoLog(vertHandle, out err);
            CheckCompileError(err, "Fragment Shader");
            

            this.handle = GL.CreateProgram();

            GL.AttachShader(this.handle, vertHandle);
            GL.AttachShader(this.handle, fragHandle);

            GL.LinkProgram(this.handle);

            GL.DetachShader(this.handle, vertHandle);
            GL.DetachShader(this.handle, fragHandle);
            GL.DeleteShader(vertHandle);
            GL.DeleteShader(fragHandle);
        }

        void CheckCompileError(string error, string name){
            if (error != String.Empty){
                throw new Exception($"{name} did not compile : {error}");
            }
        }

        public void Use(){
            GL.UseProgram(this.handle);
        }
    }
}