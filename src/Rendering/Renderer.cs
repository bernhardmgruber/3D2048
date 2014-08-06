using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SharpGL;
using SharpGL.SceneGraph.Assets;
using _3D2048.Util;
using _3D2048.Logic;

namespace _3D2048.Rendering
{
    class Renderer
    {
        private OpenGL gl;
        private Textures textures;

        public Renderer(OpenGL glIn)
        {
            gl = glIn;
            textures = new Textures(gl);
        }


   

        public void draw(Camera camera, GameState state)
        {


            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);

            gl.Enable(OpenGL.GL_BLEND);
            gl.BlendFunc(OpenGL.GL_SRC_ALPHA, OpenGL.GL_ONE_MINUS_SRC_ALPHA);

            gl.LoadIdentity();
            gl.Translate(0.0f, 0.0f, camera.zoom);
            gl.Rotate(camera.cubeRotation.x, camera.cubeRotation.y, camera.cubeRotation.z);
            gl.Color(1.0f,1.0f,1.0f,0.45f);

            for (int i = 0; i < GameState.size; i++)
            {
                for (int j = 0; j < GameState.size; j++)
                {
                    for (int k = 0; k < GameState.size; k++)
                    {
                        if (state.field[i, j, k] != 0)
                        {
                            gl.PushMatrix();
                            gl.Translate(-GameState.size / 2 + 0.5 + i, -GameState.size / 2 + 0.5 + j, -GameState.size / 2 + 0.5 + k);
                            drawCube(state.field[i, j, k]);
                            gl.PopMatrix();
                        }
                    }
                }
            }
        }




        private void drawCube(int number)
        {
            Texture texture = textures.get(number);

            //  Bind the texture.
            texture.Bind(gl);

            Vector3D color = Util.Color.getTileColor(number);
            gl.Color(color.x, color.y, color.z, 0.45f);

            gl.Begin(OpenGL.GL_QUADS);

            // Front Face
            gl.TexCoord(0.0f, 1.0f); gl.Vertex(-0.5f, -0.5f, 0.5f);	// Bottom Left Of The Texture and Quad
            gl.TexCoord(1.0f, 1.0f); gl.Vertex(0.5f, -0.5f, 0.5f);	// Bottom Right Of The Texture and Quad
            gl.TexCoord(1.0f, 0.0f); gl.Vertex(0.5f, 0.5f, 0.5f);	// Top Right Of The Texture and Quad
            gl.TexCoord(0.0f, 0.0f); gl.Vertex(-0.5f, 0.5f, 0.5f);	// Top Left Of The Texture and Quad

            // Back Face
            gl.TexCoord(1.0f, 1.0f); gl.Vertex(-0.5f, -0.5f, -0.5f);	// Bottom Right Of The Texture and Quad
            gl.TexCoord(1.0f, 0.0f); gl.Vertex(-0.5f, 0.5f, -0.5f);	// Top Right Of The Texture and Quad
            gl.TexCoord(0.0f, 0.0f); gl.Vertex(0.5f, 0.5f, -0.5f);	// Top Left Of The Texture and Quad
            gl.TexCoord(0.0f, 1.0f); gl.Vertex(0.5f, -0.5f, -0.5f);	// Bottom Left Of The Texture and Quad

            // Top Face
            gl.TexCoord(0.0f, 0.0f); gl.Vertex(-0.5f, 0.5f, -0.5f);	// Top Left Of The Texture and Quad
            gl.TexCoord(0.0f, 1.0f); gl.Vertex(-0.5f, 0.5f, 0.5f);	// Bottom Left Of The Texture and Quad
            gl.TexCoord(1.0f, 1.0f); gl.Vertex(0.5f, 0.5f, 0.5f);	// Bottom Right Of The Texture and Quad
            gl.TexCoord(1.0f, 0.0f); gl.Vertex(0.5f, 0.5f, -0.5f);	// Top Right Of The Texture and Quad

            // Bottom Face
            gl.TexCoord(0.0f, 1.0f); gl.Vertex(-0.5f, -0.5f, -0.5f);	// Top Right Of The Texture and Quad
            gl.TexCoord(1.0f, 1.0f); gl.Vertex(0.5f, -0.5f, -0.5f);	// Top Left Of The Texture and Quad
            gl.TexCoord(1.0f, 0.0f); gl.Vertex(0.5f, -0.5f, 0.5f);	// Bottom Left Of The Texture and Quad
            gl.TexCoord(0.0f, 0.0f); gl.Vertex(-0.5f, -0.5f, 0.5f);	// Bottom Right Of The Texture and Quad

            // Right face
            gl.TexCoord(1.0f, 1.0f); gl.Vertex(0.5f, -0.5f, -0.5f);	// Bottom Right Of The Texture and Quad
            gl.TexCoord(1.0f, 0.0f); gl.Vertex(0.5f, 0.5f, -0.5f);	// Top Right Of The Texture and Quad
            gl.TexCoord(0.0f, 0.0f); gl.Vertex(0.5f, 0.5f, 0.5f);	// Top Left Of The Texture and Quad
            gl.TexCoord(0.0f, 1.0f); gl.Vertex(0.5f, -0.5f, 0.5f);	// Bottom Left Of The Texture and Quad

            // Left Face
            gl.TexCoord(0.0f, 1.0f); gl.Vertex(-0.5f, -0.5f, -0.5f);	// Bottom Left Of The Texture and Quad
            gl.TexCoord(1.0f, 1.0f); gl.Vertex(-0.5f, -0.5f, 0.5f);	// Bottom Right Of The Texture and Quad
            gl.TexCoord(1.0f, 0.0f); gl.Vertex(-0.5f, 0.5f, 0.5f);	// Top Right Of The Texture and Quad
            gl.TexCoord(0.0f, 0.0f); gl.Vertex(-0.5f, 0.5f, -0.5f);	// Top Left Of The Texture and Quad
            gl.End();

            gl.Flush();



        }
    }
}
