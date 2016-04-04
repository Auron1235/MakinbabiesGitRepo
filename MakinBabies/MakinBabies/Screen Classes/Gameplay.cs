using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MakinBabies
{
    class Gameplay
    {
        #region Declarations
        private ContentManager Content;

        private List<Conveyor> belt;
        private Baby testBaby;
        #endregion

        #region Gets/Sets
        public List<Conveyor> Belt
        {
            get { return belt; }
            set { belt = value; }
        }
        public Baby TestBaby
        {
            get { return testBaby; }
            set { testBaby = value; }
        }
        
        #endregion

        #region Methods
        public Gameplay(ContentManager Content)
        {
            this.Content = Content;

            #region Belts
            belt = new List<Conveyor>();
            for (int i = 0; i < 60; i++)
            {
                belt.Add(new Conveyor(Content, new Vector2(20 * i, 0)));
            }
            #endregion

            #region Babies/Baby Jars
            testBaby = new Baby(Content);
            #endregion
        }

        public void Update()
        {
            testBaby.Update();
        }

        public void Draw(SpriteBatch sb)
        {
            testBaby.Draw(sb);
            foreach (var beltPart in belt)
            {
                beltPart.Draw(sb);
            }
        }
        #endregion
    }
}
