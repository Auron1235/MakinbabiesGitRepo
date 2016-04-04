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

        private int quality;
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
        public int Quality
        {
            get { return quality; }
            set { quality = value; }
        }
        
        #endregion

        #region Methods
        public Baby(ContentManager Content)
        {
            baseImage = Content.Load<Texture2D>("Baby Jar");
            position = new Vector2(100, 768);
            bounds = new Rectangle((int)position.X, (int)position.Y, baseImage.Width, baseImage.Height);
        }

        public void Update()
        {
            position.X += 1f;
            bounds = new Rectangle((int)position.X, (int)position.Y, baseImage.Width, baseImage.Height);
        }
        #endregion
    }
}