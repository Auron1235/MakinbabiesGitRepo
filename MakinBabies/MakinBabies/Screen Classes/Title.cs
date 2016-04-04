using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MakinBabies
{
    class Title
    {
        #region Declarations
        #endregion

        #region Gets/Sets
        #endregion

        #region Methods
        public Title(ContentManager Content)
        {

        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch sb)
        {
            sb.Begin();
            //sb.Draw(splashImage, position, Color.White);
            sb.End();
        }
        #endregion
    }
}
