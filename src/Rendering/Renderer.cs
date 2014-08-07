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

            gl.Enable(OpenGL.GL_TEXTURE_2D);
            gl.ClearColor(0.0f, 0.0f, 0.2f, 1.0f);
        }



        public void draw(Camera camera, GameState state)
        {


            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gl.Enable(OpenGL.GL_BLEND);
            gl.BlendFunc(OpenGL.GL_SRC_ALPHA, OpenGL.GL_ONE_MINUS_SRC_ALPHA);
            gl.LoadIdentity();
            gl.Translate(0.0f, 0.0f, camera.zoom);
            gl.Rotate(camera.cubeRotation.x, camera.cubeRotation.y, camera.cubeRotation.z);
            gl.Color(1.0f, 1.0f, 1.0f, 0.45f);

            float[] mv = new float[16];
            gl.GetFloat(OpenGL.GL_MODELVIEW_MATRIX, mv);

            List<Tuple<Vector3D, int, float>> values = new List<Tuple<Vector3D, int, float>>();

            for (int i = 0; i < GameState.size; i++)
            {
                for (int j = 0; j < GameState.size; j++)
                {
                    for (int k = 0; k < GameState.size; k++)
                    {
                        if (state.field[i, j, k] != 0)
                        {
                            Vector3D cubeData = new Vector3D(-GameState.size / 2.0f + 0.5f + i, -GameState.size / 2.0f + 0.5f + j, -GameState.size / 2.0f + 0.5f + k);
                            int cubeValue = state.field[i, j, k];
                            float depth = cubeData*new Vector3D(mv[2],mv[6],mv[10]);
                            values.Add(new Tuple<Vector3D, int, float>(cubeData, cubeValue, depth));
                        }
                    }
                }
            }
            values.Sort((a, b) => a.Item3.CompareTo(b.Item3));
            gl.DepthMask(0);

            foreach (var cube in values) 
            {
                gl.PushMatrix();
                gl.Translate(cube.Item1.x, cube.Item1.y, cube.Item1.z);
                drawCube(cube.Item2);

                gl.PopMatrix();
            }
            gl.DepthMask(1);
        }




        private void drawCube(int number)
        {
            Texture texture = textures.get(number);

            //  Bind the texture.
            texture.Bind(gl);

            Vector3D color = Util.Color.getTileColor(number);
            gl.Color(color.x, color.y, color.z, 0.7f);

            gl.Begin(OpenGL.GL_QUADS);

            // Front Face
            gl.TexCoord(0.0f, 1.0f); gl.Vertex(-0.5f, -0.5f, 0.5f);	// Bottom Left Of The Texture and Quad
            gl.TexCoord(1.0f, 1.0f); gl.Vertex(0.5f, -0.5f, 0.5f);	// Bottom Right Of The Texture and Quad
            gl.TexCoord(1.0f, 0.0f); gl.Vertex(0.5f, 0.5f, 0.5f);	// Top Right Of The Texture and Quad
            gl.TexCoord(0.0f, 0.0f); gl.Vertex(-0.5f, 0.5f, 0.5f);	// Top Left Of The Texture and Quad

            // Back Face
            gl.TexCoord(1.0f, 1.0f); gl.Vertex(-0.5f, -0.5f, -0.5f);// Bottom Right Of The Texture and Quad
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

        }

        private void checkState(bool won)
        {
            if (won)
            {

            }
            else
            {

            }
        }
    }
}
