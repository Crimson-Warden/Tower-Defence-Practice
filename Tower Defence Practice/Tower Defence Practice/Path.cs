using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tower_Defence_Practice
{
    class Path //does this need to be its own class?
    {
        public List<Node> nodes = new List<Node>();

        public void draw(SpriteBatch sb)
        {
            foreach (Node n in nodes)
                sb.Draw(n.image, n.position, Color.White);
        }
    }
    
    class Node : GameObject
    {
        int placeInPath;
        public int nextNodeInPath;

        public Node(string imageFile, Vector2 position, Path path, ContentManager content)
        {
            loadTexture(imageFile, content);
            this.position = position;
            updateHitBox();
            path.nodes.Add(this);

            //will need to make these changable in some way to be able to add in spliting paths etc
            placeInPath = path.nodes.Count - 1; 
            nextNodeInPath = placeInPath + 1;
        }
    }
}
