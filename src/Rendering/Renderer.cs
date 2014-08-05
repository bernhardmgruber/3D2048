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

        public Renderer(OpenGL glIn)
        {
            gl = glIn;
        }



        Texture texture = new Texture();
        String texturePath = "texture_2.bmp";

        private int gameMatrixSize = 4; //to be replaced
   

        public void draw(Camera camera, GameState state)
        {


            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gl.LoadIdentity();
            gl.Translate(0.0f, 0.0f, camera.zoom);
            gl.Rotate(camera.cubeRotation.x, camera.cubeRotation.y, camera.cubeRotation.z);
            gl.Color(1.0f,1.0f,1.0f);

            for (int i = 0; i < gameMatrixSize; i++)
            {
                for (int j = 0; j < gameMatrixSize; j++)
                {
                    for (int k = 0; k < gameMatrixSize; k++)
                    {
                        if (state.field[i, j, k] != 0)
                        {
                            gl.PushMatrix();
                            gl.Translate(-gameMatrixSize / 2 + 0.5 + i, -gameMatrixSize / 2 + 0.5 + j, -gameMatrixSize / 2 + 0.5 + k);
                            drawCube();
                            gl.PopMatrix();
                        }
                    }
                }
            }
        }




        private void drawCube()
        {
            texture.Create(gl, texturePath);

            //  Bind the texture.
            texture.Bind(gl);


            gl.Begin(OpenGL.GL_QUADS);

            // Front Face
            gl.TexCoord(0.0f, 0.0f); gl.Vertex(-0.5f, -0.5f, 0.5f);	// Bottom Left Of The Texture and Quad
            gl.TexCoord(1.0f, 0.0f); gl.Vertex(0.5f, -0.5f, 0.5f);	// Bottom Right Of The Texture and Quad
            gl.TexCoord(1.0f, 1.0f); gl.Vertex(0.5f, 0.5f, 0.5f);	// Top Right Of The Texture and Quad
            gl.TexCoord(0.0f, 1.0f); gl.Vertex(-0.5f, 0.5f, 0.5f);	// Top Left Of The Texture and Quad

            // Back Face
            gl.TexCoord(1.0f, 0.0f); gl.Vertex(-0.5f, -0.5f, -0.5f);	// Bottom Right Of The Texture and Quad
            gl.TexCoord(1.0f, 1.0f); gl.Vertex(-0.5f, 0.5f, -0.5f);	// Top Right Of The Texture and Quad
            gl.TexCoord(0.0f, 1.0f); gl.Vertex(0.5f, 0.5f, -0.5f);	// Top Left Of The Texture and Quad
            gl.TexCoord(0.0f, 0.0f); gl.Vertex(0.5f, -0.5f, -0.5f);	// Bottom Left Of The Texture and Quad

            // Top Face
            gl.TexCoord(0.0f, 1.0f); gl.Vertex(-0.5f, 0.5f, -0.5f);	// Top Left Of The Texture and Quad
            gl.TexCoord(0.0f, 0.0f); gl.Vertex(-0.5f, 0.5f, 0.5f);	// Bottom Left Of The Texture and Quad
            gl.TexCoord(1.0f, 0.0f); gl.Vertex(0.5f, 0.5f, 0.5f);	// Bottom Right Of The Texture and Quad
            gl.TexCoord(1.0f, 1.0f); gl.Vertex(0.5f, 0.5f, -0.5f);	// Top Right Of The Texture and Quad

            // Bottom Face
            gl.TexCoord(1.0f, 1.0f); gl.Vertex(-0.5f, -0.5f, -0.5f);	// Top Right Of The Texture and Quad
            gl.TexCoord(0.0f, 1.0f); gl.Vertex(0.5f, -0.5f, -0.5f);	// Top Left Of The Texture and Quad
            gl.TexCoord(0.0f, 0.0f); gl.Vertex(0.5f, -0.5f, 0.5f);	// Bottom Left Of The Texture and Quad
            gl.TexCoord(1.0f, 0.0f); gl.Vertex(-0.5f, -0.5f, 0.5f);	// Bottom Right Of The Texture and Quad

            // Right face
            gl.TexCoord(1.0f, 0.0f); gl.Vertex(0.5f, -0.5f, -0.5f);	// Bottom Right Of The Texture and Quad
            gl.TexCoord(1.0f, 1.0f); gl.Vertex(0.5f, 0.5f, -0.5f);	// Top Right Of The Texture and Quad
            gl.TexCoord(0.0f, 1.0f); gl.Vertex(0.5f, 0.5f, 0.5f);	// Top Left Of The Texture and Quad
            gl.TexCoord(0.0f, 0.0f); gl.Vertex(0.5f, -0.5f, 0.5f);	// Bottom Left Of The Texture and Quad

            // Left Face
            gl.TexCoord(0.0f, 0.0f); gl.Vertex(-0.5f, -0.5f, -0.5f);	// Bottom Left Of The Texture and Quad
            gl.TexCoord(1.0f, 0.0f); gl.Vertex(-0.5f, -0.5f, 0.5f);	// Bottom Right Of The Texture and Quad
            gl.TexCoord(1.0f, 1.0f); gl.Vertex(-0.5f, 0.5f, 0.5f);	// Top Right Of The Texture and Quad
            gl.TexCoord(0.0f, 1.0f); gl.Vertex(-0.5f, 0.5f, -0.5f);	// Top Left Of The Texture and Quad
            gl.End();

            gl.Flush();



        }
    }
}
