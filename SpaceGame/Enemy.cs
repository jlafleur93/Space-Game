using SFML.Graphics;
using SFML.System;
namespace spacegame{
    class Enemy
    {
        private readonly Random random = new Random();
        private Sprite sprite;
        public const float ENEMY_SPEED = 0.01f;
        Vector2f position;
        public Sprite EnemySprite { get { return sprite; } }

        public Vector2f Position {get { return position; }}

        public Enemy()
        {
            this.sprite = new Sprite();
            this.sprite.Texture = TextureManager.EnemyTexture;
            this.position.X = (float)this.random.Next(0, 640);
            this.position.Y = -(float)this.random.Next(0, 480);
            this.sprite.Position = this.position;

        }
        public void update()
        {
            this.position.Y += ENEMY_SPEED;
            this.sprite.Position = this.position;

        }
        public void draw(RenderTarget window)
        {
            window.Draw(this.sprite);
        }
    }
}