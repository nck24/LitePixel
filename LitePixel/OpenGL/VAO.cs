using System;
using OpenTK.Graphics.OpenGL;
namespace LitePixel.OpenGL
{
    public class VAO
    {
        public readonly int handle;
        public readonly VertexInfo info;

        public VAO(VBO vbo){
            this.info = vbo.vertInfo;

            vbo.BindBuffer();


            this.handle = GL.GenVertexArray();
            this.BindVAO();
            for (int i = 0; i < this.info.atribs.Length; i++){
                GL.VertexAttribPointer(i, this.info.atribs[i].componentCount, VertexAttribPointerType.Float, false, 
                    this.info.sizeInBytes, this.info.atribs[i].offset);
                GL.EnableVertexAttribArray(i);
            }

            this.UnbindVAO();
            vbo.UnbindBuffer();

        }

        public void BindVAO(){
            GL.BindVertexArray(this.handle);
        }

        public void UnbindVAO(){
            GL.BindVertexArray(0);
        }
    }
}