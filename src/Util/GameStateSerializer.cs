using _3D2048.Logic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace _3D2048.Util
{
    class GameStateSerializer
    {

        public static GameState loadState(String filename)
        {
            using (FileStream fs = File.OpenRead(filename))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(GameState));
                return (GameState) serializer.Deserialize(fs);
            }
        }

        public static void saveState(GameState state, String filename) 
        {
            //Create the file.
            using (FileStream fs = File.Create(filename))
            {
                XmlSerializer serializer = new XmlSerializer(typeof (GameState));
                serializer.Serialize(fs, state);
            }            
        }
    }
}
