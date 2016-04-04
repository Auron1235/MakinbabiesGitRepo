using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakinBabies
{
    class QualityBar : GameSprite
    {
        #region Declarations
        private Rectangle barLevel;
        private Texture2D barLevelImage;
        #endregion

        #region Gets/Sets
        public Rectangle BarLevel
        {
            get { return barLevel; }
            set { barLevel = value; }
        }

        public Texture2D BarLevelImage
        {
            get { return barLevelImage; }
            set { barLevelImage = value; }
        } 
        #endregion

        #region Methods
        public void DrawBar(SpriteBatch sb)
        {
            sb.Begin();
            sb.Draw(barLevelImage, barLevel, Color.Green);
            sb.End();
        }
        #endregion
    }
}
