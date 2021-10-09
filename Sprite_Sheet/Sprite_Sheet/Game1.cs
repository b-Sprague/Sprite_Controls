using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace Sprite_Sheet
{
    public class Game1 : Game
    {
        #region Variables
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        // Reference
        public static int screenWidth;
        public static int screenHieght;
        public static Vector2 screenMiddle;

        private Player _player;
        //private Camera _camera;
        #endregion

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            // Graphics
            graphics.PreferredBackBufferWidth = GraphicsDevice.DisplayMode.Width;
            graphics.PreferredBackBufferHeight = GraphicsDevice.DisplayMode.Height;
            //graphics.IsFullScreen = true;
            graphics.ApplyChanges();

            // Reference
            screenWidth = GraphicsDevice.Viewport.Width;
            screenHieght = GraphicsDevice.Viewport.Height;
            screenMiddle = new Vector2(screenWidth / 2, screenHieght / 2);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            //_camera = new Camera();
            _player = new Player(Content.Load<Texture2D>("Star_Soldier_Sprte_Sht_x4_v2_GIMP"), 0, 184, 204);
            _player.position = new Vector2(400, 300);

        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _player.HandleSpriteMovement(gameTime);
            //_camera.Follow(_player);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            //spriteBatch.Begin(transformMatrix: _camera.Transform);
            spriteBatch.Draw(_player.playerTexture, _player.position, _player.playerRec, Color.White, 0f, _player.origin, 1.0f, SpriteEffects.None, 0);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
