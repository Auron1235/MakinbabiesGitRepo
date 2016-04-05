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
    class Title
    {
        #region Declarations
        private ContentManager Content;
        private KeyboardState oldKeyState;

        private List<Conveyor> belt;
        private List<Baby> babies;
        private int babyTimer;

        private Options optionsSection;

        private Rectangle finishBox;

        private Button startButton;
        private Button exitButton;
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
        public Button StartButton
        {
            get { return startButton; }
            set { startButton = value; }
        }
        public Button ExitButton
        {
            get { return exitButton; }
            set { exitButton = value; }
        }
        #endregion

        #region Methods
        public Title(ContentManager Content)
        {
            this.Content = Content;
            oldKeyState = Keyboard.GetState();
            startButton = new Button(Content, "StartButton", new Vector2(400, 500));
            exitButton = new Button(Content, "ExitButton", new Vector2(900, 500));
            finishBox = new Rectangle(1600, 700, 1, 100);

            #region Belts
            belt = new List<Conveyor>();
            for (int i = 0; i < 70; i++)
            {
                belt.Add(new Conveyor(Content, new Vector2(20 * i - 100, 0)));
            }
            #endregion

            #region Babies
            babies = new List<Baby>();
            babies.Add(new Baby(Content));
            #endregion

            #region Options Area
            optionsSection = new Options(Content);
            #endregion
        }
        public void Clear()
        {
            babies.Clear();
        }
        public void Update()
        {
            KeyboardState newKeyState = Keyboard.GetState();
            startButton.Update();
            exitButton.Update();

            #region Baby Update
            babyTimer++;
            for (int i = 0; i < babies.Count; i++)
            {
                if (babies[i].Bounds.Intersects(finishBox))
                {
                    babies[i].IsStopped = true;
                    babies[i].IsUnderChute = true;
                    //Add points total code
                }
            }
            foreach (var baby in babies)
            {
                baby.Update();
            }
            if (babyTimer >= 350)
            {
                babyTimer = 0;
                babies.Add(new Baby(Content));
            }
            #endregion

            #region Buttons Update
            #endregion

            optionsSection.Update();

            oldKeyState = newKeyState;
        }

        public void Draw(SpriteBatch sb)
        {
            #region Belt Draw
            foreach (var beltPart in belt)
            {
                beltPart.Draw(sb);
            }
            #endregion

            #region Baby Draw
            foreach (var baby in babies)
            {
                baby.Draw(sb);
            }
            #endregion

            #region Buttons Draw
            startButton.SpriteSheetDraw(sb);
            exitButton.SpriteSheetDraw(sb);
            #endregion
            
            optionsSection.Draw(sb);
        }
        #endregion
    }
}
