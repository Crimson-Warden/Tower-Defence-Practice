using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Tower_Defence_Practice
{
    public class GameObject
    {
        public /*protected*/ Texture2D image;
        public string imageFile;
        public Vector2 position;
        public float rotation;
        public Vector2 origin;
        public Vector2 direction;
        public int baseSpeed;
        public Rectangle hitBox;
        public Rectangle previousHitBox;
        public int currentHealth;
        public int maxHealth;
        public Point size;
        public Color tint = Color.White;

        public void loadTexture(string path, ContentManager content )
        {
            image = content.Load<Texture2D>(path);
        }

        public virtual void updateHitBox()
        {
            previousHitBox = hitBox;
            hitBox.X = (int)position.X - (int)origin.X;
            hitBox.Y = (int)position.Y - (int)origin.Y;
            hitBox.Width = size == Point.Zero ? image.Width : size.X; //won't work if image is different from in game object
            hitBox.Height = size == Point.Zero ? image.Height : size.Y; //^^
        }

        public virtual void draw(SpriteBatch sb)
        {
            if (size == Point.Zero)
                sb.Draw(image, position, null, tint, rotation, origin, 1, SpriteEffects.None, 0);
            else
                sb.Draw(image, new Rectangle(position.ToPoint(), size), null, tint, rotation, origin, SpriteEffects.None, 0);
                //sb.Draw(image, position, size, Color.White, rotation, origin, 1, SpriteEffects.None, 0);
        }

        //public virtual void draw(SpriteBatch sb, Rectangle resize)
        //{
        //    sb.Draw(image, position, resize, Color.White, rotation, origin, 1, SpriteEffects.None, 0);
        //}
    }
}
