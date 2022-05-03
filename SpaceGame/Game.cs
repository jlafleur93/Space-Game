using SFML.Graphics;
using SFML.System;
using SFML.Window;
namespace spacegame
{
    class Game
    {
        private const int WIDTH = 640; 
        private const int HEIGHT = 480;
        private const string TITLE = "Space Game!";
        private RenderWindow window;
        private VideoMode mode = new VideoMode(WIDTH, HEIGHT);
        Sprite background;
        Player player;
        EnemyManager enemies;
        public Game()
        {
            this.window = new RenderWindow(this.mode, TITLE);
            this.window.SetVerticalSyncEnabled(true);
            TextureManager.LoadTexture();
            TextManager.loadFont("FreeMono");
            background = new Sprite();
            player = new Player();
            enemies = new EnemyManager();
            background.Texture = TextureManager.BackgroundTexture;
            this.window.Closed += (sender, args) => {
                this.window.Close();
            };
           
        }
        public void run()
        {
            while(this.window.IsOpen)
            {
                //handles events, updating game/drawing game
                this.handleEvents();
                this.update();
                this.draw();

            }
        }
        private void handleEvents()
        {
            this.window.DispatchEvents();
        }
        private void updateScore()
        {
            TextManager.typeText("Score: ", player.Score, 25, Color.White, new Vector2f(10f, 10f));
        }
        private void update() 
        {
            this.updateScore();
            this.player.update();
            this.enemies.update(this.player);
            AnimationManager.update();
        }

        

        private void draw()
        {
            this.window.Clear(Color.Blue);
            this.window.Draw(this.background);
            this.player.draw(this.window);
            this.enemies.draw(this.window);
            AnimationManager.draw(this.window);
            TextManager.draw(this.window);
            this.window.Display();
        }

    }
}