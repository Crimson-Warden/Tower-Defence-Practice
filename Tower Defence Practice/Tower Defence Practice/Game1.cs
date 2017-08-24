using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Tower_Defence_Practice
{
    //was about to code in an enemy moving to nodes.

    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        //public static ContentManager content = new ContentManager();
        Rectangle viewArea = new Rectangle(0, 0, 1024, 768);
        Path level1Path = new Path();
        List<Enemy> enemies = new List<Enemy>();
        Texture2D enemyImage;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            graphics.PreferredBackBufferWidth = viewArea.Width;
            graphics.PreferredBackBufferHeight = viewArea.Height;
            graphics.ApplyChanges();
            base.Initialize();
            Node start = new Node("Node", new Vector2(500, 650), level1Path, Content);
            Node a = new Node("Node", new Vector2(100, 600), level1Path, Content);
            Node b = new Node("Node", new Vector2(150, 400), level1Path, Content);
            Node c = new Node("Node", new Vector2(400, 100), level1Path, Content);
            Node end = new Node("Node", new Vector2(500, 50), level1Path, Content);
            Enemy newEnemy = new Enemy(enemyImage, 3, level1Path,enemies);
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            enemyImage = Content.Load<Texture2D>("SMG");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            enemies[0].navigatePath();
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            level1Path.draw(spriteBatch);
            foreach (Enemy e in enemies)
                e.draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
