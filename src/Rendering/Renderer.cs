using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SharpGL;
using SharpGL.SceneGraph.Assets;
using _3D2048.Util;
using _3D2048.Logic;
using GlmNet;
using System.Diagnostics;

namespace _3D2048.Rendering
{
    class Renderer
    {
        //Declaration of necessary objects
        private OpenGL gl;
        private Textures textures;


        public Renderer(OpenGL glIn)
        {
            //Generates Textures for input OpenGL Object
            gl = glIn;
            textures = new Textures(gl);


            gl.Enable(OpenGL.GL_TEXTURE_2D);    //Enables Textures
            gl.Enable(OpenGL.GL_CULL_FACE);    //Removes the Backside of the Cubes

            //Removal of all unwanted colours
            gl.ClearColor(0.0f, 0.0f, 0.2f, 1.0f);
        }

        public float toRadians(float value)
        {
            return value / 180f * (float)Math.PI;
        }

        public void draw(Camera camera, GameState state)
        {
            //Setup of the gl Object in conjunction with camera Settings
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gl.Enable(OpenGL.GL_BLEND);
            gl.BlendFunc(OpenGL.GL_SRC_ALPHA, OpenGL.GL_ONE_MINUS_SRC_ALPHA);
            //gl.LoadIdentity();
            //gl.Translate(0.0f, 0.0f, camera.zoom);
            //gl.Rotate(camera.cubeRotation.x, camera.cubeRotation.y, camera.cubeRotation.z);
            gl.Color(1.0f, 1.0f, 1.0f, 0.45f);                                              //Base Color with alpha(transparency) value

            // create modelview matrix from camera
            Matrix4D mv = Matrix4D.Identity();
            mv = mv * Matrix4D.Translate(new Vector3D(0, 0, camera.zoom));
            mv = mv * Matrix4D.RotateX(-toRadians(camera.cubeRotation.x));
            mv = mv * Matrix4D.RotateY(-toRadians(camera.cubeRotation.y));
            mv = mv * Matrix4D.RotateZ(-toRadians(camera.cubeRotation.z));

            //Setup of a new List of Tuples(for multiple Parameters) to store Cube information
            List<Tuple<Vector3D, int, float>> values = new List<Tuple<Vector3D, int, float>>();

            //Runthrough of the Gamestate Matrix in search for cubes to be rendered
            for (int i = 0; i < GameState.size; i++)
            {
                for (int j = 0; j < GameState.size; j++)
                {
                    for (int k = 0; k < GameState.size; k++)
                    {
                        if (state.field[i, j, k] != 0)
                        {
                            Vector3D cubeData = new Vector3D(-GameState.size / 2.0f + 0.5f + i, -GameState.size / 2.0f + 0.5f + j, -GameState.size / 2.0f + 0.5f + k);  //Calculates and saves a single cubes object coord center on the world coordinates  
                            int cubeValue = state.field[i, j, k];                                                                                                       //Saves Value of a Cube from the current Position in the gamestate Matrix
                            
                            //Adds The Modelmatrix to all Points of the Cube                                                   
                            Vector3D transformedCubeOrigin = new Vector3D(
                                cubeData * new Vector3D(mv[0, 0], mv[1, 0], mv[2, 0]) + mv[3, 0],
                                cubeData * new Vector3D(mv[0, 1], mv[1, 1], mv[2, 1]) + mv[3, 1],
                                cubeData * new Vector3D(mv[0, 2], mv[1, 2], mv[2, 2]) + mv[3, 2]);

                            float depth = transformedCubeOrigin.Length;
  
                            values.Add(new Tuple<Vector3D, int, float>(cubeData, cubeValue, depth));                                                                    //The List is fed with the Position, Value and depth of the Cubes
                        }
                    }
                }
            }
            values.Sort((a, b) => -a.Item3.CompareTo(b.Item3)); //List is sorted by depth
            gl.DepthMask(0);    //Depth Mask is deactivated

            //Cubes are Drawn seperately before World Coordinates are Repositioned
            foreach (var cube in values)
            {
                //gl.PushMatrix();
                //gl.Translate(cube.Item1.x, cube.Item1.y, cube.Item1.z);
                Matrix4D m = mv * Matrix4D.Translate(new Vector3D(cube.Item1.x, cube.Item1.y, cube.Item1.z));
                gl.LoadMatrixf(m.toArray());

                //  Bind the texture.
                textures.get(cube.Item2).Bind(gl);

                Vector3D color = Util.Color.getTileColor(cube.Item2);
                gl.Color(color.x, color.y, color.z, 0.7f);

                // draw
                drawCube();

                //gl.PopMatrix();
            }
            gl.DepthMask(1); //Depth Mask is reaxtivated
        }

        private void drawCube()
        {
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
            gl.TexCoord(0.0f, 1.0f); gl.Vertex(-0.5f, -0.5f, -0.5f);// Top Right Of The Texture and Quad
            gl.TexCoord(1.0f, 1.0f); gl.Vertex(0.5f, -0.5f, -0.5f);	// Top Left Of The Texture and Quad
            gl.TexCoord(1.0f, 0.0f); gl.Vertex(0.5f, -0.5f, 0.5f);	// Bottom Left Of The Texture and Quad
            gl.TexCoord(0.0f, 0.0f); gl.Vertex(-0.5f, -0.5f, 0.5f);	// Bottom Right Of The Texture and Quad

            // Right face
            gl.TexCoord(1.0f, 1.0f); gl.Vertex(0.5f, -0.5f, -0.5f);	// Bottom Right Of The Texture and Quad
            gl.TexCoord(1.0f, 0.0f); gl.Vertex(0.5f, 0.5f, -0.5f);	// Top Right Of The Texture and Quad
            gl.TexCoord(0.0f, 0.0f); gl.Vertex(0.5f, 0.5f, 0.5f);	// Top Left Of The Texture and Quad
            gl.TexCoord(0.0f, 1.0f); gl.Vertex(0.5f, -0.5f, 0.5f);	// Bottom Left Of The Texture and Quad

            // Left Face
            gl.TexCoord(0.0f, 1.0f); gl.Vertex(-0.5f, -0.5f, -0.5f);// Bottom Left Of The Texture and Quad
            gl.TexCoord(1.0f, 1.0f); gl.Vertex(-0.5f, -0.5f, 0.5f);	// Bottom Right Of The Texture and Quad
            gl.TexCoord(1.0f, 0.0f); gl.Vertex(-0.5f, 0.5f, 0.5f);	// Top Right Of The Texture and Quad
            gl.TexCoord(0.0f, 0.0f); gl.Vertex(-0.5f, 0.5f, -0.5f);	// Top Left Of The Texture and Quad
            gl.End();

        }
    }

}
