using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakinBabies
{
    class Baby : GameSprite
    {
        #region Declarations
        private Texture2D babyImage;
        private Texture2D fluidImage;

        QualityBar qualityBar;
        bool isMoveLocked;
        #endregion

        #region Gets/Sets
        public Texture2D BabyImage
        {
            get { return babyImage; }
            set { babyImage = value; }
        }
        public Texture2D FluidImage
        {
            get { return fluidImage; }
            set { fluidImage = value; }
        }
        public bool IsMoveLocked
        {
            get { return isMoveLocked; }
            set { isMoveLocked = value; }
        }
        #endregion

        #region Methods
        public Baby(ContentManager Content)
        {
            baseImage = Content.Load<Texture2D>("Baby Jar");
            position = new Vector2(100, 768);
            bounds = new Rectangle((int)position.X, (int)position.Y, baseImage.Width, baseImage.Height);

            qualityBar = new QualityBar(Content, position);
            isMoveLocked = false;
        }
        public void Movement()
        {
            if (!isMoveLocked) position.X += 1;
            if (isMoveLocked) position.Y -= 10;
        }
        public void Update()
        {
            qualityBar.Update(position);
            this.Movement();
            bounds = new Rectangle((int)position.X, (int)position.Y, baseImage.Width, baseImage.Height);
        }
        public void Draw(SpriteBatch sb)
        {
            sb.Begin();
            sb.Draw(baseImage, bounds, Color.White);
            sb.End();
            qualityBar.Draw(sb);
        }
        #endregion
    }
}