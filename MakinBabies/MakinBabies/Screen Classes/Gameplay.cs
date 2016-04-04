using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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
        private List<Baby> babies;

        private Rectangle finishBox;
        #endregion

        #region Gets/Sets
        public List<Conveyor> Belt
        {
            get { return belt; }
            set { belt = value; }
        }
        public List<Baby> Babies
        {
            get { return babies; }
            set { babies = value; }
        }
        
        #endregion

        #region Methods
        public Gameplay(ContentManager Content)
        {
            this.Content = Content;
            finishBox = new Rectangle(1500, 700, 100, 100);

            #region Belts
            belt = new List<Conveyor>();
            for (int i = 0; i < 78; i++)
            {
                belt.Add(new Conveyor(Content, new Vector2(20 * i - 100, 0)));
            }
            #endregion

            babies = new List<Baby>();
            #region Babies/Baby Jars
            babies.Add(new Baby(Content));
            #endregion
        }

        public void Update()
        {
            foreach (var baby in babies)
            {
                if (baby.Bounds.Intersects(finishBox)) baby.IsMoveLocked = true;
                baby.Update();
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A)) babies.Add(new Baby(Content));
        }

        public void Draw(SpriteBatch sb)
        {
            foreach (var beltPart in belt)
            {
                beltPart.Draw(sb);
            }
            foreach (var baby in babies)
            {
                baby.Draw(sb);
            }
            //sb.Begin();
            //sb.Draw(testBaby.BaseImage, finishBox, Color.White);
            //sb.End();
        }
        #endregion
    }
}
