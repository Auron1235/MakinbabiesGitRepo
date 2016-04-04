using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MakinBabies
{
    class Splash
    {
        #region Declarations
        private Texture2D splashImage;
        private Vector2 position;

        private float timer;
        #endregion

        #region Gets/Sets
        public Texture2D SplashImage
        {
            get { return splashImage; }
            set { splashImage = value; }
        }
        #endregion

        #region Methods
        public Splash(ContentManager Content)
        {
            splashImage = Content.Load<Texture2D>("Splash");
            position = Vector2.Zero;
        }
        public void Update()
        {
            timer++;
        }
        public bool CheckTimer()
        {
            if (timer >= 200) return true;
            return false;
        }
        public void Draw(SpriteBatch sb)
        {
            sb.Begin();
            sb.Draw(splashImage, position, Color.White);
            sb.End();
        }
        #endregion
    }
}
