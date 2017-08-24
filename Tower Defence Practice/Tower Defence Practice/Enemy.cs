using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tower_Defence_Practice
{
    class Enemy : GameObject
    {
        Random rng = new Random();
        Path path = new Path();
        int placeInPath = 0; //is there a need to change this manually? 
        int health; //does it need current/max? why? could enemies heal? 

        public Enemy(Texture2D image, int baseSpeed, Path path, List<Enemy> list)
        {
            this.image = image;
            position = path.nodes[0].position;
            this.position = position + new Vector2(rng.Next(-25, 25), rng.Next(-10, 10));
            this.baseSpeed = baseSpeed;
            this.path = path;
            list.Add(this);
        }

        //public Enemy(string imageFile, Vector2 position, int baseSpeed, List<Enemy> list, ContentManager content)
        //{
        //    loadTexture(imageFile, content);
        //    this.position = position + new Vector2(rng.Next(-25, 25), rng.Next(-10, 10));
        //    this.baseSpeed = baseSpeed;
        //    list.Add(this);
        //}

        //shoud this have a paramater or should it be a variable this class 
        public void navigatePath()
        {
            Vector2 trajectory = new Vector2(path.nodes[placeInPath].position.X - position.X, path.nodes[placeInPath].position.Y - position.Y);
            trajectory.Normalize();
            double r = Math.Sqrt(Math.Pow(trajectory.X, 2) + Math.Pow(trajectory.Y, 2));
            //double angle = Math.Atan2(trajectory.Y, trajectory.X);
            ////angle += MathHelper.ToRadians(adjustRot);
            //trajectory.X = (float)(r * Math.Cos(angle));
            //trajectory.Y = (float)(r * Math.Sin(angle));
            direction.X = trajectory.X * baseSpeed;
            direction.Y = trajectory.Y * baseSpeed;
            if (hitBox.Intersects(path.nodes[placeInPath].hitBox))
            {
                if(placeInPath < path.nodes.Count -1)
                    placeInPath = path.nodes[placeInPath].nextNodeInPath;
                else
                {
                    //should be the end of the level or whatever, presumally the player loses lives/hp or something
                } 
            }
            position += direction;
            updateHitBox();
        }
    }
}
